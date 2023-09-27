# Projeto StockQuoteAlertApp <!-- omit in toc -->

O StockQuoteAlertApp trata-se de um sistema de serviço de monitoramento que verifica os preços dos ativos usando uma API Alpha Vantage via SignalR sobre mudanças de preços com notificação a usuários por e-mail.

* Data: 27/09/2023
* Versão atual: 1.0 

## 1. Pré-Requisitos

### 1.1. Para desenvolvimento

* Windows 10 ou 11.
* [Visual Studio na última versão](https://visualstudio.microsoft.com/pt-br/downloads/)
* C# v. 10.0 (Obtido diretamente da IDE)
* .NET v. 7.0 (Obtido diretamente da IDE)

### 1.2. Somente para compilar e executar

* Em Sistema Operacional Windows
  * [C# v. 10.0](https://dotnet.microsoft.com/pt-br/download) - Distribuição: Microsoft
  * [.NET v. 7.0](https://dotnet.microsoft.com/pt-br/downloadi) - Distribuição: Microsoft

## 2. Instruções de construção, execução e uso da API

Antes de executar certifique-se de que a chave da API do Alpha Vantage possui uma chave sem limite de chamadas excedido.

O projeto pode ser executado em modo de produção ou modo de depuração diretamente através da IDE. Você também pode construir e executar o projeto pelo terminal:

Restaure os pacotes NuGet:

```
dotnet restore

```

Construa o projeto:

```
dotnet build

```
Execute o projeto:

```
dotnet run
```

# 4. Estrutura do repositório

O repositório é estruturado da seguinte forma:

* `/StockQuoteAlertApp/`
    * `/Configuration/`
        * `EmailSettings.cs`
    * `/DTO/`
        * `ApiResponseDTO.cs`
        * `MetaDataDTO.cs`
        * `TimeSeriesEntry.cs`
    * `/Exception/`
        * `AssetException.cs`
    * `/Hubs/`
        * `MonitoringHub.cs`
    * `/Models/`
        * `Asset.cs`
    * `/Pages/`
        * `_Host.cshtml`
        * `Error.cshtml`
        * `Index.razor`
    * `/Services/`
        * `MonitoringService.cs`
    * `/Shared/`
        * `MainLayout.razor`
        * `NavMenu.razor`
        * `SurveyPrompt.razor`
    * `_Imports.razor`
    * `App.razor`
    * `appsettings.json`
    * `Program.cs`
