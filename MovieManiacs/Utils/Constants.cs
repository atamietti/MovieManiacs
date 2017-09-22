using System;
namespace MovieManiacs.Utils
{
  public class Constants
  {
    public const  string Api = "https://api.themoviedb.org/3/";

    public const string ApiKey = "1f54bd990f1cdfb230adb312546d765d";

    public const string RouteGenre = "genre/movie/list?api_key=" + ApiKey;

    public const string RouteMovieList = "movie/upcoming?api_key=" + ApiKey;

    public const string RouteMovieSearch = "search/movie?api_key=" + ApiKey;

  }
}
