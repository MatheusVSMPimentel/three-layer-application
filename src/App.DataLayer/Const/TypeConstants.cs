namespace App.DataLayer.Const
{
    internal struct TypeConstants
    {
        public const string VarChar = "varchar({n})";
        public const string DecimalType = "decimal(18,2)";
        public static string SetVarchar(int n) => VarChar.Replace("{n}", n.ToString());
    }
}
