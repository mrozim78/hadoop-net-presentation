#!/bin/bash
rm -f mapreduce_publish.tar.gz
dotnet build
dotnet publish
mkdir -p mapreduce_publish
cd mapreduce_publish
rm *.*
cp ../Hadoop.Net.MapReduce.Gus.Street.Mapper/bin/Debug/netcoreapp2.2/publish/*.dll .
cp ../Hadoop.Net.MapReduce.Gus.Street.Mapper/bin/Debug/netcoreapp2.2/publish/*.runtimeconfig.json .
cp ../Hadoop.Net.MapReduce.Gus.Street.Reducer/bin/Debug/netcoreapp2.2/publish/*.dll .
cp ../Hadoop.Net.MapReduce.Gus.Street.Reducer/bin/Debug/netcoreapp2.2/publish/*.runtimeconfig.json .
cp ../Hadoop.Net.MapReduce.Gus.Street.Mapper.AlterKeyAndValue/bin/Debug/netcoreapp2.2/publish/*.dll .
cp ../Hadoop.Net.MapReduce.Gus.Street.Mapper.AlterKeyAndValue/bin/Debug/netcoreapp2.2/publish/*.runtimeconfig.json .
cd ..
tar -czvf mapreduce_publish.tar.gz mapreduce_publish