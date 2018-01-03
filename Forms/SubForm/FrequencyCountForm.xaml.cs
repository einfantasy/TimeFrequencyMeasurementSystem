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
    /// FrequencyCountForm.xaml 的交互逻辑
    /// </summary>
    public partial class FrequencyCountForm : UserControl, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        public ObservableCollection<MeasurementFrequencyCount> LstFrequencyCount
        {
            get
            {
                return MeasurementData.LstFrequencyCount;
            }
            set
            {
                MeasurementData.LstFrequencyCount = value;
                Changed("LstFrequencyCount");
            }
        }

        public FrequencyCountForm()
        {
            InitializeComponent();
            LstFrequencyCount = new ObservableCollection<MeasurementFrequencyCount>();
            this.DataContext = this;
        }
        private void BtnAddRecord1_Click(object sender, RoutedEventArgs e)
        {
            WindowFrequencyCount windowFC = new WindowFrequencyCount();
            if (windowFC.ShowDialog() == true)
            {
                MeasurementBase measurement = new MeasurementFrequencyCount(windowFC.Now, windowFC.Frequency);
                LstFrequencyCount.Add((MeasurementFrequencyCount)measurement);
            }
        }

        private void ItmFrequencyCountRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridFrequencyCount.SelectedIndex != -1)
            {
                MeasurementFrequencyCount mfc = LstFrequencyCount[dataGridFrequencyCount.SelectedIndex];
                LstFrequencyCount.Remove(mfc);
            }
        }
        
    }
}
