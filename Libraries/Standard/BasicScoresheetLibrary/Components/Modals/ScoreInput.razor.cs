using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using aa = BasicBlazorLibrary.Components.CssGrids.Helpers;
namespace BasicScoresheetLibrary.Components.Modals
{
    public partial class ScoreInput
    {
        [Parameter]
        public int Value { get; set; }
        [Parameter]
        public EventCallback<int> ValueChanged { get; set; }
        [Parameter]
        public string Player { get; set; } = "";
        [Parameter]
        public string Category { get; set; } = "";

        private readonly CustomBasicList<int> _numbers = new CustomBasicList<int>()
        {
            7, 8, 9, 4, 5, 6, 1, 2, 3
        };
        private string _display = "";
        protected override void OnParametersSet()
        {
            if (Visible == false || Value == 0)
            {
                _display = "";
                return;
            }
            _display = Value.ToString(); //hopefully does not do onparameterset everytime i click an entry.
            base.OnParametersSet();
        }
        private string GetPlayer()
        {
            if (string.IsNullOrWhiteSpace(Player) && string.IsNullOrWhiteSpace(Category))
            {
                return "";
            }
            if (string.IsNullOrWhiteSpace(Category))
            {
                return Player;
            }
            if (string.IsNullOrWhiteSpace(Player) == false)
            {
                return $"{Player} - {Category}";
            }
            return Category;
        }
        private void UpdateValue(int value)
        {
            UpdateValue(value.ToString());
        }
        private void UpdateValue(string value)
        {
            if (value == "0")
            {
                if (_display == "")
                {
                    return;
                }
            }
            if (value == "-")
            {
                if (_display != "")
                {
                    return; //has to ignore because a minus can't be used if not the first item.
                }
            }
            if (_display.Length <= 2)
            {
                _display += value; //just append.
                return;
            }
            if (_display.StartsWith("-") && _display.Length == 3)
            {
                _display += value; //just append.
                return;
            }
            return; //can't do anymore.
        }
        private void Clear()
        {
            _display = "";
        }
        private void BackSpace()
        {
            if (_display == "")
            {
                return;
            }
            _display = _display.Substring(0, _display.Length - 1);
        }
        private void ProcessEnter()
        {
            bool rets = int.TryParse(_display, out int results);
            if (rets == true)
            {
                ValueChanged.InvokeAsync(results);
            }
            ProcessCancel(); //this too.
        }
        private void ProcessCancel()
        {
            VisibleChanged.InvokeAsync(false); //hopefully this simple.
        }
        private static string GetRowsColumns => aa.RepeatMinimum(4);
    }
}