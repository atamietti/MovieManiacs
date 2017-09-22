using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MovieManiacs.ViewModels
{
  public class BaseVM : INotifyPropertyChanged
  {

    private bool _isbusy;
    public bool IsBusy
    {
      get
      {
        return _isbusy;
      }
      set
      {
        this._isbusy = value;
        OnPropertyChanged(nameof(IsBusy));
      }
    }


    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      var handler = PropertyChanged;
      if (handler != null)
      {
        handler(this, new PropertyChangedEventArgs(propertyName));
      }
    }


  }

}
