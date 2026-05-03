namespace Information
{
    public partial class Dictionary
    {
        public Dictionary(LanguageCode languageCode, DictionaryEntry[] entries)
        {
            LanguageCode = languageCode;
            entries_ = [.. entries];
        }
    }
    public partial class Dictionaries
    {
        public Dictionaries(Dictionary[] dictionaries)
        {
            dictionaries_ = [.. dictionaries];
        }
    }
}
