using SwagTests;
using Xunit;
using Xunit.Abstractions;

namespace NG2Tests
{
	[Collection("NGBuildInSequence")]
	public class OpenapiDirectoryGoogleTests
	{
		readonly TsTestHelper helper;
		public OpenapiDirectoryGoogleTests(ITestOutputHelper output)
		{
			helper = new TsTestHelper(output);
		}

		[Fact]
		public void Test_driveactivity()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\driveactivity\v2");
		}

		[Fact]
		public void Test_drive()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\drive\v3");
		}

		[Fact]
		public void Test_doubleclicksearch()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\doubleclicksearch\v2");
		}

		[Fact]
		public void Test_doubleclickbidmanager()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\doubleclickbidmanager\v1");
		}

		[Fact]
		public void Test_domainsrdap()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\domainsrdap\v1");
		}

		[Fact]
		public void Test_docs()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\docs\v1");
		}

		[Fact]
		public void Test_dns()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\dns\v2beta1");
		}

		[Fact]
		public void Test_dlp()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\dlp\v2");
		}

		[Fact]
		public void Test_discovery()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\discovery\v1");
		}

		[Fact]
		public void Test_digitalassetlinks()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\digitalassetlinks\v1");
		}

		[Fact]
		public void Test_dfareporting()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\dfareporting\v3.3");
		}

		[Fact]
		public void Test_deploymentmanager()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\deploymentmanager\v2");
		}

		[Fact]
		public void Test_datastore()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\datastore\v1");
		}

		[Fact]
		public void Test_dataproc()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\dataproc\v1");
		}

		[Fact]
		public void Test_datafusion()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\datafusion\v1beta1");
		}

		[Fact]
		public void Test_dataflow()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\dataflow\v1b3");
		}

		[Fact]
		public void Test_customsearch()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\customsearch\v1");
		}

		[Fact]
		public void Test_content()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\content\v2");
		}

		[Fact]
		public void Test_containeranalysis()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\containeranalysis\v1beta1");
		}

		[Fact]
		public void Test_container()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\container\v1");
		}

		[Fact]
		public void Test_compute()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\compute\v1");
		}

		[Fact]
		public void Test_composer()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\composer\v1");
		}

		[Fact]
		public void Test_commentanalyzer()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\commentanalyzer\v1alpha1");
		}

		[Fact]
		public void Test_cloudtrace()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\cloudtrace\v2");
		}

		[Fact]
		public void Test_cloudtasks()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\cloudtasks\v2");
		}

		[Fact]
		public void Test_cloudshell()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\cloudshell\v1");
		}

		[Fact]
		public void Test_cloudsearch()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\cloudsearch\v1");
		}

		[Fact]
		public void Test_cloudscheduler()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\cloudscheduler\v1");
		}

		[Fact]
		public void Test_cloudresourcemanager()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\cloudresourcemanager\v2");
		}

		[Fact]
		public void Test_cloudprofiler()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\cloudprofiler\v2");
		}

		[Fact]
		public void Test_cloudprivatecatalogproducer()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\cloudprivatecatalogproducer\v1beta1");
		}

		[Fact]
		public void Test_cloudprivatecatalog()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\cloudprivatecatalog\v1beta1");
		}

		[Fact]
		public void Test_cloudkms()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\cloudkms\v1");
		}

		[Fact]
		public void Test_cloudiot()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\cloudiot\v1");
		}

		[Fact]
		public void Test_cloudidentity()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\cloudidentity\v1");
		}

		[Fact]
		public void Test_cloudfunctions()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\cloudfunctions\v1");
		}

		[Fact]
		public void Test_clouderrorreporting()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\clouderrorreporting\v1beta1");
		}

		[Fact]
		public void Test_clouddebugger()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\clouddebugger\v2");
		}

		[Fact]
		public void Test_cloudbuild()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\cloudbuild\v1");
		}

		[Fact]
		public void Test_cloudbilling()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\cloudbilling\v1");
		}

		[Fact]
		public void Test_cloudasset()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\cloudasset\v1");
		}

		[Fact]
		public void Test_classroom()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\classroom\v1");
		}

		[Fact]
		public void Test_civicinfo()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\civicinfo\v2");
		}

		[Fact]
		public void Test_chat()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\chat\v1");
		}

		[Fact]
		public void Test_calendar()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\calendar\v3");
		}

		[Fact]
		public void Test_books()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\books\v1");
		}

		[Fact]
		public void Test_blogger()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\blogger\v3");
		}

		[Fact]
		public void Test_binaryauthorization()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\binaryauthorization\v1");
		}

		[Fact]
		public void Test_bigtableadmin()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\bigtableadmin\v2");
		}

		[Fact]
		public void Test_bigqueryreservation()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\bigqueryreservation\v1");
		}

		[Fact]
		public void Test_bigquerydatatransfer()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\bigquerydatatransfer\v1");
		}

		[Fact]
		public void Test_bigqueryconnection()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\bigqueryconnection\v1beta1");
		}

		[Fact]
		public void Test_bigquery()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\bigquery\v2");
		}

		[Fact]
		public void Test_automl()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\automl\v1beta1");
		}

		[Fact]
		public void Test_appsactivity()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\appsactivity\v1");
		}

		[Fact]
		public void Test_appengine()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\appengine\v1");
		}

		[Fact]
		public void Test_androidpublisher()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\androidpublisher\v3");
		}

		[Fact]
		public void Test_androidmanagement()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\androidmanagement\v1");
		}

		[Fact]
		public void Test_androidenterprise()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\androidenterprise\v1");
		}

		[Fact]
		public void Test_androiddeviceprovisioning()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\androiddeviceprovisioning\v1");
		}

		[Fact]
		public void Test_analyticsreporting()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\analyticsreporting\v4");
		}

		[Fact]
		public void Test_analytics()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\analytics\v3");
		}

		[Fact]
		public void Test_alertcenter()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\alertcenter\v1beta1");
		}

		[Fact]
		public void Test_adsensehost()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\adsensehost\v4.1");
		}

		[Fact]
		public void Test_adsense()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\adsense\v1.4");
		}

		[Fact]
		public void Test_adminreports_v1()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\admin\reports_v1");
		}

		[Fact]
		public void Test_admindatatransfer_v1()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\admin\datatransfer_v1");
		}

		[Fact]
		public void Test_adexperiencereport()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\adexperiencereport\v1");
		}

		[Fact]
		public void Test_adexchangebuyer()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\adexchangebuyer\v1.4");
		}

		[Fact]
		public void Test_accesscontextmanager()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\accesscontextmanager\v1");
		}

		[Fact]
		public void Test_accessapproval()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\accessapproval\v1beta1");
		}

		[Fact]
		public void Test_acceleratedmobilepageurl()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\acceleratedmobilepageurl\v1");
		}

		[Fact]
		public void Test_abusiveexperiencereport()
		{
			helper.GenerateFromOpenApiAndBuild(@"C:\VSProjects\Study\openapi-directory\APIs\googleapis.com\abusiveexperiencereport\v1");
		}

	}
}