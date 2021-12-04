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
    /// Логика взаимодействия для GameFragment.xaml
    /// </summary>
    public partial class GameFragment : Page
    {
        public GameFragment()
        {
            InitializeComponent();
            DGridGame.ItemsSource = HockeyLeagueEntities.GetContext().Game.ToList();
            string role = Manager.Role;
            if (role == "User")
            {
                addGame.IsEnabled = false;
                delGame.IsEnabled = false;
            }

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager._frame.Navigate(new AddGame((sender as Image).DataContext as Game));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager._frame.Navigate(new AddGame((sender as Button).DataContext as Game));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var gameforRemoving = DGridGame.SelectedItems.Cast<Game>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {gameforRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    HockeyLeagueEntities.GetContext().Game.RemoveRange(gameforRemoving);
                    HockeyLeagueEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DGridGame.ItemsSource = HockeyLeagueEntities.GetContext().Player.ToList();
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
                DGridGame.ItemsSource = HockeyLeagueEntities.GetContext().Game.ToList();
            }
        }
    }
}
