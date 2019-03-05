using System;
using System.Collections.Generic;
using System.Linq;
using Hadoop.Net.Library.HBase.Stargate.Client.Models;

namespace Hadoop.Net.Hbase.WebApp.Repository
{
    public class HbaseRowFactory
    {
        private string Table;
        public string Row;
        private Dictionary<HBaseCellDescriptor,string> values = new Dictionary<HBaseCellDescriptor, string>();
        
        private HbaseRowFactory(string table, string row)
        {
            Table = table;
            Row = row;
        }

        public static HbaseRowFactory CreateFactory(string tableName, string row)
        {
            return new HbaseRowFactory(tableName,row);
        }
        
        private HbaseRowFactory AddColumnValue(string column , string qualifier , string value)
        {
            values.Add(new HBaseCellDescriptor()
                {
                    Column = column , 
                    Qualifier = qualifier
                },
                value);
            return this;
        }

        public HbaseRowFactory AddColumnStringValue(string column, string qualifier, string value)
        {
            return AddColumnValue(column, qualifier, value);
        }
        
        public HbaseRowFactory AddColumnBooleanValue(string column, string qualifier, bool value)
        {
            return AddColumnValue(column, qualifier, value ? "true" : "false");
        }
        
        
        public HbaseRowFactory AddColumnDateTimeValue(string column, string qualifier, DateTime dateTime)
        {
            return AddColumnValue(column, qualifier, dateTime.ToString("yyyy-MM-dd HH:mm:ss"));
        }
        
        public HbaseRowFactory AddColumnIntValue(string column, string qualifier,int value)
        {
            return AddColumnValue(column, qualifier, value.ToString());
        }
        
        public HbaseRowFactory AddColumnLongValue(string column, string qualifier,long value)
        {
            return AddColumnValue(column, qualifier, value.ToString());
        }
        
        public HbaseRowFactory AddColumnDecimalValue(string column, string qualifier,decimal value)
        {
            return AddColumnValue(column, qualifier, value.ToString("0.##"));
        }
        
        
        public CellSet MakeCellSet()
        {
                 
            return new CellSet(values.Select(a =>

                new Cell(

                    new Identifier()
                    {
                        Table = Table,
                        Row = Row,
                        CellDescriptor = a.Key

                    },
                    a.Value

                )
            ))
            {
                Table = Table
            };
        }
    }
}