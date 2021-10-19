### Building
In Visual Studio: Select Build from drop down at the top and click on Build
Powershell: cd to directory with solution, then run 
	> dotnet build --configuration Debug

Or to run with release config:
	> dotnet build --configuration Release

### Run the program
MUST BUILD FIRST 
In Powershell:
cd to Tfl.Console\bin\Debug\netcoreapp3.1 [If build with Debug config]

Or
cd to Tfl.Console\bin\Release\netcoreapp3.1 [If build with Release config]

Then run:
 > .\Tfl.Console [Road]
 e.g.
 > .\Tfl.Console A10


### Running tests
In Visual 

### Assumptions
- A 200 response from the api will be a list containing only one entity
- Only one argument is allowed to be provided to console app
- Its ok for the user to just run the exe from a build directory