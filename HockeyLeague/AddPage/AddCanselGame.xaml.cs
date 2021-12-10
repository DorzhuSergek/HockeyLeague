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
    namespace AddPage
    {
        /// <summary>
        /// Логика взаимодействия для AddCanselGame.xaml
        /// </summary>
        public partial class AddCanselGame : Page
        {
            private Cause_cansel_game _currentCanselGame = new Cause_cansel_game();
            public AddCanselGame(Cause_cansel_game cause_Cansel_Game)
            {
                InitializeComponent();
                nameGame.ItemsSource = HockeyLeagueEntities.GetContext().Game.ToList();
                if (cause_Cansel_Game != null)
                    _currentCanselGame = cause_Cansel_Game;

                DataContext = _currentCanselGame;
            }

            private void BtnSave_Click(object sender, RoutedEventArgs e)
            {
                if (nameGame.Name == "" && Cause.Text == "" && Date.SelectedDate == null)
                {
                    if (_currentCanselGame.id == 0)
                    {
                        HockeyLeagueEntities.GetContext().Cause_cansel_game.Add(_currentCanselGame);
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
                    MessageBox.Show("Заполните поля", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
        }
    }
   
}
