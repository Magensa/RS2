# Introduction 

The Repository Contains Sample Applications For EMV, PPSCRAv2, SCRAV2 

 1. EMV Samples
    1. GetEMVCommands 
 2. PPSCRAv2 Samples
    1. GetCertLoad 
    2. GetCommandListByDevice
    3. GetDeviceAuthCommand
    4. GetEnableSREDCommand
    5. GetKeyList
    6. GetKeyLoadCommand
    7. GetLoadConfigCommand
    8. GetPreActivateCommand
3. SCRAv2 Samples
    1. GetCommandByKSN
    2. GetCommandByMUT
    3. GetCommandList
    4. GetFirmwareList
    5. GetKeyList
    6. GetFirmwareByMUT
    7. GetFirmwareCommands
    8. GetKeyLoadCommand
    
# Clone the repository
 1. Navigate to the main page of the  **repository**. 
 2. Under the  **repository**  name, click  **Clone** .
 3. Use any Git Client(eg.: GitBash, Git Hub for windows, Source tree ) to  **clone**  the  **repository**  using HTTPS.

Note: reference for  [Cloning a Github Repository](https://help.github.com/en/articles/cloning-a-repository)


# Getting Started

1.  Install .net core 3.1 LTS

    - Demo app requires dotnet core 3.1 LTS is installed

2.  Software dependencies( The Following nuget packages are automatically installed when we open and run the project), please recheck and add the references from nuget
 

     Microsoft.Extensions.DependencyInjection

     Microsoft.Extensions.Configuration

     Microsoft.Extensions.Configuration.EnvironmentVariables

     Microsoft.Extensions.Configuration.Json
     
     Microsoft.Extensions.Configuration.Binder

    
###Latest releases
- Initial release with all commits and changes as on Apr 14th 2020

# Build and Test

 Steps to Build and run project( .net core 3.1)

 From the cmd,  Navigate to the cloned folder and go to respective folder  Ex: For EMVSamples
    
 Run the following commands
    
 ```dotnet clean EMVSamples.sln```

 ```dotnet build EMVSamples.sln```

 Navigate from command prompt to EMV.DemoApp folder containing EMV.DemoApp.csproj and run below command

 ```dotnet run --project EMV.DemoApp.csproj```

 This should open the application running in console.

