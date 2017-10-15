# appLanche

.Net Core 2.0 - Entity Core in Memory

## Para rodar aplicacao em maquina local

Baixar o codigo 

>git clone https://github.com/imitsuo/appLanche.git

É necessário instalar .Net Core 2.0 

## Para executar App Web

Acessar a pasta /Web

### Executar
>dotnet restore

>dotnet run

### Modo Debug

Windows

>set ASPNETCORE_ENVIRONMENT=Development

Linux

>export ASPNETCORE_ENVIRONMENT=Development

## Executar Testes Unitarios

Acessar a pasta /Tests

### Executar
>dotnet restore

>dotnet test
