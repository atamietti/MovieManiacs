
using System;
using System.Collections;
using System.Windows.Input;
using Xamarin.Forms;

namespace MovieManiacs.Views.Components
{
  public class MoviesListView: ListView
  {
		public static readonly BindableProperty LoadMoreCommandProperty = BindableProperty.Create<MoviesListView, ICommand>(bp => bp.LoadMoreCommand, default(ICommand));

		public ICommand LoadMoreCommand
		{
			get { return (ICommand)GetValue(LoadMoreCommandProperty); }
			set { SetValue(LoadMoreCommandProperty, value); }
		}

		public MoviesListView( ) : base( ListViewCachingStrategy.RecycleElement)
		{
			ItemAppearing += InfiniteListView_ItemAppearing;


		}

		void InfiniteListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
		{
			var items = ItemsSource as IList;

			if (items != null && e.Item == items[items.Count - 1])
			{
        if (LoadMoreCommand != null && LoadMoreCommand.CanExecute(null))
        {
          LoadMoreCommand.Execute(null);
        }
			}
		}

	}
}
