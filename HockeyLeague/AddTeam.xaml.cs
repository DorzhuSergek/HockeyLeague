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
    /// Логика взаимодействия для AddTeam.xaml
    /// </summary>
    public partial class AddTeam : Page
    {
        private Team _currentTeam = new Team();
        public AddTeam(Team selectedTeam)
        {
            InitializeComponent();

            if (selectedTeam != null)
                _currentTeam = selectedTeam;
            
            DataContext = _currentTeam;

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (NameTeam.Text == "" && couchSurname.Text == "" && City.Text == "" && couchSurname.Text == "")
            {
                if (_currentTeam.id == 0)
                {
                    HockeyLeagueEntities.GetContext().Team.Add(_currentTeam);
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
