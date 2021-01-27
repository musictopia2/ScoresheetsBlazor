using BasicScoresheetLibrary.Components.MiscScores;
using BasicScoresheetLibrary.ViewModels;
using ChinazoScoresheetLibrary.Components;
using CommonBasicStandardLibraries.CollectionClasses;
using CommonBasicStandardLibraries.Exceptions;
using CousinsScoresheetLibrary.Components;
using System;
namespace AllScoresLoaderLibrary
{
    public class LoaderViewModel : BaseLoaderViewModel
    {
        protected override void GenerateScoreList()
        {
            ScorePages = new CustomBasicList<string>()
            {
                "Misc Scores",
                "Chinazo",
                "Cousins"
            };
        }
        protected override Type GetScoreType()
        {
            Console.WriteLine(CurrentPage);
            if (CurrentPage == "")
            {
                throw new BasicBlankException("CurrentPage cannot be blank.  Otherwise, should not even figure out which component it is.  Try making it show the list for a person to choose from");
            }
            if (CurrentPage == "Misc Scores")
            {
                return typeof(MiscScoresInputComponent);
            }
            if (CurrentPage == "Chinazo")
            {
                return typeof(ChinazoInputComponent);
            }
            if (CurrentPage == "Cousins")
            {
                return typeof(CousinsInputComponent);
            }
            throw new BasicBlankException($"Score Of {CurrentPage} Not Supported");
        }
    }
}
