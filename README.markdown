# docker-centos-servicestack

This repository contains an examplary C# [ServiceStack][servicestack] project
running on [mono][mono] that can be easily deployed into a CentOS docker image.


## Usage

The `Makefile` lets you easily build the ready-to-use [docker][docker] image
that can be used to run the [ServiceStack][servicestack] powered web service on
a docker enabled unix box.

The docker image is currently configured to run a [supervisord][supervisord]
daemon that is responsible for starting and observing the web service running on
[mono][mono]. The web service exposes the API endpoint on port 8080. The
docker image itself is configured to expose that port by default.

``` bash
# build the docker image
$ make docker

# run the built image
$ make run
```


### Run interactively

In order to see the output of the running [supervisord][supervisord] you can
start the docker image with an interactive shell - basically invoking `docker`
with `-t -i --rm`

``` bash
$ make interactive
```


## Web service

As soon as your docker image is running you can test your web service on the
port that is forwarded by docker:

``` bash
# look for the exposed port 8080 of your docker container
$ docker ps
CONTAINER ID   IMAGE                                  COMMAND                PORTS
678a549e3499   kongo2002/centos-servicestack:latest   /usr/bin/supervisord   0.0.0.0:49154->8080/tcp

# here the port was forwarded to 49154
$ curl localhost:49154/ping
{"data":"pong","success":true}

$ curl localhost:49154/echo/foo
{"data":"foo","success":true}
```


[servicestack]: https://github.com/ServiceStack/ServiceStack/
[supervisord]: http://supervisord.org/
[docker]: https://www.docker.io
[mono]: http://www.mono-project.com/
