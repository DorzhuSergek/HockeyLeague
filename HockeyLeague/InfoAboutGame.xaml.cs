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
    /// Логика взаимодействия для InfoAboutGame.xaml
    /// </summary>
    public partial class InfoAboutGame : Page
    {
        public InfoAboutGame()
        {
            InitializeComponent();
            DGridInfo.ItemsSource = HockeyLeagueEntities.GetContext().Game_Account_Information.ToList();
            string role = Manager.Role;
            if (role == "User")
            {
                addInfo.IsEnabled = false;
                delInfo.IsEnabled = false;
            }


        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                HockeyLeagueEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridInfo.ItemsSource = HockeyLeagueEntities.GetContext().Game_Account_Information.ToList();
            }
        }

        private void BtnEdit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Manager._frame.Navigate(new AddInfo((sender as Image).DataContext as Game_Account_Information));
        }

        private void addInfo_Click(object sender, RoutedEventArgs e)
        {
            Manager._frame.Navigate(new AddInfo(null));
        }

        private void delInfo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
