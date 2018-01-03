using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimeFrequencyMeasurementSystem.Data;
using TimeFrequencyMeasurementSystem.Structs;

namespace TimeFrequencyMeasurementSystem.Forms.SubForm
{
    /// <summary>
    /// FrequencyReproducibilityForm.xaml 的交互逻辑
    /// </summary>
    public partial class FrequencyReproducibilityForm : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        public ObservableCollection<MeasurementFrequencyReproducibility> LstFrequencyReproducibility
        {
            get
            {
                return MeasurementData.LstFrequencyReproducibility;
            }
            set
            {
                MeasurementData.LstFrequencyReproducibility = value;
                Changed("LstFrequencyReproducibility");
            }
        }

        public FrequencyReproducibilityForm()
        {
            InitializeComponent();
            LstFrequencyReproducibility = new ObservableCollection<MeasurementFrequencyReproducibility>();
            this.DataContext = this;
        }

        private void ItmFrequencyReproducibilityRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridFrequencyReproducibility.SelectedIndex != -1)
            {
                MeasurementFrequencyReproducibility mfr = LstFrequencyReproducibility[dataGridFrequencyReproducibility.SelectedIndex];
                LstFrequencyReproducibility.Remove(mfr);
            }
        }

        private void BtnAddRecord6_Click(object sender, RoutedEventArgs e)
        {
            WindowFrequencyReproducibility windowFR = new WindowFrequencyReproducibility();
            if (windowFR.ShowDialog() == true)
            {
                MeasurementBase measurement = new MeasurementFrequencyReproducibility(windowFR.Now, windowFR.FrequencyI, windowFR.FrequencyII, windowFR.FrequencyStandard.ToString());
                LstFrequencyReproducibility.Add((MeasurementFrequencyReproducibility)measurement);
            }
        }
    }
}
