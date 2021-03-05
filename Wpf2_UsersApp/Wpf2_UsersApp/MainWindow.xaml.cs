﻿using System;
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

namespace Wpf2_UsersApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_sign_in_click(object sender, RoutedEventArgs e)
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
            }
        }
    }
}
