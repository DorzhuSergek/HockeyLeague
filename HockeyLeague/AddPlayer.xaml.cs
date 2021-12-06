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
    /// Логика взаимодействия для AddPlayer.xaml
    /// </summary>
    public partial class AddPlayer : Page
    {
        private Player _currentPlayer = new Player();

        public AddPlayer(Player selectedTeam)
        {
            InitializeComponent();
            ComboTeam.ItemsSource = HockeyLeagueEntities.GetContext().Team.ToList();
            if (selectedTeam != null)
                _currentPlayer = selectedTeam;

            DataContext = _currentPlayer;
            List<string> position = new List<string>();
            position.Add("Вратарь");
            position.Add("Защитник");
            position.Add("Нападающий");
            cmbPosition.ItemsSource = position;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPlayer.id == 0)
            {
                HockeyLeagueEntities.GetContext().Player.Add(_currentPlayer);
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

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
