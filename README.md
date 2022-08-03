# CatsAndDogsAPI 🐱🐶
This is a project integrating both the cats and dogs api. Swagger UI is also used to test the API Endpoints

## Swagger UI Overview
<img src="https://user-images.githubusercontent.com/52302432/182620783-39d9e25f-81d4-413d-a3bc-e5bd97eb0f8d.png" alt="Swagger Overview" />

## Project Requirements
- Visual Code 2022
- .Net 6 (Pre installed in VS 2022)
- Microsoft ASP.Net Core
- Microsoft .NetCore

## Nuget Dependencies
### CatsAndDogs.Api (API Layer)
- <a href="https://www.nuget.org/packages/AutoMapper.Extensions.Microsoft.DependencyInjection/11.0.0/">AutoMapper</a> [AutoMapper.Extensions.Microsoft.DependencyInjection] (v11.0.0)
- <a href="https://www.nuget.org/packages/AutoMapper.Extensions.Microsoft.DependencyInjection/11.0.0/">MS WebApi.Core</a> [Microsoft.AspNet.WebApi.Core] (v5.2.9)
- <a href="https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Binder/6.0.0/">MS Configuration Binder</a> [Microsoft.Extensions.Configuration.Binder] (v6.0.0)
- <a href="https://www.nuget.org/packages/Swashbuckle.AspNetCore/6.4.0/">Swashbuckle</a> [Swashbuckle.AspNetCore] (v6.4.0)

### CatsAndDogs.Business (Business Layer)
- <a href="https://www.nuget.org/packages/AutoMapper.Extensions.Microsoft.DependencyInjection/11.0.0/">AutoMapper</a> [AutoMapper.Extensions.Microsoft.DependencyInjection] (v11.0.0)

### CatsAndDogs.Tests
- <a href="https://www.nuget.org/packages/coverlet.collector/3.1.2/">Coverlet</a> [coverlet.collector] (v3.1.2)
- <a href="https://www.nuget.org/packages/FluentAssertions/6.7.0/">FluentAssertions</a> [FluentAssertions] (v6.7.0)
- <a href="https://www.nuget.org/packages/Microsoft.AspNetCore.TestHost/6.0.7/">MS Core TestHost</a> [Microsoft.AspNetCore.TestHost] (v6.0.7)
- <a href="https://www.nuget.org/packages/Moq/4.18.1/">Moq</a> [Moq] (v4.18.1)
- <a href="https://www.nuget.org/packages/xunit/2.4.1/">XUnit</a> [xunit] (v2.4.1)
- <a href="https://www.nuget.org/packages/xunit.runner.visualstudio/2.4.3/">XUnit Runner</a> [xunit.runner.visualstudio] (v2.4.3)

### Integration.Cats 🐱 (<a href="https://thecatapi.com/">Meow!</a>)
- <a href="https://www.nuget.org/packages/Microsoft.Extensions.Options/6.0.0/">MS Options</a> [Microsoft.Extensions.Options] (v6.0.0)
- <a href="https://www.nuget.org/packages/Newtonsoft.Json/13.0.1/">Newtonsoft.Json</a> [Newtonsoft.Json] (v.13.0.1)

### Integration.Dogs 🐶(<a href="https://thedogapi.com/">Woof!</a>)
- <a href="https://www.nuget.org/packages/Microsoft.Extensions.Options/6.0.0/">MS Options</a> [Microsoft.Extensions.Options] (v6.0.0)
- <a href="https://www.nuget.org/packages/Newtonsoft.Json/13.0.1/">Newtonsoft.Json</a> [Newtonsoft.Json] (v.13.0.1)

## Setting up the App
There is not much that you need to do when setting up the up. Well here are the things that you need to do:
- Register a new account in <a href="https://thecatapi.com/">The Cat API</a>
- Register a new account as well in <a href="https://thedogapi.com/">The Dog API</a>
- After receiving the secret API keys,

## Setting up and running the App
<ol>
  <li>Clone the project to your local machine using git <code>git clone https://github.com/kent-decrypt/CatsAndDogsAPI.git</code></li>
  <li>Register a new account in <a href="https://thecatapi.com/">The Cat API</a></li>
  <li>Register a new account as well in <a href="https://thedogapi.com/">The Dog API</a><//li>
  <li>Open Visual Studio 2022 and click on "Open a Project or Solution"</li>
  <li>When a popup appears, go to the folder where you cloned the repository</li>
  <li>Double click on the .sln file</li>
  <li>Under the CatsAndDogs.Api project, open the appsettings.json and make sure to modify the following settings
  <img src="https://user-images.githubusercontent.com/52302432/182614021-087c61e4-438c-4dac-825c-384af472c3a6.png" alt="AppSettings.json" />
  </li>
  <li>Make sure that the default project is CatsAndDogs.Api</li>
  <li>Press F5 or the Play button to run the Project</li>
</ol>

## Installing dependencies on the project
<b>Note</b>: If you're going to install the packages using Visual Studio's Nuget Package Manager, you can check this link as a reference. <a href="https://docs.microsoft.com/en-us/nuget/consume-packages/install-use-packages-visual-studio">Install and manage NuGet Packages</a>
### Install packages via Package Manager Console 👇
<ol>
  <li>On the Visual Studio Application, click on the View Tab</li>
  <li>Hover on the <b>Other Windows</b> and click on <b>Package Manager Console</b></li>
  <li>Package Manager Console will appear on the bottom screen by default and make sure that the selected Default Project is CatsAndDogs.Api
  <img src="https://user-images.githubusercontent.com/52302432/182615078-0286924f-4031-478d-b3d7-85794fe14343.png" alt="Package Manager Console" /></li>
  <li>You can run the following scripts below (you can copy paste it 😉):
    <ul>
      <li><code>Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection -ProjectName CatsAndDogs.Api -Version 11.0.0</code></li>
      <li><code>Install-Package Microsoft.AspNet.WebApi.Core -ProjectName CatsAndDogs.Api -Version 5.2.9</code></li>
      <li><code>Install-Package Microsoft.Extensions.Configuration.Binder -ProjectName CatsAndDogs.Api -Version 6.0.0</code></li>
      <li><code>Install-Package Swashbuckle.AspNetCore -ProjectName CatsAndDogs.Api -Version 6.4.0</code></li>
      <li><code>Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection -ProjectName CatsAndDogs.Business -Version 11.0.0</code></li>
      <li><code>Install-Package coverlet.collector -ProjectName Tests.CatsAndDogs -Version 3.1.2</code></li>
      <li><code>Install-Package FluentAssertions -ProjectName Tests.CatsAndDogs -Version 6.7.0</code></li>
      <li><code>Install-Package Microsoft.AspNetCore.TestHost -ProjectName Tests.CatsAndDogs -Version 6.0.7</code></li>
      <li><code>Install-Package Moq -ProjectName Tests.CatsAndDogs -Version 4.18.1</code></li>
      <li><code>Install-Package xunit -ProjectName Tests.CatsAndDogs -Version 2.4.1</code></li>
      <li><code>Install-Package xunit.runner.visualstudio -ProjectName Tests.CatsAndDogs -Version 2.4.3</code></li>
      <li><code>Install-Package Microsoft.Extensions.Options -ProjectName Integration.Cats.Api -Version 6.0.0</code></li>
      <li><code>Install-Package Newtonsoft.Json -ProjectName Integration.Cats.Api -Version 13.0.1</code></li>
      <li><code>Install-Package Microsoft.Extensions.Options -ProjectName Integration.Dogs.Api -Version 6.0.0</code></li>
      <li><code>Install-Package Newtonsoft.Json -ProjectName Integration.Dogs.Api -Version 13.0.1</code></li>
    </ul>
  </li>
</ol>

## Using the Unit Test by CLI
You can follow the steps below for running the Unit Tests
<ol>
  <li>Open the Developer Power Shell. View Tab > Terminal. Or you can press <code>CTRL + `</code> from your keyboard</li>
  <li>Check if you're in the directory of the CatsAndDogs.Tests, if not, you can use the following code <code>cd CatsAndDogs.Test</code></li>
  <li>After verifying the directory that you're in, type in <code>dotnet test Tests.CatsAndDogs.csproj</code>
  <img src="https://user-images.githubusercontent.com/52302432/182625671-728e64c6-7431-4c3a-aef0-4738348b03d6.png" alt="Unit Testing" /></li>
  <li>And you're done! You have executed the Unit Tests by using the CLI!
  <img src="https://user-images.githubusercontent.com/52302432/182625853-3fa8175a-cf94-4e80-a736-aeb3d49757ed.png" alt="Unit Testing Complete" />
</li>
</ol>

## Comments / Suggestions / Bugs
Let me know for any questions, bugs, or any suggestions by filing an issue in this repository (Just no hate comments please 😉).
