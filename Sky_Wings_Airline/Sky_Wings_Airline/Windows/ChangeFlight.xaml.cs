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
using Sky_Wings_Airline.Entity;

namespace Sky_Wings_Airline.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChangeFlight.xaml
    /// </summary>
    public partial class ChangeFlight : Window
    {
        public Flight _flight;
        public ChangeFlight(Flight flight)
        {
            InitializeComponent();
            _flight = flight;
            LoadDataForm();
            StartData();
        }

        public void LoadDataForm()
        {
            using (var bd = new Sky_Wings_AirlineEntities())
            {
                foreach (var val in bd.Airport)
                {
                    comboBoxDepartureAirport.Items.Add(val.NameAirport);
                    comboBoxArrivalAirport.Items.Add(val.NameAirport);
                }

                foreach (var val in bd.Planes)
                {
                    comboBoxPlane.Items.Add(val.Name);
                }

                foreach (var val in bd.Staff)
                {
                    if (val.IDRole == 1)
                    {
                        comboBoxFirstPilot.Items.Add(val.Surname);
                        comboBoxSecondPilot.Items.Add(val.Surname);
                    }
                }
            }
        }

        public bool CheckNotNull()
        {
            bool flag = false;
            if (comboBoxArrivalAirport.SelectedItem != null)
                if (comboBoxDepartureAirport.SelectedItem != null)
                    if (datePickerArrivalDate.SelectedDate != null)
                        if (datePickerDepartureDate.SelectedDate != null)
                            if (comboBoxPlane.SelectedItem != null)
                                if (comboBoxFirstPilot.SelectedItem != null)
                                    if (comboBoxSecondPilot.SelectedItem != null)
                                        flag = true;

            return flag;
        }

        public void StartData()
        {
            using (var bd = new Sky_Wings_AirlineEntities())
            {
                comboBoxDepartureAirport.SelectedItem = bd.Airport.FirstOrDefault(o => o.ID == _flight.IDDepartureAirport).NameAirport;
                comboBoxArrivalAirport.SelectedItem = bd.Airport.FirstOrDefault(o=>o.ID == _flight.IDArrivalAirport).NameAirport;
                datePickerArrivalDate.Text = _flight.ArrivalDate.ToString();
                datePickerDepartureDate.Text = _flight.DepartureDate.ToString();
                comboBoxPlane.SelectedItem = bd.Planes.FirstOrDefault(o => o.ID == _flight.IDPlane).Name;
                comboBoxFirstPilot.SelectedItem = bd.Staff.FirstOrDefault(o=>o.ID == _flight.IDFirstPilot).Surname;
                comboBoxSecondPilot.SelectedItem = bd.Staff.FirstOrDefault(o => o.ID == _flight.IDSecondPilot).Surname;
            }
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (datePickerDepartureDate.SelectedDate <= datePickerArrivalDate.SelectedDate && CheckNotNull())
            {
                using (var bd = new Sky_Wings_AirlineEntities())
                {
                    var flight = bd.Flight.FirstOrDefault(o => o.ID == _flight.ID);
                    flight.IDArrivalAirport = bd.Airport
                        .FirstOrDefault(o => o.NameAirport == comboBoxArrivalAirport.SelectedItem).ID;
                    flight.IDDepartureAirport = bd.Airport
                        .FirstOrDefault(o => o.NameAirport == comboBoxDepartureAirport.SelectedItem).ID;
                    flight.ArrivalDate = datePickerArrivalDate.SelectedDate;
                    flight.DepartureDate = (DateTime)datePickerDepartureDate.SelectedDate;
                    flight.IDPlane = bd.Planes.FirstOrDefault(o => o.Name == comboBoxPlane.SelectedItem).ID;
                    flight.IDFirstPilot = bd.Staff.FirstOrDefault(o => o.Surname == comboBoxFirstPilot.SelectedItem).ID;
                    flight.IDSecondPilot =
                        bd.Staff.FirstOrDefault(o => o.Surname == comboBoxSecondPilot.SelectedItem).ID;
                    bd.SaveChanges();
                }

                this.Close();
            }
        }

        private void comboBoxDepartureAirport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxDepartureAirport.SelectedIndex == comboBoxArrivalAirport.SelectedIndex)
            {
                comboBoxDepartureAirport.SelectedIndex = -1;
            }
        }

        private void comboBoxArrivalAirport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxDepartureAirport.SelectedIndex == comboBoxArrivalAirport.SelectedIndex)
            {
                comboBoxArrivalAirport.SelectedIndex = -1;
            }
        }

        private void comboBoxFirstPilot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxFirstPilot.SelectedIndex == comboBoxSecondPilot.SelectedIndex)
            {
                comboBoxFirstPilot.SelectedIndex = -1;
            }
        }

        private void comboBoxSecondPilot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxFirstPilot.SelectedIndex == comboBoxSecondPilot.SelectedIndex)
            {
                comboBoxSecondPilot.SelectedIndex = -1;
            }
        }
    }
}
