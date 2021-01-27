using Microsoft.AspNetCore.Components;
namespace BasicScoresheetLibrary.Components.Internal
{
    public partial class CellComponent
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter]
        public EnumAlignment TextAlignment { get; set; } = EnumAlignment.Left;
        [Parameter]
        public string TextSize { get; set; } = "5vmin"; //can be smaller if necessary to accomodate smaller devices.
        [Parameter]
        public EventCallback OnClicked { get; set; }
        private void PrivateClicked()
        {
            if (OnClicked.HasDelegate == false)
            {
                return;
            }
            OnClicked.InvokeAsync();
        }
    }
}