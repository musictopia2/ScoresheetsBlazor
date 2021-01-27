using CommonBasicStandardLibraries.CollectionClasses;
namespace BasicScoresheetLibrary.ViewModels
{
    public interface ICategoryScoreViewModel : IScoreViewModel
    {
        CustomBasicList<string> Categories { get; }
    }
}