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
    /// Логика взаимодействия для User_window.xaml
    /// </summary>
    public partial class User_window : Window
    {
        public User_window()
        {
            InitializeComponent();

            AppContext DB = new AppContext();
            List<User> users = DB.Users.ToList();

            users_list.ItemsSource = users;

        }
    }
}
