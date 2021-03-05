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

using System.Windows.Media.Animation; // animation

namespace Wpf2_UsersApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppContext DB;

        public MainWindow()
        {
            InitializeComponent();

            DB = new AppContext();

            // BUTTON'S ANIMATION
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = 450;
            animation.Duration = TimeSpan.FromSeconds(3);
            btn_sign_up.BeginAnimation(Button.WidthProperty, animation);

           
            /* TEST OF ADDING TO DB
            * List<User> Users = DB.Users.ToList();
            string str = "";

            foreach (User user in Users)
            {
                str += "Login: " + user.Login + "; ";
            }

            test_text.Text = str;*/
        }

        private void btn_sign_up_click(object sender, RoutedEventArgs e)
        {
            string login = text_box_login.Text.Trim();
            string password = text_box_password.Password.Trim();
            string password2 = text_box_password2.Password.Trim();
            string email = text_box_email.Text.Trim().ToLower();

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
            if (password != password2 || password2 == "")
            {
                text_box_password2.ToolTip = "Password is wrong confirmed!";
                text_box_password2.Background = Brushes.Red;
            }
            if (email.Length < 5 || ! email.Contains("@") || ! email.Contains("."))
            {
                text_box_email.ToolTip = "Wrong email value!";
                text_box_email.Background = Brushes.Red;
            }
            else
            {
                text_box_login.ToolTip = "";
                text_box_login.Background = Brushes.Transparent;

                text_box_password.ToolTip = "";
                text_box_password.Background = Brushes.Transparent;

                text_box_password2.ToolTip = "";
                text_box_password2.Background = Brushes.Transparent;

                text_box_email.ToolTip = "";
                text_box_email.Background = Brushes.Transparent;

                //fields clearing
                text_box_login.Text = "";
                text_box_password.Password = "";
                text_box_password2.Password = "";
                text_box_email.Text = "";

                MessageBox.Show("all right!;)");

                User user = new User(login, email, password);

                DB.Users.Add(user);
                DB.SaveChanges();

                AuthorizationWindow1 window = new AuthorizationWindow1();
                window.Show();
                //this.Hide();
                this.Close();
            }
        }

        private void btn_to_auth_form_click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow1 window = new AuthorizationWindow1();
            window.Show();
            //this.Hide();
            this.Close();
        }
    }
}
