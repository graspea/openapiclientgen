﻿using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Fonlow.OpenApiClientGen
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Fonlow.OpenApiClientGen.exe generates C# and TypeScript client codes according to an Open API YAML/JSON file.");
			if (args.Length == 0)
			{
				ShowHelp();
				Console.WriteLine("Warning: Need yaml/json path and settings path.");
				return;
			}

			if (args.Length == 1)
			{
				ShowHelp();
				Console.WriteLine("Warning: Need settings path.");
				return;
			}


			var dir = Environment.GetEnvironmentVariable("dir");
			if(Directory.Exists(dir)) Directory.SetCurrentDirectory(dir);
			Console.WriteLine($"Current directory: {Directory.GetCurrentDirectory()}");

			
			string defFile = args[0];
			if (!File.Exists(defFile))
			{
				Console.WriteLine($"{defFile} not exist.");
				return;
			}

			string settingsFile = args[1];
			if (!File.Exists(settingsFile))
			{
				Console.WriteLine($"{settingsFile} not exist.");
				return;
			}

			IConfigurationRoot configuration = new ConfigurationBuilder()
					.AddJsonFile("appsettings.json", false, true)
					.Build();

			ILogger logger;

			using (ServiceProvider serviceProvider = new ServiceCollection()
				.AddLogging(cfg =>
				{
					cfg.AddConfiguration(configuration.GetSection("Logging"));
					cfg.AddConsole();
				})
				.BuildServiceProvider())
			{
				logger = serviceProvider.GetService<ILogger<Program>>();
			}

			logger.LogInformation("Program logger loaded");

			using Diagnostics.LoggerTraceListener listener = new Fonlow.Diagnostics.LoggerTraceListener(logger);
			System.Diagnostics.Trace.Listeners.Add(listener);

			string settingsString = File.ReadAllText(settingsFile);
			ClientTypes.Settings settings = System.Text.Json.JsonSerializer.Deserialize<ClientTypes.Settings>(settingsString);

			OpenApiDocument doc;
			using (FileStream stream = new FileStream(defFile, FileMode.Open, FileAccess.Read))
			{
				doc = new OpenApiStreamReader().Read(stream, out OpenApiDiagnostic diagnostic);
			}

			Console.WriteLine("Processing...");
			Trace.TraceInformation(doc.Info.FormatOpenApiInfo());

			Fonlow.CodeDom.Web.CodeGen.GenerateClientAPIs(settings, doc.Paths, doc.Components, Directory.GetCurrentDirectory());

			Console.WriteLine("Done");
		}

		static void ShowHelp()
		{
			Console.WriteLine(@"
Parameter 1: Open API YAML/JSON definition file
Parameter 2: Settings file in JSON format.
Example:  
  Fonlow.OpenApiClientGen.exe my.yaml
  Fonlow.OpenApiClientGen.exe my.yaml myproj.json
  Fonlow.OpenApiClientGen.exe my.yaml ..\myproj.json

");
		}

	}

	public static class OpenApiDocExtentions
	{
		public static string FormatOpenApiInfo(this OpenApiInfo info)
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine(info.Title);
			builder.AppendLine("V " + info.Version);
			builder.AppendLine(info.Description);
			return builder.ToString();
		}

	}
}
