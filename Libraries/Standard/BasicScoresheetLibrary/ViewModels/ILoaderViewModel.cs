using CommonBasicStandardLibraries.CollectionClasses;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicScoresheetLibrary.ViewModels
{
    public interface ILoaderViewModel : IScorePageList
    {
        string CurrentPage { get; set; }
        //i don't think we need to worry about title on this one.
        RenderFragment? ScoreRendered { get; }
        //i don't think that this time, it needs statehaschanged.  if i am wrong, rethink.
        void PopulateFragment();
    }
}
