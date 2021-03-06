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

namespace HockeyLeague
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AutoLogin auto = new AutoLogin();
            auto.Close();
            Manager._frame = Frame;
            string role = Manager.Role;
            if (role == "User")
            {
                txtRole.Text = "Пользователь";
            }
            else
            {
                txtRole.Text = "Администратор";
            }
        }

        private void TeamClick(object sender, MouseButtonEventArgs e)
        {
            Manager._frame.Navigate(new PageWPF.TeamFragment());
        }

        private void PlayerClick(object sender, MouseButtonEventArgs e)
        {
            Manager._frame.Navigate(new PageWPF.PlayerFragment());
        }

        private void GameClick(object sender, MouseButtonEventArgs e)
        {
            Manager._frame.Navigate(new PageWPF.GameFragment());
        }

        private void InfoAboutGameClick(object sender, MouseButtonEventArgs e)
        {
            Manager._frame.Navigate(new PageWPF.InfoAboutGame());
        }

        private void canselGame_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Manager._frame.Navigate(new PageWPF.CanselGame());
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
