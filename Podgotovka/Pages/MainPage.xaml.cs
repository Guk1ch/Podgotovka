using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Podgotovka.Data;

namespace Podgotovka.Pages
{
	/// <summary>
	/// Interaction logic for MainPage.xaml
	/// </summary>
	public partial class MainPage : Page
	{
		public static List<ToDo> toDos { get; set; }
		public static User us { get; set; }
		public MainPage(User user) 
		{
			InitializeComponent();
			us = user;
			toDos = Bd_connection.tasksEntities.ToDo.Where(x => x.ID_User == user.ID_User).ToList();
			List<string> ls = new List<string>();
			ls.Add("All");
			ls.Add("Old");
			ls.Add("New");
			cb_Filters.ItemsSource = ls;
			List<Data.Type> types = Bd_connection.tasksEntities.Type.ToList();
			types.Insert(0, new Data.Type() { ID_Type = -1, Name = "All" });
			cb_Type.ItemsSource = types;
			cb_Type.DisplayMemberPath = "Name";
			
			this.DataContext = this;

		}

		public  void Filter() 
		{
			List<ToDo> dos = Bd_connection.tasksEntities.ToDo.Where(x => x.ID_User == us.ID_User).ToList();
			if(cb_Type.SelectedItem != null)
			{
				if (cb_Type.SelectedItem.ToString() == "Выполнено")
				{
					dos = dos.Where(x => x.ID_Type == 1).ToList();
				}
				else if (cb_Type.SelectedItem.ToString() == "Выполняется")
				{
					dos = dos.Where(x => x.ID_Type == 2).ToList();
				}
				else if (cb_Type.SelectedItem.ToString() == "Брошено")
				{
					dos = dos.Where(x => x.ID_Type == 3).ToList();
				}
				else if (cb_Type.SelectedItem.ToString() == "All")
				{
					dos = Bd_connection.tasksEntities.ToDo.Where(x => x.ID_User == us.ID_User).ToList();
				}
			}
			if (cb_Filters.SelectedItem != null) 
			{
				if (cb_Filters.SelectedItem.ToString() == "Old")
				{
					dos = dos.OrderBy(x => x.DataComplite).ToList();
				}
				else if (cb_Filters.SelectedItem.ToString() == "New")
				{
					dos = dos.OrderByDescending(x => x.DataComplite).ToList();
				}
				else if (cb_Filters.SelectedItem.ToString() == "All") 
				{
					dos = Bd_connection.tasksEntities.ToDo.Where(x => x.ID_User == us.ID_User).ToList();
				}
			}
			lv_main.ItemsSource = dos;
		}

		private void lv_main_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var todo = lv_main.SelectedItem as ToDo;
			if (todo != null)
			{
				NavigationService.Navigate(new EditToDoPage(todo));
			}
		}

		private void cb_Filters_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Filter();
		}

		private void cb_Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Filter();
		}

		private void Add_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new AddToDoPage());
		}
	}
}
