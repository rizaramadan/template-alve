To add new migration:
1. `cd ..` from this location
2. execute command `dotnet ef migrations add "init" --project Infrastructures --startup-project Web --output-dir Persistence\Migrations`

To update database:
1. `cd ..` from this location
2. execute command `dotnet ef database update --project Infrastructures --startup-project Web`
