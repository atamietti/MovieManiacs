using Newtonsoft.Json;

namespace MovieManiacs.Models
{
  public class Genre
  {
	
    [JsonProperty("Id")]
		public int Id
    {
      get;
      set;
    }

		[JsonProperty("name")]
		public string Name
    {
      get;
      set;
    }
  
  }
}
