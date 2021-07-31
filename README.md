# Weelo

# Create Database
dotnet ef migrations add Initial -c WeeloDbContext -p ..\Infraestructure\ -s .\Api.csproj -o Data/Migrations -v
dotnet ef database update -c WeeloDbContext -p ..\Infraestructure\ -s .\Api.csproj -v
