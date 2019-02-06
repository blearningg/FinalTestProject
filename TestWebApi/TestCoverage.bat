"%~dp0..\packages\OpenCover.4.5.3723\OpenCover.Console.exe" ^
-register:user ^
-target:"%VS120COMNTOOLS%\..\IDE\mstest.exe" ^
-targetargs:"/testcontainer:\"%~dp0..\NunitApiTest\bin\Debug\NunitApiTest.dll\" /resultsfile:\"%~dp0TestCoverage.trx\"" ^
-filter:"+[TestWebApi*]* -[NunitApiTest]* -[*]TestWebApi.RouteConfig" ^
-mergebyhash ^
-skipautoprops ^
-output:"%~dp0\TestCoverageReport.xml"