namespace TWT.Core.Constans
{
    public static class Regexes
    {
        public static readonly string LincensePlateRegex = "^[A-Z a-z]{3}-[0-9]{3}$";
        public static readonly string OwnerNameRegex = "^[a-z A-Z]{3,20} [a-z A-Z]{3,20}$";
    }
}
