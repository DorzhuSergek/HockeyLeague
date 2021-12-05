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
using System.Windows.Shapes;

namespace HockeyLeague
{
    /// <summary>
    /// Логика взаимодействия для AutoLogin.xaml
    /// </summary>
    public partial class AutoLogin : Window
    {
        MainWindow mainWindow;
        public AutoLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            if (txtlogin.Text == "" || txtpassword.Password == "")
            {
                MessageBox.Show("Вы не ввели логин или пароль. Попробуйте ещё раз", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string login = txtlogin.Text;
            string password = txtpassword.Password;
            bool isCorrect = false;
            var logged = HockeyLeagueEntities.GetContext().LogUser(login, password).ToList();
            foreach (var u in logged)
            {

                if (HockeyLeagueEntities.GetContext().Roles.Find(u.id) != null)
                {
                    var role = HockeyLeagueEntities.GetContext().Roles.ToList().Where(x=>x.Roles1=="Manager" &&x.Login==login);
                    MessageBox.Show("Добро пожаловать, " + login.ToString());
                    if (role.ToList().Count()==1)
                    {
                        Manager.Role = "Manager";
                    }
                    else
                    {
                        Manager.Role = "User";
                    }
                    mainWindow = new MainWindow();
                    mainWindow.Show();
                    Close();
                    return;
                }
            }

            if (!isCorrect)
            {
                MessageBox.Show("Проверьте корректность ваших данных", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
