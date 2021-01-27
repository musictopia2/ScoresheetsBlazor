using BasicScoresheetLibrary.StorageClasses;
using CommonBasicStandardLibraries.CollectionClasses;
using CousinsScoresheetLibrary.Helpers;
using Microsoft.JSInterop;
namespace CousinsScoresheetLibrary.StorageClasses
{
    public class CousinsStorage : BaseCategoryScoreStorage, ICousinsStorage
    {
        public CousinsStorage(IJSRuntime js) : base(js) { }
        public override string Title => CousinsGlobalClass.Title;
        public override CustomBasicList<string> Categories => CousinsGlobalClass.Categories;
    }
}