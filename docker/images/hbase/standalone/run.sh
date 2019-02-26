#!/bin/bash

/opt/hbase-$HBASE_VERSION/bin/start-hbase.sh
/opt/hbase-$HBASE_VERSION/bin/hbase thrift start -p 9090 --infoport 9095 &
/opt/hbase-$HBASE_VERSION/bin/hbase rest start -p 9080 --infoport 9085 &
tail -f /opt/hbase-$HBASE_VERSION/logs/*

