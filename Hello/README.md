# Package the jar
mvn package 

# Package the docker image in the node mechine or push it to the docker registry
docker build -t hello:1.0.0 .