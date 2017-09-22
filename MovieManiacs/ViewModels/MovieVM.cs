using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MovieManiacs.Models;
using MovieManiacs.Services;
using MovieManiacs.Utils;
using MovieManiacs.Views;
using Xamarin.Forms;

namespace MovieManiacs.ViewModels
{
  public class MovieVM : BaseVM
  {
    protected INavigation Navigation;

    private MovieResult _moviesResult;
    public MovieResult MoviesResult
    {
      get { return this._moviesResult; }
      set
      {

        this._moviesResult = value;
        base.OnPropertyChanged((nameof(this.MoviesResult)));
      }
    }

    private ObservableCollection<Movie> _movies;
    public ObservableCollection<Movie> Movies
    {
      get { return this._movies; }
      set
      {
        this._movies = value;
        base.OnPropertyChanged((nameof(this.Movies)));
      }
    }

    private Movie _selectedMovie;
    public Movie SelectedMovie
    {
      get { return this._selectedMovie; }
      set
      {
        this._selectedMovie = value;
        base.OnPropertyChanged((nameof(this.SelectedMovie)));
      }
    }

    private int _page;
    public int Page
    {
      get { return this._page; }
      set
      {
        this._page = value;
        base.OnPropertyChanged((nameof(this.Page)));
      }
    }

    private string _searchParam;
    public string SearchParam
    {
      get { return this._searchParam; }
      set
      {
        this._searchParam = value;
        base.OnPropertyChanged((nameof(this.SearchParam)));
      }
    }

    public virtual string MoviesURL
    {
      get
      {
        return $"{Constants.RouteMovieList}&page={this.Page.ToString()}";
      }
    }

    public BaseWS<MovieResult> Service
    {
      get;
      set;
    }

    public Command LoadMoviesCommand
    {
      get; set;
    }

    public Command SearchCommand
    {
      get; set;
    }

    public MovieVM(INavigation navigation)
    {
      this.Navigation = navigation;

      this.LoadMoviesCommand = new Command(async () =>
      {
        await this.LoadMovies();
      });

      this.SearchCommand = new Command(async () =>
      {
        await this.Search();
      });

      Movies = new ObservableCollection<Movie>();

      this.Service = new BaseWS<MovieResult>(Constants.Api);

      LoadMoviesCommand.Execute(null);

    }

    public async Task LoadMovies()
    {

      base.IsBusy = true;

      if (this.Page == 0)
        GenreUtils.Genres = await new BaseWS<GenresResult>(Constants.Api).RequestAsync(Constants.RouteGenre);

      if (this.Page <= this.MoviesResult?.TotalPages)
        this.Page++;
      else
        this.Page = 1;

      this.MoviesResult = await this.Service.RequestAsync(this.MoviesURL);
      base.IsBusy = false;

      foreach (var item in this.MoviesResult.Movies)
      {
        if (!Movies.Contains(item))
          this.Movies.Add(item);
      }

    }

    public async Task Search()
    {
      if (string.IsNullOrWhiteSpace((this.SearchParam)))
        return;
      

      var searchUrl = $"{Constants.RouteMovieSearch}&query={this.SearchParam}&page=1";

      var movies = await this.Service.RequestAsync(searchUrl);
      var searchVM = new SearchMovieResultVM(movies, this.Navigation);
      searchVM.SearchParam = this.SearchParam;
      await this.Navigation.PushAsync(new SearchMovieResultPage(searchVM));
    }


  }
}

