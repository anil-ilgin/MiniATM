### How to Run the Solution?

- Open the terminal and navigate to the directory where the solution is located.
- Navigate to ATM.client folder and run the following:
```
npm install
```
- After installing required npm packages, navigate to ATM.Server folder and run the following command to execute the solution:
```
dotnet restore
```
-After restoring the packages, run the following command to build and run the solution:
```
dotnet run
```
After a quick build, the solution will run and you will see the output in the terminal:

```
Using launch settings from C:\Users\anilutku\source\repos\EnalyzerTask\ATM\ATM.Server\Properties\launchSettings.json...
Building...
warn: Microsoft.AspNetCore.StaticFiles.StaticFileMiddleware[16]
      The WebRootPath was not found: C:\Users\anilutku\source\repos\EnalyzerTask\ATM\ATM.Server\wwwroot. Static files may be unavailable.
warn: Microsoft.AspNetCore.StaticFiles.StaticFileMiddleware[16]
      The WebRootPath was not found: C:\Users\anilutku\source\repos\EnalyzerTask\ATM\ATM.Server\wwwroot. Static files may be unavailable.
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5270
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7184
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\Users\anilutku\source\repos\EnalyzerTask\ATM\ATM.Server
```

- And finally a new terminal window will open with the following URL:
```
  VITE v6.2.5  ready in 243 ms

  ➜  Local:   https://localhost:50415/
  ➜  Network: use --host to expose
  ➜  press h + enter to show help
 ```
- You can now open the URL in your browser to test the ATM.
