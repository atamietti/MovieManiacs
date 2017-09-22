using MovieManiacs.Models;
using MovieManiacs.Utils;
using Xamarin.Forms;

namespace MovieManiacs.Views.DataTemplates
{
  public class MovieListDataTemplate : ViewCell
  {
    private Color lineColor = Color.FromHex("#68C7E9");


    public MovieListDataTemplate()
    {

      var topFrame = new Frame
      {
        OutlineColor = lineColor,
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
      lblTitle?.SetBinding<Movie>(Label.TextProperty, vm => vm.Title); 

			var lblReleaseDate = new Label();
			lblReleaseDate?.SetBinding<Movie>(Label.TextProperty, vm => vm.ReleaseDate, stringFormat: "Release Date: {0:d}");


			var lblGenre = new Label();
			lblGenre?.SetBinding<Movie>(Label.TextProperty, vm => vm.GengreIds, stringFormat: "Genres: {0:d}", converter: new ConverterGenreIds());

      var stackContent = new StackLayout
      {
        Children =
        {
          image,
          lblTitle,
          lblReleaseDate,
          lblGenre
        }
      };


      topFrame.Content = stackContent;
      this.View = topFrame;
    }


  }
}

