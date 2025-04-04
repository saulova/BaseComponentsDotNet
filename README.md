# BaseComponentsDotNet

This repository contains Base Components (SeedWork) for .NET.

## Requirements

- .NET SDK 9.0.2 or later
- VSCode
- Docker
- VSCode Docker Extension
- VSCode DevContainers Extension

## Installation

1. Clone this repository:
   ```sh
   git clone https://github.com/saulova/BaseComponentsDotNet.git
   ```
2. Navigate to the project directory:
   ```sh
   cd BaseComponentsDotNet
   ```
3. Restore NuGet packages:
   ```sh
   dotnet restore
   ```

## Running the Examples

Each project in this repository is an independent example and can be executed separately.

### RequestHandlersExample.API

This project demonstrates the use of request handlers to process commands using mediator pattern.

```sh
dotnet run --project src/Examples/RequestHandlersExample.API/RequestHandlersExample.API.csproj
```

### EventHandlersExample.API

This project illustrates the use of event handlers to handle events within the application using mediator pattern.

```sh
dotnet run --project src/Examples/EventHandlersExample.API/EventHandlersExample.API.csproj
```

### PipelineExample.API

Demonstrates a pipeline processing using mediator pattern.

```sh
dotnet run --project src/Examples/PipelineExample.API/PipelineExample.API.csproj
```

## License

This project is licensed under the MIT License. See the `LICENSE` file for more details.
