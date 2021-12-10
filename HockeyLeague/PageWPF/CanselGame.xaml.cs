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
        /// Логика взаимодействия для CanselGame.xaml
        /// </summary>
        public partial class CanselGame : Page
        {
            public CanselGame()
            {
                InitializeComponent();

                DGridCanselGame.ItemsSource = HockeyLeagueEntities.GetContext().Cause_cansel_game.ToList();
                string role = Manager.Role;
                if (role == "User")
                {
                    addCanselGme.IsEnabled = false;
                    delCanselGame.IsEnabled = false;
                }
            }

            private void BtnEdit_Click(object sender, RoutedEventArgs e)
            {
                Manager._frame.Navigate(new AddPage.AddCanselGame((sender as Image).DataContext as Cause_cansel_game));
            }

            private void addCanselGme_Click(object sender, RoutedEventArgs e)
            {
                Manager._frame.Navigate(new AddPage.AddCanselGame(null));
            }

            private void delCanselGame_Click(object sender, RoutedEventArgs e)
            {
                var canselGameforRemoving = DGridCanselGame.SelectedItems.Cast<Cause_cansel_game>().ToList();
                if (MessageBox.Show($"Вы точно хотите удалить следующие {canselGameforRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        HockeyLeagueEntities.GetContext().Cause_cansel_game.RemoveRange(canselGameforRemoving);
                        HockeyLeagueEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные удалены");

                        DGridCanselGame.ItemsSource = HockeyLeagueEntities.GetContext().Cause_cansel_game.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }
    }

}
