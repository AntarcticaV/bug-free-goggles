using Sky_Wings_Airline.Entity;
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
using Sky_Wings_Airline.Windows;

namespace Sky_Wings_Airline
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void buttonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            var timer = DateTime.Now;
            
                using (var bd = new Sky_Wings_AirlineEntities())
                {
                    var user = bd.Staff.Where(em => em.Login == textBoxLogin.Text).FirstOrDefault();
                    if (user != null && user.Password == passwordBox.Password)
                    {
                        switch (user.IDRole)
                        {
                            case 1:
                                break;
                            case 2:
                                break;
                            case 3:
                                var oper = new OperatorWindows();
                                oper.Show();
                                this.Close();
                                break;
                            case 4:
                                break;
                            case 5:
                                var admin = new AdminWindow();
                                admin.Show();
                                this.Close();
                                break;
                        }
                    }
                    else
                    {
                        textBlockError.Text = "Неверный логин или пароль";
                    }
                }
            
        }
    }
}
