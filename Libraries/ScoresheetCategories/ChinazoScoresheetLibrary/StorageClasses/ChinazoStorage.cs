using BasicScoresheetLibrary.StorageClasses;
using ChinazoScoresheetLibrary.Helpers;
using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.JSInterop;
namespace ChinazoScoresheetLibrary.StorageClasses
{
    public class ChinazoStorage : BaseCategoryScoreStorage, IChinazoStorage
    {
        public ChinazoStorage(IJSRuntime js) : base(js)
        {
        }
        public override string Title => ChinazoGlobalClass.Title;
        public override int MinimumPlayers => 4; //has to be 4 because more text to deal with.
        public override CustomBasicList<string> Categories => ChinazoGlobalClass.Categories;
    }
}
