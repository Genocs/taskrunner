# Introduction 
This repo is a simple long running task without any interaction. The scope is to use it as Windows Service fashion 


# Getting Started
TODO: Guide users through getting your code up and running on their own system. In this section you can talk about:
1.	Installation process
2.	Software dependencies
3.	Latest releases
4.	API references

# Build and Test

Build the Docker image and set the tag 
``` bash 
docker build -t taskrunner.service .
docker tag taskrunner.service genocs/taskrunner.service
```

Push the image to the docker conatainer registry. The pull command is provided as well 

``` bash 
docker push genocs/taskrunner.service
docker pull genocs/taskrunner.service
```

## How to run a docker container 
``` bash 
docker run -d --name taskrunner.service.local genocs/taskrunner.service
```

# Contribute
TODO: Explain how other users and developers can contribute to make your code better. 

If you want to learn more about creating good readme files then refer the following [guidelines](https://docs.microsoft.com/en-us/azure/devops/repos/git/create-a-readme?view=azure-devops). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [Chakra Core](https://github.com/Microsoft/ChakraCore)



