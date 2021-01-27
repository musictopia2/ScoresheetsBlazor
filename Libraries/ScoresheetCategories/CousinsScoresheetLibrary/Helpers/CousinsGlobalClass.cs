using CommonBasicStandardLibraries.CollectionClasses;
namespace CousinsScoresheetLibrary.Helpers
{
    public static class CousinsGlobalClass
    {
        public static string Title => "Cousins";
        public static CustomBasicList<string> Categories => new CustomBasicList<string>()
        {
            "1 Set Of 3",
            "2 Sets Of 3",
            "1 Set Of 4",
            "2 Sets Of 4",
            "1 Set Of 5",
            "2 Sets Of 5",
            "1 Set Of 6",
            "2 Sets Of 6"
        };
    }
}