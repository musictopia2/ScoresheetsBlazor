using CommonBasicStandardLibraries.CollectionClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinazoScoresheetLibrary.Helpers
{
    public static class ChinazoGlobalClass
    {
        public static CustomBasicList<string> Categories => new CustomBasicList<string>()
        {
            "1 Set Of 3, 1 Run Of 3",
            "2 Sets Of 3",
            "2 Runs Of 3",
            "2 Sets Of 3, 1 Run Of 3",
            "1 Set Of 3, 2 Runs Of 2",
            "3 Sets Of 3",
            "3 Runs of 3",
            "3 Sets Of 3, 1 Run Of 3",
            "1 Set Of 3, 3 Runs Of 3",
            "4 Sets Of 3",
            "4 Runs Of 3"
        };
        public static string Title => "Chinazo";
    }
}
