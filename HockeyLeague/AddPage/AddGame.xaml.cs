using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
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
    namespace AddPage
    {
        /// <summary>
        /// Логика взаимодействия для AddGame.xaml
        /// </summary>
        public partial class AddGame : Page
        {
            private Game _currentGame = new Game();
            public AddGame(Game gameSelected)
            {


                InitializeComponent();
                HostTeam.ItemsSource = HockeyLeagueEntities.GetContext().Team.ToList();
                GuestTeam.ItemsSource = HockeyLeagueEntities.GetContext().TeamTwo.ToList();



                if (gameSelected != null)
                    _currentGame = gameSelected;

                DataContext = _currentGame;

            }

            private void BtnSave_Click(object sender, RoutedEventArgs e)
            {
                if(HostTeam.SelectedItem!=null&&GuestTeam.SelectedItem!=null&&!String.IsNullOrWhiteSpace(countHost.Text)&&!String.IsNullOrWhiteSpace(countGuest.Text)&& !String.IsNullOrWhiteSpace(city.Text) && DateGame.SelectedDate != null)
                {
                    if (_currentGame.id == 0)
                    {
                        HockeyLeagueEntities.GetContext().Game.Add(_currentGame);
                    }
                    try
                    {
                        HockeyLeagueEntities.GetContext().SaveChanges();
                        MessageBox.Show("Информация сохранена");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Заполните поля");
                }
               
            }

            private void HostTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {

            }

            private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
            {
                if (!Char.IsDigit(e.Text, 0))
                {
                    e.Handled = true;
                }
            }
        }
    }

}
