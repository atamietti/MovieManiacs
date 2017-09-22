using System.Collections.Generic;
using Newtonsoft.Json;

namespace MovieManiacs.Models
{
  
  public class GenresResult
  {
    [JsonProperty("genres")]
    public List<Genre> GenreList
    {
      get;
      set;
    }
  }

}
