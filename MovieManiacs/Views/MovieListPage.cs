using System;
using MovieManiacs.ViewModels;
using MovieManiacs.Views.Components;
using MovieManiacs.Views.DataTemplates;
using Xamarin.Forms;
using MovieManiacs.Views;
using MovieManiacs.Models;

namespace MovieManiacs
{
  public class MovieListPage : ContentPage
  {
    protected MovieVM VM;
    public StackLayout StackContent;


    public MovieListPage()
    {

      Init();
    }

    public void Init()
    {
      this.StackContent = new StackLayout();

      this.AddTitle();
      this.AddVM();
      this.AddSearch();
      this.AddList();

      Content = this.StackContent;
    }

    public virtual void AddTitle()
    {
      this.Title = "Movie Maniacs";

    }
    public virtual void AddVM()
    {
      this.VM = new MovieVM(this.Navigation);
      this.BindingContext = VM;

    }
    public virtual void AddSearch()
    {
      var search = new SearchBar();
      search.Placeholder = "Search Bar";
      search?.SetBinding<MovieVM>(SearchBar.TextProperty, vm => vm.SearchParam);
      search?.SetBinding<MovieVM>(SearchBar.SearchCommandProperty, vm => vm.SearchCommand);
      this.StackContent.Children.Add(search);

    }
  

    public virtual void AddList()
    {

      var listMovies = new MoviesListView();
      listMovies?.SetBinding<MovieVM>(ListView.ItemsSourceProperty, vm => vm.Movies);
      listMovies?.SetBinding<MovieVM>(MoviesListView.LoadMoreCommandProperty, vm => vm.LoadMoviesCommand);

      listMovies.ItemSelected += (o, e) =>
      {
        this.Navigation.PushAsync(new MoviePage((Movie)e.SelectedItem));
      };

      listMovies.HasUnevenRows = true;
      listMovies.SeparatorVisibility = SeparatorVisibility.None;
      listMovies.ItemTemplate = new DataTemplate(typeof(MovieListDataTemplate));


      var footActivity = new ActivityIndicator
      {
        IsRunning = true,
        IsVisible = true,
        BackgroundColor = Color.Transparent,
        Color = Color.OrangeRed,
        HorizontalOptions = LayoutOptions.CenterAndExpand
      };

      footActivity?.SetBinding<MovieVM>(ActivityIndicator.IsVisibleProperty, vm => vm.IsBusy);

      listMovies.Footer = footActivity;

      this.StackContent.Children.Add(listMovies);

    }

  }
}

