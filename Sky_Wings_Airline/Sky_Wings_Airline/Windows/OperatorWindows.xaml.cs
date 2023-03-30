using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using Sky_Wings_Airline.additional_class;
using Sky_Wings_Airline.Entity;

namespace Sky_Wings_Airline.Windows
{
    /// <summary>
    /// Логика взаимодействия для OperatorWindows.xaml
    /// </summary>
    public partial class OperatorWindows : Window
    {
        public OperatorWindows()
        {
            InitializeComponent();
            LoadGrid();
        }

        public void LoadGrid()
        {
            dataGrid.Items.Clear();
            using (var bd = new Sky_Wings_AirlineEntities())
            {
                bd.Staff.Load();
                bd.Planes.Load();
                bd.Airport.Load();
                bd.Status.Load();
                bd.Role.Load();

                foreach (var val in bd.Flight.ToList())
                {
                    var gg = new DataGritFlight()
                    {
                        ID = val.ID,
                        DepartureAirport = bd.Airport.FirstOrDefault(o => o.ID == val.IDDepartureAirport)?.NameAirport,
                        ArrivalAirport = bd.Airport.FirstOrDefault(o => o.ID == val.IDArrivalAirport)?.NameAirport,
                        Plane = bd.Planes.FirstOrDefault(o => o.ID == val.IDPlane)?.Name,
                        DepartureDate = val.DepartureDate,
                        ArrivalDate = val.ArrivalDate,
                        Status = bd.Status.FirstOrDefault(o => o.ID == val.IDStatus)?.Title,
                        SurnameFirstPilot = bd.Staff.FirstOrDefault(o => o.ID == val.IDFirstPilot)?.Surname,
                        SurnameSecondPilot = bd.Staff.FirstOrDefault(o => o.ID == val.IDSecondPilot)?.Surname
                    };
                    dataGrid.Items.Add(gg);
                }

            }
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            var main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void buttonDeleteFlight_Click(object sender, RoutedEventArgs e)
        {
            DataGritFlight flight = (DataGritFlight)dataGrid.SelectedItem;
            if (flight != null && flight.Status == "Рейс отменён")
            {
                using (var bd = new Sky_Wings_AirlineEntities())
                {
                    bd.Flight.Remove(bd.Flight.FirstOrDefault(o => o.ID == flight.ID));
                    bd.Flight_Attendant_List.Remove(
                        bd.Flight_Attendant_List.FirstOrDefault(o => o.IDFlight == flight.ID));
                    bd.Passenger_List.Remove(bd.Passenger_List.FirstOrDefault(o => o.IDFlight == flight.ID));
                    bd.SaveChanges();
                }

                LoadGrid();
            }
        }

        private void buttonChangeFlight_Click(object sender, RoutedEventArgs e)
        {
            DataGritFlight flight = (DataGritFlight)dataGrid.SelectedItem;
            if (flight != null && (flight.Status == "Рейс отменён" || flight.Status == "Ожидает согласования"))
            {
                using (var bd = new Sky_Wings_AirlineEntities())
                {
                    var change = new ChangeFlight(bd.Flight.FirstOrDefault(o => o.ID == flight.ID));
                    change.ShowDialog();
                }
            }
            LoadGrid();
        }

        private void buttonAddFlight_Click(object sender, RoutedEventArgs e)
        {
         
            var add = new AddFlightWindows();
            add.ShowDialog();
        
            LoadGrid();
        }
    }
}
