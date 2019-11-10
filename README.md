Net Core 3 Example Application
==

### Includes
  * Net Core 3
  * Api Controllers
  * Entity Framework Core Code First
  * Serilog Logger with Console and Graylog sinks (configured from appsettings.json)

## Migrations

### Generate Migration

From root folder (folder with .sln file) run: `dotnet ef migrations add InitMigration --context MainContext --project WebApi.NetCore.Template.DAL --startup-project WebApi.NetCore.Template.Start`

### Update Database

`dotnet ef dbcontext info  --project WebApi.NetCore.Template.Start`

### Database Info

`dotnet ef database update --project WebApi.NetCore.Template.Start`
