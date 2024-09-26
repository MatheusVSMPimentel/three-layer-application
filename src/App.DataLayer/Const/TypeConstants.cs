namespace App.DataLayer.Const
{
    internal struct TypeConstants
    {
        public const string VarChar = "varchar({n})";
        public static string SetVarchar(int n) => VarChar.Replace("{n}", n.ToString());
    }
}
