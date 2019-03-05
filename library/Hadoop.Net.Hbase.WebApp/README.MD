# Hbase Simple App

First add table to HBase database

```sql
create 'colors','definition'

create 'user_color','',''
```
To get result in Hive. 

First create table 'colors'

```sql
create external table colors (
key string,
red int,
green int,
blue int,
alpha string
)
STORED BY 'org.apache.hadoop.hive.hbase.HBaseStorageHandler' 
WITH SERDEPROPERTIES 
("hbase.columns.mapping" =":key,definition:red,definition:green,definition:blue,definition:alpha")
TBLPROPERTIES("hbase.table.name" = "colors")

```

Next create table 'user_color'

```sql
create external table user_color (
key string,
is_red string ,
is_green string,
is_blue string,
user_agent string,
remote_ip string
)
STORED BY 'org.apache.hadoop.hive.hbase.HBaseStorageHandler' 
WITH SERDEPROPERTIES 
("hbase.columns.mapping" =":key,answer:is_red,answer:is_green,answer:is_blue,header:user_agent,header:remote_ip")
TBLPROPERTIES("hbase.table.name" = "user_color")

```


