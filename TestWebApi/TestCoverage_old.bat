"%~dp0..\packages\OpenCover.4.5.3723\OpenCover.Console.exe" ^
-register:user ^
-target:"%VS120COMNTOOLS%\..\IDE\mstest.exe" ^
-targetargs:"/testcontainer:\"%~dp0..\BowlingSPAService.Tests\bin\Debug\BowlingSPAService.Tests.dll\" /resultsfile:\"%~dp0BowlingSPAService.trx\"" ^
-filter:"+[BowlingSPAService*]* -[BowlingSPAService.Tests]* -[*]BowlingSPAService.RouteConfig" ^
-mergebyhash ^
-skipautoprops ^
-output:"%~dp0\GeneratedReports\BowlingSPAServiceReport.xml"



"..\..\..\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe" -target:"..\..\..\packages\NUnit.ConsoleRunner.3.11.0\tools\nunit3-console.exe" -targetargs:"NAME_OF_TEST_PROJECT.dll" -filter:"+[NAME_OF_PROJECT]NAME_OF_PROJECT*" -excludebyattribute:"System.CodeDom.Compiler.GeneratedCodeAttribute" -register:user -output:"_CodeCoverageResult.xml"
@pause

"..\..\..\packages\ReportGenerator.2.4.5.0\tools\ReportGenerator.exe" "-reports:_CodeCoverageResult.xml" "-targetdir:_CodeCoverageReport";
@pause

:RunLaunchReport
start "report&quot; &quot;_CodeCoverageReport\index.htm";
exit /b %errorlevel%