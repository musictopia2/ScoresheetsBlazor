using CommonBasicStandardLibraries.CollectionClasses;
namespace BasicScoresheetLibrary.Models
{
    public class PlayerModel
    {
        public string Name { get; set; } = "";
        public CustomBasicList<int> Scores { get; set; } = new CustomBasicList<int>();
    }
}