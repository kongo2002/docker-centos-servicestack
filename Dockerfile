# ServiceStack running on mono
#
# VERSION 0.0.1

FROM tianon/centos:6.5
MAINTAINER Gregor Uhlenheuer <kongo2002@gmail.com>

# get mono build dependencies
RUN yum install -y wget tar bzip2 gcc gcc-c++ perl

# build mono runtime
RUN wget -q "http://download.mono-project.com/sources/mono/mono-3.2.8.tar.bz2" && \
    tar xvf mono-3.2.8.tar.bz2 && \
    cd mono-3.2.8 && \
    ./configure --prefix=/usr/local --enable-nls=no && \
    make -j3 && make install && \
    cd .. && \
    rm -rf mono-3.2.8*

# add EPEL
RUN wget -q "http://dl.fedoraproject.org/pub/epel/6/x86_64/epel-release-6-8.noarch.rpm" && \
    wget -q "http://rpms.famillecollet.com/enterprise/remi-release-6.rpm" && \
    rpm -Uvh remi-release-6*.rpm epel-release-6*.rpm && \
    rm *.rpm

RUN yum install -y supervisor
