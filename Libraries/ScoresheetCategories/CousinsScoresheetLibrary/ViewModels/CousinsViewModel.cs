using BasicScoresheetLibrary.ViewModels;
using CousinsScoresheetLibrary.StorageClasses;
namespace CousinsScoresheetLibrary.ViewModels
{
    public class CousinsViewModel : BaseCategoryScoreViewModel, ICousinsViewModel
    {
        public CousinsViewModel(ICousinsStorage storage) : base(storage) { }
    }
}