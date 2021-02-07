# Programming Languages

The solutions in this repository are written in either Python 3.6 or C# 8.0. The first 2 solutions are in Python while the latter 2 in C#.

The python solutions do not use any framework however the C# ones use ASP.NET CORE 3.1.

# Development environments

Python solutions use VS Code

C# solutions use Visual Studio 2019(v16.8.2)

The assumption here is that it is straighforward to setup Python and therefore the rest of this page will address setting up for developing the web and api projects.

# Platform
The web and api projects in this repository are developed using ASP.NET CORE 3.1 which is a long term support release and can be downloaded from [here](https://dotnet.microsoft.com/download/dotnet-core/3.1). Essentially all that is needed is the software development kit(SDK) as opposed to the runtime version.

The development is setup on Windows 10 Build 18363. Any build of windows 10 should work fine though.


# Storage
The IOU project uses an in memory database but with a [repository](web-projects/IOUTracker/Models/ITrackerRepository.cs) abstracting all the details of accessing data therefore providing an easy switch to any storage of choice.

# Local run

Incase one doesn't have Visual studio installed, it is still possible to view the code using VS code and run the apps using the command line. Follow the commands below for the different projects.

## Fire and Ice Web app

Open the windows terminal, but in its absence it still okay to use the windows command prompt.

Comfirm the right version of .NET CORE with
```
dotnet --info
```

Upon confirming run this series of commands to restore package dependencies and run the project

```
cd web-projects\game-of-thrones
dotnet build
dotnet run
```

## IOU Tracker

```
cd web-projects\IOUTracker
dotnet build
dotnet run
```

# Deployment
The deployment is done using the Visual studio Publish feature. It is worthy to note that while the development is done on a windows environment, the deployment has been done on a linux one.

# Improvements

While these two sets of applications fulfil the functional requirements as requested, a number of non-functional requirements are needed if we are to think production grade

1. Link the application to a persistent store.
2. Apply logging uniformly.
3. Apply access control.
4. Write unit tests.
5. Use github actions to trigger a deployment on push to main.
6. Improve observability by logging to a managed sink.
7. Provide access to deployed apps via secure http.

# Contributions

Contributions are welcome! Simply fork the repository, set it up using the shared instructions and send a pull request. I will be happy to review and merge.