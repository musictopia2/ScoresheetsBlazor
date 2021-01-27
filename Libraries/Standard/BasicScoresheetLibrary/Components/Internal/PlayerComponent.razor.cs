using Microsoft.AspNetCore.Components;
namespace BasicScoresheetLibrary.Components.Internal
{
    public partial class PlayerComponent
    {
        [Parameter]
        public string Value { get; set; } = "";
        [Parameter]
        public EventCallback<string> ValueChanged { get; set; } //for bindings.
        [Parameter]
        public string TextSize { get; set; } = "5vmin";
        [Parameter]
        public EventCallback OnChange { get; set; }
        private void PrivateChanged(string value)
        {
            ValueChanged.InvokeAsync(value);
            if (OnChange.HasDelegate)
            {
                OnChange.InvokeAsync(); //to let the others know it changed so it can update via signal r if necessary.
            }
        }
    }
}