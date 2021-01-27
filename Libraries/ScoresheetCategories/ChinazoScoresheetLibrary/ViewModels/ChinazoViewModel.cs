using BasicScoresheetLibrary.ViewModels;
using ChinazoScoresheetLibrary.StorageClasses;
namespace ChinazoScoresheetLibrary.ViewModels
{
    public class ChinazoViewModel : BaseCategoryScoreViewModel, IChinazoViewModel
    {
        public ChinazoViewModel(IChinazoStorage storage) : base(storage) { }
    }
}