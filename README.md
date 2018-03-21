# webCRM ERP Integrations

## Prerequisites

* .NET Core SDK v2.x.
* Node.js. Don't install the latest 9.x branch. 8.10.0 is fine.
* `npm install --global azure-functions-core-tools@core`. Remember the `@core` modifier to get the latest .NET Core version of the tools. They are still in beta.
* Visual Studio Code is recommended.

## Building

    dotnet build
    dotnet build --configuration Release

## Generate webCRM SDK

Update the webCRM SDK, `WebcrmConnector/WebcrmSdk.cs`. The command is ignored if the OS isn't Windows.

    dotnet build --configuration GenerateWebcrmSdk

## Hosting Locally

Start a local Functions App host with the following command in the folder `/Api/bin/Debug/netstandard2.0`.

    func host start

## Running the Tests

Build the project first, start the local host server, and run the following command. You don't need to rebuild betwen  making changes to the test code.

    dotnet test Api.Test

## Publish From the Command Line

Run the following command in the folder `/Api/bin/Release/netstandard2.0`.

    func azure functionapp publish erp-integrations

## Publish From Visual Studio

In Visual Studio Code: F1 > Run Task > Publish to Azure.

In Visual Studio: Right click on Api project and selelect 'Publish...'.
