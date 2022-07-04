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
	/// Interaction logic for AuthorisPage.xaml
	/// </summary>
	public partial class AuthorisPage : Page
	{
		public AuthorisPage()
		{
			InitializeComponent();
		}

		private void btn_reg_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.Navigate(new RegPage());
		}

		private void btn_log_in_Click(object sender, RoutedEventArgs e)
		{
			if (txt_log.Text.Trim().Length != 0 && txt_pass.Password.Trim().Length != 0)
			{
				User user = new User();
				var z = Bd_connection.tasksEntities.User.ToList();
				user = z.Where(x => x.Login == txt_log.Text.Trim() && x.Password == txt_pass.Password.Trim()).FirstOrDefault();
				if (user != null)
				{
					NavigationService.Navigate(new MainPage(user));
				}
				else
				{
					MessageBox.Show("Логин или пароль неверны");
				}

			}
			else 
			{
				MessageBox.Show("Заполните все поля");
			}

		}
	}
}
