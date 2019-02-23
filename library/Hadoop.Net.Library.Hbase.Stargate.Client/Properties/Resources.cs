namespace Hadoop.Net.Library.HBase.Stargate.Client
{
    public class Resources
    {
        public readonly static string ResourceBuilder_MinimumForCellOrRowQueryNotMet = "Table name must be specified at a minimum for Cell or Row queries.";
        public readonly static string ResourceBuilder_MinimumForDeleteItemNotMet = "Table name and row key must be specified at a minimum for item deletion.";

        public readonly static string ResourceBuilder_MinimumForBatchInsertNotMet = "Table name must be specified at a minimum for batch insert.";

        public readonly static string ResourceBuilder_MinimumForSchemaUpdateNotMet = "Table name must be specified at a minimum for schema update/creation.";
    
        public readonly static string ResourceBuilder_MinimumForScannerNotMet = "Table name must be specified for scanner access.";

        public readonly static string ResourceBuilder_MinimumForSingleValueAccessNotMet = "Table name, row key, and column name must be specified at a minimum for single value access.";

        public readonly static string ErrorProvider_ColumnNameMissing = "All columns must have a name.";
    
    }
}