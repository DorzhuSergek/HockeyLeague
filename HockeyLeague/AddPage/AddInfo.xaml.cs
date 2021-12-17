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
        /// Логика взаимодействия для AddInfo.xaml
        /// </summary>
        public partial class AddInfo : Page
        {
            private Game_Account_Information _Info = new Game_Account_Information();
            public AddInfo(Game_Account_Information selectedInfo)
            {
                InitializeComponent();
                cmbPlayer.ItemsSource = HockeyLeagueEntities.GetContext().Player.ToList();
                cmbGame.ItemsSource = HockeyLeagueEntities.GetContext().Game.ToList();
                if (selectedInfo != null)
                {
                    _Info = selectedInfo;
                }
                DataContext = _Info;
            }

            private void BtnSave_Click(object sender, RoutedEventArgs e)
            {
                if (cmbPlayer.SelectedItem != null && !String.IsNullOrWhiteSpace(time.Text) && cmbGame.SelectedItem != null)
                {
                    if (_Info.ID == 0)
                    {
                        HockeyLeagueEntities.GetContext().Game_Account_Information.Add(_Info);
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
        }
    }

}
