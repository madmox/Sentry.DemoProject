Test repo to replicate Sentry [IncludeRequestPayload bug](https://github.com/getsentry/sentry-dotnet/issues/175).

Steps to reproduce:
* Open the solution in Visual Studio 2017.
* Fill in your DSN in the file `src/Sentry.DemoProject.Web/appsettings.json`.
* Hit 'F5'.
* From PostMan (or equivalent), send an HTTP POST request to `/api/test` with a ZIP file as raw binary content.
  * You might wanna disable SSL certificate validation in PostMan.
