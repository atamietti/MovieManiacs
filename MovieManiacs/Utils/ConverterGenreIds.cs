using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;
using System.Linq;

namespace MovieManiacs.Utils
{
  public class ConverterGenreIds : IValueConverter
  {

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var retorno = string.Empty;

      if (value == null)
        return retorno;
      
        var lista = ((List<int>)value);

        foreach (var item in lista)
        retorno += $"{GenreUtils.Genres?.GenreList?.FirstOrDefault(f => f.Id == item)?.Name}; ";

      return retorno;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
