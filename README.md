Test repo to replicate Sentry [IncludeRequestPayload bug](https://github.com/getsentry/sentry-dotnet/issues/175).

Steps to reproduce:
* Fill in your DSN in the file `src/Sentry.DemoProject.Web/appsettings.json`.
* Hit 'F5' from Visual Studio 2017.
* From PostMan (or equivalent), send an HTTP POST request to `/api/test` with a ZIP file as raw binary content.
** You might wanna disable SSL certificate validation in PostMan.

```
POST https://localhost:44378/api/test HTTP/1.1
Host: localhost:44378
Accept: */*
Content-Type: application/octet-stream
Content-Length: 5574077

<raw ZIP file>
```