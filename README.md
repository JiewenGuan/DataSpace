# Australian Microgravity Database and Website

## Introduction
This repository (DataSpace) contains the configurations and applied schematics for the realisation of a database to store the details of microgravity experiments conducted by Australians or with Australian researchers as part of the research team, as well as the deployment of a web-based access to the content by the general public, and a mechanism for administrators of the database to manage the relevant database content.

## Architecture
This product has been developed using the ASP.NET Core framework, a cross-platform, high performance, open-source software development solution. It is predominantly written in C#, has been implemented with a Model-View-Controller design pattern inclusive of a locally hosted relational database for the storage of relevant data, and the presentation has been achieved with Razor Pages. This affords future developers an ease of modification of this Solution should the need arise, as well as the flexibility to deploy web APIs to reach other clients such as as a REST API which may be called by clients such as a mobile device app.

## Developer environment deployment instructions
Updated: 14 May 2020

### Preamble
There are a number of means of deploying this product for testing, evaluation and modification purposes. As such the instructions contained therein should be considered as a suggestion only, and if using different environments it may be neccessary to install additional packages. They are provided as a means of achieving various anticipated tasks with relative ease on a Windows 10 platform and are thus provided as is and are subject to modification without notice.

### Prerequisites
- Install [Visual Studio 2019 16.4](https://visualstudio.microsoft.com/downloads/) or later with the ASP.NET and web development workload.
   - Note: This project has been developed with Visual Studio 2019 16.4 and Visual Studio 2019 16.5. 
- Install [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1) or later.
   - Note: It is imperative that the version of .Net Core SDK installed supports the version of Visual Studio in your environment. For example at the time of writing, .Net Core v3.1.4 SDK 3.1.202 is required for Visual Studio 2019 (v16.5).
- To confirm the installation, open a new PowerShell or equivalent and run the following command: `dotnet`.
   - Note: You may need to install additional dependencies on older versions of Windows (pre Windows 10) or on other platforms.

### Instructions
1. With Visual Studio 2019, clone this repository using the menu options **File** > **Clone or Checkout a Repository**.
   - Note: you can also `$ git clone https://github.com/Waaaghtech/DataSpace.git` and open the Solution manually.
2. Before running the Solution, it is recommended to update the the database to latest migration. With the Solution open in Visual Studio 2019, this can be achieved by executing the `update-database` command in the PMC.
   - Note: the PMC (Package Manager Console) can be accessed from the menu option **Tools** > **NuGet Package Manager** > **Package Manager Console**.
3. If operating with the Google login configuration active (active by default) you will need to obtain the appropriate credentials. Alternatively the developers may be able to assist in acquiring these. 
   - Note: see [Facebook, Google, and external provider authentication in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/?view=aspnetcore-3.1&tabs=visual-studio) for more information.
4. As previously mentioned, the project is initialised by default to offer the login externally with Google which must be stored. Secret storage is activated for this project, so it is neccessary to to run the following dotnet commands in the PowerShell (or equivalent) in the project root folder, replacing `<client-id>` and `<client-secret>` with the requisite values.
   ```pwsh
   dotnet user-secrets set "Authentication:Google:ClientId" "<client-id>"
   dotnet user-secrets set "Authentication:Google:ClientSecret" "<client-secret>"
   ```
     - Note: to open a PowerShell in this folder, open a File Explorer in the root director and execute `powershell` in the navigation bar.
     - Note: more information about this process see [Store the Google client ID and secret](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/social/google-logins?view=aspnetcore-3.1#store-the-google-client-id-and-secret)
5. It is necessary to launch the solution on the appropriate port for the relevant Google client ID. There are two ways to achieve launch the solution on the correct port:
     - To temporarily deploy the localhost on a specified port, in a PowerShell in the root folder execute the following command replacing `<port>` with the appropriate port.
   ```
   dotnet run --urls=https://localhost:<port>/
   ```
     - For a more permanent debugging solution, you can set the port for debugging in Visual Studio code by setting the `Web Server Settings` on the bottom of the Debug window accessible from **Project** > **`<project-name>` Properties**. This only applies when launching from inside Visual Studio 2019.
     - Note: Failing to set the port correctly will not typically prevent the Solution from loading or an unpriveleged user from navigating the website, but credential validation with Google will not function.

You may encounter a certificate error when using https. This can be resolved by creating your own certificate, or when using Visual Studio 2019 by trusting and installing the IIS Express SSL certificate that it attempts to generate automatically. 
