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
	/// Interaction logic for RegPage.xaml
	/// </summary>
	public partial class RegPage : Page
	{
		public RegPage()
		{
			InitializeComponent();
			
		}

		private void btn_back_Click(object sender, RoutedEventArgs e)
		{
			NavigationService.GoBack();
		}

		private void btn_reg_Click(object sender, RoutedEventArgs e)
		{
			User user = new User();
			if (txt_log.Text.Trim().Length != 0 && txt_pass.Password.Trim().Length != 0 && txt_Name.Text.Trim().Length != 0 && txt_Confpass.Password.Trim().Length != 0)
			{
				if (txt_pass.Password.Trim() == txt_Confpass.Password.Trim())
				{
					user.Name = txt_Name.Text.Trim();
					user.Login = txt_log.Text.Trim();
					user.Password = txt_pass.Password.Trim();
					user.ID_lvl = 1;
					user.Data = DateTime.Now;
					Bd_connection.tasksEntities.User.Add(user);
					Bd_connection.tasksEntities.SaveChanges();
					NavigationService.Navigate(new AuthorisPage());
				}
				else { MessageBox.Show("Что то пошло не так мудила"); }
			}
			else 
			{
				MessageBox.Show("не все поля заполнены сучка");
			}
		}
	}
}
