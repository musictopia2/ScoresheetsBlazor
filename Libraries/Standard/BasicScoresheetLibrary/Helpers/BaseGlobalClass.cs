using System;
namespace BasicScoresheetLibrary.Helpers
{
    public static class BaseGlobalClass
    {
        public static bool HasMainPage { get; set; }
        public static bool NeedsRefresh { get; set; } = true;
        public static string PreviousPageKey => "PreviousPage";
        public static Action? ReloadMainPage { get; set; }
    }
}