using BasicScoresheetLibrary.Components.Core;
using ChinazoScoresheetLibrary.StorageClasses;
namespace ChinazoScoresheetLibrary.Components
{
    public class ChinazoCore : BaseCategoryScoreComponent<IChinazoStorage>
    {
        protected override string CellSize => "11vmin";
        protected override string TextSize => "4.2vmin";
        protected override string CategoryRowHeight => "50vmin";
    }
}