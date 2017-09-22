using System;
using MovieManiacs.Models;
using MovieManiacs.Utils;
using Xamarin.Forms;

namespace MovieManiacs.Views
{
  public class MoviePage : ContentPage
  {

    private Color outlineFrameColor = Color.FromHex("#BFC5C5");

    public MoviePage(Movie movie)
    {
      this.Title = movie.Title;

      this.BindingContext = movie;
      var topFrame = new Frame
      {
        OutlineColor = outlineFrameColor,
        VerticalOptions = LayoutOptions.FillAndExpand,
        HorizontalOptions = LayoutOptions.FillAndExpand,
        BackgroundColor = Color.Transparent,
        HasShadow = true,
        Padding = new Thickness(20),

      };


      var image = new Image();
      image.Aspect = Aspect.AspectFit;
      image.VerticalOptions = LayoutOptions.FillAndExpand;
      image.HorizontalOptions = LayoutOptions.FillAndExpand;
      image?.SetBinding<Movie>(Image.SourceProperty, vm => vm.PosterPath, stringFormat: "https://image.tmdb.org/t/p/w500{0}");

      var lblTitle = new Label();
      lblTitle.FontAttributes = FontAttributes.Bold;
      lblTitle?.SetBinding<Movie>(Label.TextProperty, vm => vm.Title); ;

      var lblReleaseDate = new Label();
      lblReleaseDate?.SetBinding<Movie>(Label.TextProperty, vm => vm.ReleaseDate, stringFormat: "{0:d}");

      var lblGenre = new Label();
      lblGenre?.SetBinding<Movie>(Label.TextProperty, vm => vm.GengreIds, converter: new ConverterGenreIds());

      var lblOverView = new Label();
      lblOverView?.SetBinding<Movie>(Label.TextProperty, vm => vm.OverView);



      var poster = new Image()
      {
        Aspect = Aspect.AspectFill,
        VerticalOptions = LayoutOptions.FillAndExpand,
        HorizontalOptions = LayoutOptions.FillAndExpand
      };
      poster.SetBinding<Movie>(Image.SourceProperty, vm => vm.BackdropPath, stringFormat: "https://image.tmdb.org/t/p/w500{0}");


      var stackContent = new StackLayout
      {
        Children =
    {
      image,
      lblTitle,
      lblReleaseDate,
      lblGenre,
      lblOverView,

    }
      };


      topFrame.Content = stackContent;

      this.Content = new ScrollView { Content = new StackLayout { Children = { poster, topFrame } } };


    }
  }
}
