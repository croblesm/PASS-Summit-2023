# PASS-Summit-2023
Repository for PASS Summit 2023 session

## Prerequisites

- [Create a workspaces environment (Optional)](https://github.com/features/codespaces)
- [Install Go-SqlCmd (Optional)](https://learn.microsoft.com/en-us/sql/tools/sqlcmd/sqlcmd-utility?view=sql-server-ver16&tabs=go%2Clinux&pivots=cs1-bash#tabpanel_2_go)
- [Install .NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [Install SQL Database Projects - VSCode or ADS extension](https://marketplace.visualstudio.com/items?itemName=ms-mssql.sql-database-projects-vscode)

Here you have the instructions to install the prerequisites in Ubuntu 20.04 with GitHub Codespaces:

## Installation
### 1. Install Go-SqlCmd (Optional) - Ubuntu 20.04


```bash
curl https://packages.microsoft.com/keys/microsoft.asc | sudo tee /etc/apt/trusted.gpg.d/microsoft.asc
sudo add-apt-repository "$(wget -qO- https://packages.microsoft.com/config/ubuntu/20.04/prod.list)"
sudo apt-get update
sudo  apt-get install sqlcmd
```

### 2. Install .NET 6.0 - Ubuntu 20.04

```bash
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
chmod +x ./dotnet-install.sh
./dotnet-install.sh --version latest
./dotnet-install.sh --version latest --runtime aspnetcore
dotnet --list-sdks
```

## Build App (Azure SQL bindings for Azure Functions)

### Create a SQL Server Container

```bash
# Create SQL Database from a backup
sqlcmd create mssql --accept-eula

# Get connection string
sqlcmd config connection-strings

# Export sqlcmd password env variable
export 'SQLCMDPASSWORD=<Password>';

# Deploy database scripts using your favorite tool
```

### Create Azure Function

Azure Functions supports input bindings, output bindings, and a function trigger for the Azure SQL and SQL Server products.

- [C#](https://learn.microsoft.com/en-us/azure/azure-functions/functions-bindings-azure-sql?tabs=isolated-process%2Cextensionv4&pivots=programming-language-csharp)
- [Java](https://learn.microsoft.com/en-us/azure/azure-functions/functions-bindings-azure-sql?tabs=isolated-process%2Cextensionv4&pivots=programming-language-java)
- [JavaScript](https://learn.microsoft.com/en-us/azure/azure-functions/functions-bindings-azure-sql?tabs=isolated-process%2Cextensionv4&pivots=programming-language-javascript)
- [PowerShell](https://learn.microsoft.com/en-us/azure/azure-functions/functions-bindings-azure-sql?tabs=isolated-process%2Cextensionv4&pivots=programming-language-powershell)
- [Python](https://learn.microsoft.com/en-us/azure/azure-functions/functions-bindings-azure-sql?tabs=isolated-process%2Cextensionv4&pivots=programming-language-python)

## Learn More

- [aka.ms/azuredatastudio-sqlprojects](https://aka.ms/azuredatastudio-sqlprojects)
- [aka.ms/dac-eff-what](http://aka.ms/dac-eff-what)
- [aka.ms/azuredbemulator](https://aka.ms/azuredbemulator)
- [aka.ms/go-sqlcmd-qs](http://aka.ms/go-sqlcmd-qs)
- [aka.ms/dab](http://aka.ms/dab)
- [aka.ms/sqlbindings](https://aka.ms/sqlbindings)
- [aka.ms/sql-action](https://github.com/azure/sql-action)