using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using MovieManiacs.Models;
using Xamarin.Forms;

namespace MovieManiacs.ViewModels
{
  public class SearchMovieResultVM : MovieVM
  {
    public string Title
    {
      get { return $"Search result for: {base.SearchParam}"; }
    }

    public SearchMovieResultVM(MovieResult movieResult, INavigation navigation) : base(navigation)
    {
      this.MoviesResult = movieResult;

      Page = 1;

      if (movieResult?.Movies == null)
        return;

      foreach (var item in movieResult.Movies)
      {
        if (!Movies.Contains(item))
          this.Movies.Add(item);
      }
    }

    public override string MoviesURL
    {
      get
      {
        return $"{Utils.Constants.RouteMovieSearch}&query={this.SearchParam}&page={this.Page.ToString()}";
      }
    }
  }
}
