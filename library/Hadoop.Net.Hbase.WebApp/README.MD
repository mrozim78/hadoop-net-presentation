# Hbase Simple App

First add table to HBase database

```sql
create 'colors','definition'

create 'user_color','answer','header'
```
To get result in Hive. First use beeline:

```bash
beeline -u jdbc:hive2://localhost:10000
```

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

To get result
```sql
select 
user_color_count_tmp.red ,
user_color_count_tmp.green,
user_color_count_tmp.blue,
user_color_count_tmp.alpha,
sum(red_number) as as_red,
sum(green_number) as as_green,
sum(blue_number) as as_blue
from (
    select 
    colors.red ,
    colors.green,
    colors.blue ,
    colors.alpha,
    case when user_color_tmp.is_red='true' then 1 
         else 0 
    end as red_number , 

    case when user_color_tmp.is_green='true' then 1
        else 0
    end as green_number, 

    case when user_color_tmp.is_blue='true' then 1
        else 0
    end as blue_number
    from
    colors left join
    (
        select split(key,'\\|')[0] as color_key , 
        is_red , 
        is_green , 
        is_blue 
        from user_color
    ) as user_color_tmp 
    on colors.key = user_color_tmp.color_key) 
as user_color_count_tmp
group by
user_color_count_tmp.red ,
user_color_count_tmp.green,
user_color_count_tmp.blue,
user_color_count_tmp.alpha
```
To check color use

https://www.hexcolortool.com/

