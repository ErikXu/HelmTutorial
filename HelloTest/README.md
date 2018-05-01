# Publish the project
dotnet publish -c Release

# Package the docker image in the node mechine or push it to the docker registry
docker build -t hello-test:1.0.0 .