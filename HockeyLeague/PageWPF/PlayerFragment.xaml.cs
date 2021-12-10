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
    namespace PageWPF
    {
        /// <summary>
        /// Логика взаимодействия для PlayerFragment.xaml
        /// </summary>
        public partial class PlayerFragment : Page
        {
            public PlayerFragment()
            {
                InitializeComponent();
                DGridPlayer.ItemsSource = HockeyLeagueEntities.GetContext().Player.ToList();
                string role = Manager.Role;
                if (role == "User")
                {
                    addPlayer.IsEnabled = false;
                    delPlayer.IsEnabled = false;
                }
            }

            private void BtnEdit_Click(object sender, RoutedEventArgs e)
            {
                Manager._frame.Navigate(new AddPage.AddPlayer((sender as Image).DataContext as Player));
            }

            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Manager._frame.Navigate(new AddPage.AddPlayer((sender as Button).DataContext as Player));
            }

            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                var playerforRemoving = DGridPlayer.SelectedItems.Cast<Player>().ToList();
                if (MessageBox.Show($"Вы точно хотите удалить следующие {playerforRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        HockeyLeagueEntities.GetContext().Player.RemoveRange(playerforRemoving);
                        HockeyLeagueEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные удалены");

                        DGridPlayer.ItemsSource = HockeyLeagueEntities.GetContext().Player.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }

            private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
            {
                if (Visibility == Visibility.Visible)
                {
                    HockeyLeagueEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    DGridPlayer.ItemsSource = HockeyLeagueEntities.GetContext().Player.ToList();
                }

            }
        }
    }

}
