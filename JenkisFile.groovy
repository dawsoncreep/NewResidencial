pipeline
{
    agent any

    environment
    {
        //Functions
		DEPLOY_PATTERN = NewPatterName()

		// Paths to programas 
		MSNUGET_PATH = "C:\\Program Files (x86)\\NuGet\\NuGet.exe";
		MSBUILD_PATH = "C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Enterprise\\MSBuild\\15.0\\Bin\\MSBuild.exe";
		MSCODECOVERAGE_PATH = "C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Enterprise\\Team Tools\\Dynamic Code Coverage Tools\\CodeCoverage.exe";
		MSTESTRUNNER_PATH = "C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Enterprise\\Common7\\IDE\\CommonExtensions\\Microsoft\\TestWindow\\vstest.console.exe";
    }
	stages
    {
    }
     post 
    { 
        always
        {
            echo "Cleanup correctly!!!"            
        }
        success
        {
            echo "Pipieline done correctly!!!"
        }
        failure 
        {
            echo "Pipieline has failed!!!"
        }
    }
}

def NewPatterName()
{
	return "_" + new Date().format( 'ddMMyyyy' ) + "_" + "${env.BUILD_NUMBER}";
}

def UpdateAssemblyInformation()
{	
	String productInfo = "Nissan WMS Mobile";
	String copyright = "COPYRIGHT 2018 © NISSAN MEXICANA S.A. DE C.V. All rights reserved.";
	String productOwner = "NISSAN MEXICANA S.A. DE C.V.";
	String pattern = "-";

	// TODO: Find a better way of versioning assembly information
	// Untill that:
	// For master branch,  version patter is 3.1.3.BUILD_NUMBER
	// For release branch, version patter is 3.1.2.BUILD_NUMBER
	// For develop branch, version patter is 3.1.1.BUILD_NUMBER
	// For other branch,   version patter is 3.1.0.BUILD_NUMBER

	// Definition:
	// Mayor	= 3
	// Minor	= 1
	// branch	= 0 for features
	//			 ,1 for develop
	//			 ,2 for release
	//			 ,3 for master
	// Build	= Jenkins Build Number
	 
	if(env.BRANCH_NAME == 'master')
	{
		pattern = "Assembly\$1Version(\"3.1.3.%s\")";
	}
	else if (env.BRANCH_NAME.startsWith('release')) 
	{
		pattern = "Assembly\$1Version(\"3.1.2.%s\")";
	}
	else if (env.BRANCH_NAME == 'develop') 
	{
		pattern = "Assembly\$1Version(\"3.1.1.%s\")";
	}
	else
	{
		pattern = "Assembly\$1Version(\"3.1.0.%s\")";
	}

	changeAsmVer versionPattern: "${env.BUILD_NUMBER}", regexPattern: "Assembly(\\w*)Version\\(\"(\\d+).(\\d+).(\\d+).(\\d+)\"\\)", replacementPattern: pattern, assemblyCompany: productOwner, assemblyProduct: productInfo, assemblyCopyright: copyright
}