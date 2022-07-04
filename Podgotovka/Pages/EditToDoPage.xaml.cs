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
	/// Interaction logic for EditToDoPage.xaml
	/// </summary>
	public partial class EditToDoPage : Page
	{
		public EditToDoPage(ToDo todo)
		{
			InitializeComponent();
			txt_Name.Text = todo.Name;
			txt_Desk.Text = todo.Desk;
			cb_XP.Text = todo.CountXP.Sum.ToString();
			dp_Date.Text = todo.DataComplite.ToString();
			cb_Type.ItemsSource = Bd_connection.tasksEntities.Type.ToList();
			cb_Type.DisplayMemberPath = "Name";
			cb_Type.SelectedItem = Bd_connection.tasksEntities.Type.Where(x=> x.ID_Type == todo.ID_Type).FirstOrDefault();

		}
		private void btn_back_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new MainPage(MainPage.us));
		}

		private void btn_Save_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
