using System.Collections.Generic;
using Newtonsoft.Json;

namespace MovieManiacs.Models
{
  public class MovieResult 
  {
		
		[JsonProperty("Page")]
		public int Page
    {
      get;
      set;
    
    }
		[JsonProperty("total_results")]
		public int TotalResults
    {
      get;
      set;
    }

		[JsonProperty("total_pages")]
		public int TotalPages
		{
			get;
			set;

		}

		[JsonProperty("results")]
		public List<Movie> Movies
		{
			get;
			set;
		}
  }
}

