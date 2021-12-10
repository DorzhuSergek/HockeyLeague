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
        /// Логика взаимодействия для Team.xaml
        /// </summary>
        public partial class TeamFragment : Page
        {
            public TeamFragment()
            {
                InitializeComponent();
                DGrid.ItemsSource = HockeyLeagueEntities.GetContext().Team.ToList();
                string role = Manager.Role;
                if (role == "User")
                {
                    addTeam.IsEnabled = false;
                    delTeam.IsEnabled = false;
                }
            }

            private void BtnEdit_Click(object sender, RoutedEventArgs e)
            {
                Manager._frame.Navigate(new AddPage.AddTeam((sender as Image).DataContext as Team));
            }

            private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
            {
                if (Visibility == Visibility.Visible)
                {
                    HockeyLeagueEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    DGrid.ItemsSource = HockeyLeagueEntities.GetContext().Team.ToList();
                }
            }

            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Manager._frame.Navigate(new AddPage.AddTeam(null));
            }

            private void Delete_Click(object sender, RoutedEventArgs e)
            {
                var teamforRemoving = DGrid.SelectedItems.Cast<Team>().ToList();
                if (MessageBox.Show($"Вы точно хотите удалить следующие {teamforRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        HockeyLeagueEntities.GetContext().Team.RemoveRange(teamforRemoving);
                        HockeyLeagueEntities.GetContext().SaveChanges();
                        MessageBox.Show("Данные удалены");

                        DGrid.ItemsSource = HockeyLeagueEntities.GetContext().Team.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }

            private void search_TextChanged(object sender, TextChangedEventArgs e)
            {
                DGrid.ItemsSource = HockeyLeagueEntities.GetContext().Team.ToList().Where(x => x.Name.ToLower().Contains(search.Text.ToLower()));
            }
        }
    }

}
