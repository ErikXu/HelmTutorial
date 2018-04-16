FROM java:8u111-jre
RUN mkdir /app
COPY . /app
WORKDIR /app
CMD ["java","-Xmx4g","-Djava.security.egd=file:/dev/./urandom","-jar","hello-1.0.0.jar"]