#!/bin/bash

# Build hadoop images with .net core
docker build -t deweydms/hadoop-base hadoop/base
docker build -t deweydms/hadoop-datanode hadoop/datanode
docker build -t deweydms/hadoop-historyserver hadoop/historyserver
docker build -t deweydms/hadoop-namenode hadoop/namenode
docker build -t deweydms/hadoop-nodemanager hadoop/nodemanager
docker build -t deweydms/hadoop-resourcemanager hadoop/resourcemanager

# Build hbase images
docker build -t deweydms/hbase-base hbase/base
docker build -t deweydms/hbase-standalone hbase/standalone

# Build hive images
docker build -t deweydms/hive-server hive/server
docker build -t deweydms/hive-postgresql hive/postgresql

