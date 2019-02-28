# Map Reduce Gus Street

Copy *ULIC_Adresowy* file with street from link:

http://eteryt.stat.gov.pl/eTeryt/rejestr_teryt/udostepnianie_danych/baza_teryt/uzytkownicy_indywidualni/pobieranie/pliki_pelne.aspx?contrast=default


into some HDFS directory for example into path

*/data/input/gus*

Next on source mapreduce run script:

```bash
./make_mapreduce_publish.sh
```
Next file 

*mapreduce_publish.tar.gz* 

copy into nodemanager container and extract in root directory

```bash
tar -xvf mapreduce_publish.tar.gz
```

In container nodemanager in root directory run :
```bash
hadoop jar /opt/hadoop-2.7.7/share/hadoop/tools/lib/hadoop-streaming-2.7.7.jar \
-files "mapreduce_publish"  \
-mapper "dotnet mapreduce_publish/Hadoop.Net.MapReduce.Gus.Street.Mapper.dll" \
-combiner "dotnet mapreduce_publish/Hadoop.Net.MapReduce.Gus.Street.Reducer.dll" \
-reducer "dotnet mapreduce_publish/Hadoop.Net.MapReduce.Gus.Street.Reducer.dll" \
-input /data/input \
-output /data/output/gus/step1
```
Next run second MapReduce job to swap key and value:

```bash
hadoop jar /opt/hadoop-2.7.7/share/hadoop/tools/lib/hadoop-streaming-2.7.7.jar \
-D mapreduce.job.output.key.comparator.class=org.apache.hadoop.mapreduce.lib.partition.KeyFieldBasedComparator \
-D mapred.text.key.comparator.options=-k1nr \
-files "mapreduce_publish"  \
-mapper "dotnet mapreduce_publish/Hadoop.Net.MapReduce.Gus.Street.Mapper.AlterKeyAndValue.dll" \
-reducer  org.apache.hadoop.mapred.lib.IdentityReducer \
-input /data/output/gus/step1 \
-output /data/output/gus/step2 
```

In HDFS in directory 

*/data/output/gus/step2* 

you have your result file.
