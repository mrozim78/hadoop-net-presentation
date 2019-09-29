FROM openjdk:8-slim-stretch
MAINTAINER "Remigiusz Mrozek <mrozi.m@gmail.com>"


ENV JAVA_HOME=/usr/lib/jvm/java-8-openjdk-amd64/
RUN mkdir /usr/lib/jvm
RUN ln -s /usr/local/openjdk-8 /usr/lib/jvm/java-8-openjdk-amd64

RUN apt-get update && DEBIAN_FRONTEND=noninteractive apt-get install -y --no-install-recommends net-tools curl wget gpg apt-transport-https openssh-client


RUN wget -qO- https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.asc.gpg
RUN mv microsoft.asc.gpg /etc/apt/trusted.gpg.d/
RUN wget -q https://packages.microsoft.com/config/debian/9/prod.list
RUN mv prod.list /etc/apt/sources.list.d/microsoft-prod.list

RUN apt-get update && apt-get install -y dotnet-sdk-2.2

ENV HADOOP_VERSION 2.7.7
ENV HADOOP_URL https://www.apache.org/dist/hadoop/common/hadoop-$HADOOP_VERSION/hadoop-$HADOOP_VERSION.tar.gz
RUN set -x \
   && curl -fSL "$HADOOP_URL" -o /tmp/hadoop.tar.gz \
   && curl -fSL "$HADOOP_URL.asc" -o /tmp/hadoop.tar.gz.asc \
   && tar -xvf /tmp/hadoop.tar.gz -C /opt/ \
   && rm /tmp/hadoop.tar.gz*
    
RUN ln -s /opt/hadoop-$HADOOP_VERSION/etc/hadoop /etc/hadoop
RUN cp /etc/hadoop/mapred-site.xml.template /etc/hadoop/mapred-site.xml
RUN mkdir /opt/hadoop-$HADOOP_VERSION/logs

RUN mkdir /hadoop-data

ENV HADOOP_PREFIX=/opt/hadoop-$HADOOP_VERSION
ENV HADOOP_CONF_DIR=/etc/hadoop
ENV MULTIHOMED_NETWORK=1

ENV USER=root
ENV PATH $HADOOP_PREFIX/bin/:$PATH


#Koniec wstawienia

ADD entrypoint.sh /entrypoint.sh
RUN chmod a+x /entrypoint.sh

ENTRYPOINT ["/entrypoint.sh"]