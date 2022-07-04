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
	/// Interaction logic for AddToDoPage.xaml
	/// </summary>
	public partial class AddToDoPage : Page
	{
		public AddToDoPage()
		{
			InitializeComponent();
			cb_XP.ItemsSource = Bd_connection.tasksEntities.CountXP.ToList();
			cb_XP.DisplayMemberPath = "Sum";
			this.DataContext = this;
			
		}

		private void btn_back_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new MainPage(MainPage.us));
		}

		private void btn_Save_Click(object sender, RoutedEventArgs e)
		{
			ToDo toDo = new ToDo();
			toDo.Name = txt_Name.Text;
			toDo.Desk = txt_Desk.Text;
			toDo.ID_CountXP = (cb_XP.SelectedItem as CountXP).ID_CountXP;
			toDo.DataComplite = dp_Date.SelectedDate;
			toDo.ID_Type = 2;
			toDo.ID_User = MainPage.us.ID_User;
			Bd_connection.tasksEntities.ToDo.Add(toDo);
			Bd_connection.tasksEntities.SaveChanges();
			NavigationService.Navigate(new MainPage(MainPage.us));
		}
	}
}
