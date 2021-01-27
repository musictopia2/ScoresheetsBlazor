using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicScoresheetLibrary.ViewModels
{
    public abstract class BaseLoaderViewModel : ILoaderViewModel
    {
        public string CurrentPage { get; set; } = "";
        public RenderFragment? ScoreRendered { get; private set; }
        public CustomBasicList<string> ScorePages { get; protected set; } = new CustomBasicList<string>();
        protected abstract Type GetScoreType();
        public BaseLoaderViewModel()
        {
            GenerateScoreList();
        }
        protected abstract void GenerateScoreList();
        public void PopulateFragment()
        {
            ScoreRendered = (builder) =>
            {
                Type type = GetScoreType();
                builder.OpenComponent(0, type);
                builder.CloseComponent();
            };
        }
    }
}
