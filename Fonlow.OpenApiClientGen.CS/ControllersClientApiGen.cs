﻿using Fonlow.OpenApiClientGen.ClientTypes;
using Microsoft.CodeAnalysis;
using Microsoft.OpenApi.Models;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Fonlow.OpenApiClientGen.CS
{
	/// <summary>
	/// Store CodeDom references shared by all functions of the client API class.
	/// </summary>
	internal class SharedContext
	{
		internal CodeFieldReferenceExpression ClientReference { get; set; }
		internal CodeFieldReferenceExpression BaseUriReference { get; set; }
		internal CodeFieldReferenceExpression JsonSerializerReference { get; set; }
	}


	/// <summary>
	/// Generate .NET codes of the client API of the controllers
	/// </summary>
	public class ControllersClientApiGen
	{
		readonly CodeCompileUnit codeCompileUnit;
		readonly SharedContext sharedContext;
		CodeNamespace clientNamespace;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="codeGenParameters"></param>
		/// <remarks>The client data types should better be generated through SvcUtil.exe with the DC option. The client namespace will then be the original namespace plus suffix ".client". </remarks>
		public ControllersClientApiGen(Settings settings)
		{
			this.settings = settings;
			codeCompileUnit = new CodeCompileUnit();
			sharedContext = new SharedContext();
			nameComposer = new NameComposer(settings);
		}

		readonly Settings settings;

		readonly NameComposer nameComposer;

		/// <summary>
		/// Write CodeDOM into C# codes to TextWriter. And the C# codes is a bit hacky.
		/// </summary>
		/// <param name="writer"></param>
		void GenerateHackyCodesToWriter(TextWriter writer)
		{
			if (writer == null)
				throw new ArgumentNullException(nameof(writer), "No TextWriter instance is defined.");

			using CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
			CodeGeneratorOptions options = new CodeGeneratorOptions() { BracingStyle = "C", IndentString = "\t" };
			provider.GenerateCodeFromCompileUnit(codeCompileUnit, writer, options);
		}

		/// <summary>
		/// Save C# codes to a file.
		/// </summary>
		/// <param name="fileName"></param>
		// hack inspired by https://csharpcodewhisperer.blogspot.com/2014/10/create-c-class-code-from-datatable.html
		public void Save(string fileName)
		{
			using StreamWriter streamWriter = new StreamWriter(fileName);
			GenerateCodesToWriter(streamWriter);
		}

		/// <summary>
		/// Write CodeDOM into C# codes to text
		/// </summary>
		/// <returns>C# codes</returns>
		public string WriteToText()
		{
			using StringWriter stringWriter = new StringWriter();
			GenerateCodesToWriter(stringWriter);
			return stringWriter.ToString();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="textWriter">To receive refined codes</param>
		void GenerateCodesToWriter(TextWriter textWriter)
		{
			using MemoryStream stream = new MemoryStream();
			using StreamWriter writer = new StreamWriter(stream);
			GenerateHackyCodesToWriter(writer);

			writer.Flush();
			stream.Position = 0;
			using StreamReader streamReader = new StreamReader(stream);
			string s = streamReader.ReadToEnd();
			if (settings.UseEnsureSuccessStatusCodeEx)
			{
				textWriter.Write(s.Replace("//;", "").Replace(dummyBlock, blockOfEnsureSuccessStatusCodeEx));
			}
			else
			{
				textWriter.Write(s.Replace("//;", ""));
			}
		}

		/// <summary>
		/// Generate CodeDom of the client API for ApiDescriptions.
		/// </summary>
		/// <param name="descriptions">Web Api descriptions exposed by Configuration.Services.GetApiExplorer().ApiDescriptions</param>
		public void CreateCodeDom(OpenApiPaths paths, OpenApiComponents components)
		{
			if (paths == null && components == null)
			{
				return;
			}

			clientNamespace = new CodeNamespace(settings.ClientNamespace);
			codeCompileUnit.Namespaces.Add(clientNamespace);//namespace added to Dom

			ComponentsToCsTypes componentsToCsTypes = new ComponentsToCsTypes(settings, codeCompileUnit, clientNamespace);
			componentsToCsTypes.CreateCodeDom(components);

			if (paths == null)
				return;

			clientNamespace.Imports.AddRange(new CodeNamespaceImport[]{
				new CodeNamespaceImport("System"),
				new CodeNamespaceImport("System.Linq"),
				new CodeNamespaceImport("System.Collections.Generic"),
				new CodeNamespaceImport("System.Threading.Tasks"),
				new CodeNamespaceImport("System.Net.Http"),
				new CodeNamespaceImport("Newtonsoft.Json"),
				new CodeNamespaceImport("Json = Newtonsoft.Json"),
				new	CodeNamespaceImport("System.IO"),
				new CodeNamespaceImport("System.Threading"),
				new CodeNamespaceImport("System.Net.Http.Headers")
				});

			if (settings.UseEnsureSuccessStatusCodeEx)
			{
				clientNamespace.Imports.Add(new CodeNamespaceImport("Fonlow.Net.Http"));
			}

			string[] containerClassNames = GetContainerClassNames(paths);

			CodeTypeDeclaration[] newClassesCreated = containerClassNames.Select(d => CreateControllerClientClass(clientNamespace, d)).ToArray();

			foreach (KeyValuePair<string, OpenApiPathItem> p in paths)
			{
				foreach (KeyValuePair<OperationType, OpenApiOperation> op in p.Value.Operations)
				{
					ClientApiFunctionGen apiFunctionGen = new ClientApiFunctionGen();
					CodeMemberMethod apiFunction = apiFunctionGen.CreateApiFunction(settings, p.Key, op.Key, op.Value, componentsToCsTypes, true, settings.UseEnsureSuccessStatusCodeEx);
					if (apiFunction == null)
					{
						System.Diagnostics.Trace.TraceWarning($"Not to generate C# for {p.Key} {op.Key}.");
						continue;
					}

					string containerClassName = nameComposer.GetContainerName(op.Value, p.Key);
					CodeTypeDeclaration existingClass = LookupExistingClass(containerClassName);

					existingClass.Members.Add(apiFunction);
					if (settings.GenerateBothAsyncAndSync)
					{
						ClientApiFunctionGen functionGen2 = new ClientApiFunctionGen();
						existingClass.Members.Add(functionGen2.CreateApiFunction(settings, p.Key, op.Key, op.Value, componentsToCsTypes, false, settings.UseEnsureSuccessStatusCodeEx));
					}
				}
			}

			if (settings.UseEnsureSuccessStatusCodeEx)
			{
				CreateDummyOfEnsureSuccessStatusCodeEx();
			}
		}

		//public CompilerResults CompileThenSave(string fileName)//not working in .net core
		//{
		//	using CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
		//	CodeGeneratorOptions options = new CodeGeneratorOptions() { BracingStyle = "C", IndentString = "\t" };
		//	var s = WriteToText();
		//	var results = provider.CompileAssemblyFromSource(  //https://docs.microsoft.com/en-us/dotnet/core/compatibility/unsupported-apis
		//		new CompilerParameters(new string[] { "System.Net.Http", "Newtonsoft.Json" })
		//		{
		//			GenerateInMemory = true,
		//		}, s
		//		);

		//	File.WriteAllText(fileName, s); //save the file anyway

		//	return results;
		//}

		string[] GetContainerClassNames(OpenApiPaths paths)
		{
			if (settings.ContainerNameStrategy == ContainerNameStrategy.None)
			{
				return new string[] { settings.ContainerClassName };
			}

			List<string> names = new List<string>();

			foreach (KeyValuePair<string, OpenApiPathItem> p in paths)
			{
				foreach (KeyValuePair<OperationType, OpenApiOperation> op in p.Value.Operations)
				{
					string name = nameComposer.GetContainerName(op.Value, p.Key);
					names.Add(name);
				}
			}

			return names.Distinct().ToArray();
		}

		/// <summary>
		/// Lookup existing CodeTypeDeclaration created.
		/// </summary>
		/// <param name="controllerName"></param>
		/// <returns></returns>
		CodeTypeDeclaration LookupExistingClass(string controllerName)
		{
			for (int i = 0; i < codeCompileUnit.Namespaces.Count; i++)
			{
				CodeNamespace ns = codeCompileUnit.Namespaces[i];
				if (ns.Name == settings.ClientNamespace)
				{
					for (int k = 0; k < ns.Types.Count; k++)
					{
						CodeTypeDeclaration c = ns.Types[k];
						if (c.Name == controllerName)
							return c;
					}
				}
			}

			return null;
		}

		CodeTypeDeclaration CreateControllerClientClass(CodeNamespace ns, string className)
		{
			CodeTypeDeclaration targetClass = new CodeTypeDeclaration(className)
			{
				IsClass = true,
				IsPartial = true,
				TypeAttributes = TypeAttributes.Public,
			};

			ns.Types.Add(targetClass);
			AddLocalFields(targetClass);
			AddConstructorWithHttpClient(targetClass);
			AddDeserializeMethod(targetClass);
			AddSerializeMethod(targetClass);

			return targetClass;
		}

		static void AddDeserializeMethod(CodeTypeDeclaration targetClass)
        {
			CodeMemberMethod method = new CodeMemberMethod();
			CodeTypeParameter tType = new CodeTypeParameter("T");
			method.Name = "Deserialize";
			method.Attributes = MemberAttributes.Private | MemberAttributes.Static;
			method.TypeParameters.Add(tType);
			method.ReturnType = new CodeTypeReference("T");

			method.Parameters.Add(new CodeParameterDeclarationExpression(
				"JsonSerializer", "serializer"));
			method.Parameters.Add(new CodeParameterDeclarationExpression(
				"System.String", "jsonText"));

			method.Statements.Add(new CodeSnippetStatement(
			$@"			using var r = new JsonTextReader(new StringReader(jsonText));"
			));
			method.Statements.Add(new CodeSnippetStatement(
			$@"			return serializer.Deserialize<T>(r);"
			));

			targetClass.Members.Add(method);
		}

		static void AddSerializeMethod(CodeTypeDeclaration targetClass)
		{
			CodeMemberMethod method = new CodeMemberMethod();
			method.Name = "Serialize";
			method.Attributes = MemberAttributes.Private | MemberAttributes.Static;
			method.ReturnType = new CodeTypeReference("System.String");

			method.Parameters.Add(new CodeParameterDeclarationExpression(
				"JsonSerializer", "serializer"));
			method.Parameters.Add(new CodeParameterDeclarationExpression(
				"System.Object", "value"));

			method.Statements.Add(new CodeSnippetStatement(
			$@"			using var w = new StringWriter();"
			));
			method.Statements.Add(new CodeSnippetStatement(
			$@"			serializer.Serialize(w, value);"
			));
			method.Statements.Add(new CodeSnippetStatement(
			$@"			return w.ToString();"
			));

			targetClass.Members.Add(method);
		}


		static void AddLocalFields(CodeTypeDeclaration targetClass)
		{
			CodeMemberField clientField = new CodeMemberField
			{
				Attributes = MemberAttributes.Private,
				Name = "call",
				Type = new CodeTypeReference("Func<HttpRequestMessage, CancellationToken, Task<string>>")
			};
			targetClass.Members.Add(clientField);

			CodeMemberField jsonSerializerField = new CodeMemberField
			{
				Attributes = MemberAttributes.Private,
				Name = "jsonSerializer",
				Type = new CodeTypeReference("JsonSerializer")
			};
			targetClass.Members.Add(jsonSerializerField);
		}

		void AddConstructorWithHttpClient(CodeTypeDeclaration targetClass)
		{
			CodeConstructor constructor = new CodeConstructor
			{
				Attributes =
				MemberAttributes.Public | MemberAttributes.Final
			};

			// Add parameters.
			constructor.Parameters.Add(new CodeParameterDeclarationExpression(
				"Func<HttpRequestMessage,CancellationToken, Task<string>>", "call"));

			constructor.Parameters.Add(new CodeParameterDeclarationExpression(
				"JsonSerializerSettings", "jsonSerializerSettings=null"));

			// Add field initialization logic
			sharedContext.ClientReference = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "call");
			constructor.Statements.Add(new CodeAssignStatement(sharedContext.ClientReference, new CodeArgumentReferenceExpression("call")));

			sharedContext.JsonSerializerReference = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "jsonSerializer");
			CodeMethodInvokeExpression methodInvoke = new CodeMethodInvokeExpression(
				// targetObject that contains the method to invoke.
				new CodeTypeReferenceExpression(new CodeTypeReference("JsonSerializer")),
				// methodName indicates the method to invoke.
				"Create",
				// parameters array contains the parameters for the method.
				new CodeExpression[] { new CodeArgumentReferenceExpression("jsonSerializerSettings") });
			constructor.Statements.Add(new CodeAssignStatement(sharedContext.JsonSerializerReference, methodInvoke));

			targetClass.Members.Add(constructor);
		}

		void CreateDummyOfEnsureSuccessStatusCodeEx()
		{
			codeCompileUnit.Namespaces.Add(new CodeNamespace("EnsureSuccessStatusCodeExDummy"));
		}

		const string blockOfEnsureSuccessStatusCodeEx =
		@"

namespace Fonlow.Net.Http
{
	using System.Net.Http;

	public class WebApiRequestException : HttpRequestException
	{
		public System.Net.HttpStatusCode StatusCode { get; private set; }

		public string Response { get; private set; }

		public System.Net.Http.Headers.HttpResponseHeaders Headers { get; private set; }

		public System.Net.Http.Headers.MediaTypeHeaderValue ContentType { get; private set; }

		public WebApiRequestException(string message, System.Net.HttpStatusCode statusCode, string response, System.Net.Http.Headers.HttpResponseHeaders headers, System.Net.Http.Headers.MediaTypeHeaderValue contentType) : base(message)
		{
			StatusCode = statusCode;
			Response = response;
			Headers = headers;
			ContentType = contentType;
		}
	}

	public static class ResponseMessageExtensions
	{
		public static void EnsureSuccessStatusCodeEx(this HttpResponseMessage responseMessage)
		{
			if (!responseMessage.IsSuccessStatusCode)
			{
				var responseText = responseMessage.Content.ReadAsStringAsync().Result;
				var contentType = responseMessage.Content.Headers.ContentType;
				throw new WebApiRequestException(responseMessage.ReasonPhrase, responseMessage.StatusCode, responseText, responseMessage.Headers, contentType);
			}
		}
	}
}";
		const string dummyBlock =
			@"
namespace EnsureSuccessStatusCodeExDummy
{
	
}";
	}


}
