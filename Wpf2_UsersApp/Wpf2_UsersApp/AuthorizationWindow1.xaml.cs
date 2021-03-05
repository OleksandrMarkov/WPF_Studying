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
using System.Windows.Shapes;

namespace Wpf2_UsersApp
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow1.xaml
    /// </summary>
    public partial class AuthorizationWindow1 : Window
    {
        public AuthorizationWindow1()
        {
            InitializeComponent();
        }

        private void btn_sign_in_click(object sender, RoutedEventArgs e)
        {
            string login = text_box_login.Text.Trim();
            string password = text_box_password.Password.Trim();

            if (login.Length < 5)
            {
                text_box_login.ToolTip = "It can`t be less than 5 symbols!";
                text_box_login.Background = Brushes.Red;
            }
            if (password.Length < 5)
            {
                text_box_password.ToolTip = "It can`t be less than 5 symbols!";
                text_box_password.Background = Brushes.Red;
            }

            else
            {
                text_box_login.ToolTip = "";
                text_box_login.Background = Brushes.Transparent;

                text_box_password.ToolTip = "";
                text_box_password.Background = Brushes.Transparent;

                text_box_login.Text = "";
                text_box_password.Password = "";

                User auth_user = null;
                using (AppContext DB = new AppContext())
                {
                    auth_user = DB.Users.Where(someuser => someuser.Login == login && someuser.Password == password).FirstOrDefault();
                }

                if(auth_user != null)
                {
                    User_window uw = new User_window();
                    uw.Show();
                   // this.Hide();
                    this.Close();
                      
                    MessageBox.Show("all right!;)");
                }
                else
                {
                    MessageBox.Show(" :( ");
                }

                    
            }
        }

        private void btn_to_main_form_click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            //this.Hide();
            this.Close();
        }
    }
}
