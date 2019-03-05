using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using Hadoop.Net.Library.HBase.Stargate.Client.Models;

namespace Hadoop.Net.Hbase.WebApp.Repository
{
    public static class ExtendCellSetMethods
    {
        private static string GetValue(CellSet cellSet, string column, string qualifier, bool returnNull = false)
        {
            foreach (Cell cell in cellSet)
                if (cell.Identifier.CellDescriptor.Column == column &&
                    cell.Identifier.CellDescriptor.Qualifier == qualifier)
                    return cell.Value;

            if (returnNull)
                return null;

            throw new Exception($"No such value {column}:{qualifier}");
        }

        public static string GetString(this CellSet cellSet
            , string column, string qualifier)
        {
            return GetValue(cellSet, column, qualifier);
        }

        public static string GetStringOrNull(this CellSet cellSet
            , string column, string qualifier)
        {
            return GetValue(cellSet, column, qualifier, returnNull: true);
        }


        public static bool GetBoolean(this CellSet cellSet
            , string column, string qualifier)
        {
            string value = GetValue(cellSet, column, qualifier);
            if (new string[] {"true", "false"}.Contains(value))
                return value == "true";
            throw new Exception($"Value {value} is not boolean'");
        }

        public static bool? GetBooleanNullable(this CellSet cellSet
            , string column, string qualifier)
        {

            string value = GetValue(cellSet, column, qualifier, returnNull: true);
            if (value == null)
                return null;
            if (new string[] {"true", "false"}.Contains(value))
                return value == "true";
            throw new Exception($"Value {value} is not boolean'");
        }


        public static DateTime GetDateTime(this CellSet cellSet, string column, string qualifier)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            string value = GetValue(cellSet, column, qualifier);
            return DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss", provider);
        }

        public static DateTime? GetDateTimeNullable(this CellSet cellSet, string column, string qualifier)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            string value = GetValue(cellSet, column, qualifier, returnNull: true);
            if (value == null)
                return null;
            return DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss", provider);
        }


        public static int GetInt(this CellSet cellSet, string column, string qualifier)
        {
            string value = GetValue(cellSet, column, qualifier);
            
            return int.Parse(value);
          
        }
        public static int? GetIntNullable(this CellSet cellSet, string column, string qualifier)
        {
            string value = GetValue(cellSet, column, qualifier);
            if (value == null)
                return null;
            return int.Parse(value);
          
        }
        
        
        public static long GetLong(this CellSet cellSet, string column, string qualifier)
        {
            string value = GetValue(cellSet, column, qualifier);
            
            return long.Parse(value);
          
        }
        public static long? GetLongNullable(this CellSet cellSet, string column, string qualifier)
        {
            string value = GetValue(cellSet, column, qualifier);
            if (value == null)
                return null;
            return long.Parse(value);
          
        }
        
        public static decimal GetDecimal(this CellSet cellSet, string column, string qualifier)
        {
            string value = GetValue(cellSet, column, qualifier);

            return decimal.Parse(value);

        }
        
        public static decimal? GetDecimalNullable(this CellSet cellSet, string column, string qualifier)
        {
            string value = GetValue(cellSet, column, qualifier);
            if (value == null)
                return null;
            
            return decimal.Parse(value);

        }
        

    }
}