using System;
using System.Collections.Generic;
using MovieManiacs.ViewModels;
using Xamarin.Forms;

namespace MovieManiacs.Views
{
  public class SearchMovieResultPage : MovieListPage
  {

    SearchMovieResultVM resultVM;
    public SearchMovieResultPage(): base()
    {
      
    }

		public SearchMovieResultPage(SearchMovieResultVM vm) 
		{
      
      this.resultVM = vm;
      base.Init();
		}

    public override void AddVM()
    {

			this.BindingContext = resultVM;

		}
    public override void AddSearch()
    {
      
    }
    public override void AddTitle()
    {
      this.SetBinding<SearchMovieResultVM>(ContentPage.TitleProperty,vm=>vm.Title);
    }
  }
}
