namespace App.BusinessLayer.Const
{
    internal struct ValidationConstMessages
    {
        public const string NotEmptyMessage = "The field {PropertyName} needs to be fill.";
        public const string LengthMessage = "The field {PropertyName} needs to be between {MinLength} and {MaxLength} chars.";
        public const string GreatThanMessage = "The field {PropertyName} needs to be over {ComparisonValue}.";
        public const string DocumentLenghtEqualMessage = "The field Document needs be {ComparisonValue} chars and was pass only {PropertyValue}.";
        public const string InvalidFieldMessage = "The field {PropertyName} is invalid.";
    }
}