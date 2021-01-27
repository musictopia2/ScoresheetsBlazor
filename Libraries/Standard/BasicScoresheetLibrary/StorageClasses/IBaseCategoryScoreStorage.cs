using CommonBasicStandardLibraries.CollectionClasses;
namespace BasicScoresheetLibrary.StorageClasses
{
    public interface IBaseCategoryScoreStorage : IScoreStorage
    {
        CustomBasicList<string> Categories { get; }
    }
}