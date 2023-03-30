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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Sky_Wings_Airline.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddFlightWindows.xaml
    /// </summary>
    public partial class AddFlightWindows : Window
    {
        public AddFlightWindows()
        {
            InitializeComponent();
            LoadDataForm();
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
                    var flight = new Flight
                    {
                        IDArrivalAirport = bd.Airport
                            .FirstOrDefault(o => o.NameAirport == comboBoxArrivalAirport.SelectedItem).ID,
                        IDDepartureAirport =
                        bd.Airport.FirstOrDefault(o => o.NameAirport == comboBoxDepartureAirport.SelectedItem).ID,
                        ArrivalDate = datePickerArrivalDate.SelectedDate,
                        DepartureDate = (DateTime)datePickerDepartureDate.SelectedDate,
                        IDPlane = bd.Planes.FirstOrDefault(o => o.Name == comboBoxPlane.SelectedItem).ID,
                        IDFirstPilot = bd.Staff.FirstOrDefault(o => o.Surname == comboBoxFirstPilot.SelectedItem).ID,
                        IDSecondPilot =
                        bd.Staff.FirstOrDefault(o => o.Surname == comboBoxSecondPilot.SelectedItem).ID,
                        Status = bd.Status.FirstOrDefault(o=>o.ID==1)
                    };
                    bd.Flight.Add(flight);
                    bd.SaveChanges();
                }
                this.Close();
            }
        }

        public bool CheckNotNull()
        {
            bool flag = false;
            if (comboBoxArrivalAirport.SelectedItem != null )
                if (comboBoxDepartureAirport.SelectedItem != null) 
                    if(datePickerArrivalDate.SelectedDate != null)
                        if (datePickerDepartureDate.SelectedDate != null)
                            if(comboBoxPlane.SelectedItem != null)
                                if(comboBoxFirstPilot.SelectedItem != null)
                                    if (comboBoxSecondPilot.SelectedItem != null)
                                        flag = true;

            return flag;
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
