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
    /// FrequencyAccuracyFrom.xaml 的交互逻辑
    /// </summary>
    public partial class FrequencyAccuracyFrom : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        public ObservableCollection<MeasurementFrequencyAccuracy> LstFrequencyAccuracy
        {
            get
            {
                return MeasurementData.LstFrequencyAccuracy;
            }
            set
            {
                MeasurementData.LstFrequencyAccuracy = value;
                Changed("LstFrequencyAccuracy");
            }
        }
        public FrequencyAccuracyFrom()
        {
            InitializeComponent();
            LstFrequencyAccuracy = new ObservableCollection<MeasurementFrequencyAccuracy>();
            this.DataContext = this;
        }

        private void BtnAddRecord5_Click(object sender, RoutedEventArgs e)
        {
            WindowFrequencyAccuracy windowFA = new WindowFrequencyAccuracy();
            if (windowFA.ShowDialog() == true)
            {
                MeasurementBase measurement = new MeasurementFrequencyAccuracy(windowFA.Now, windowFA.FrequencyStandard.ToString(), windowFA.FrequencyActual);
                LstFrequencyAccuracy.Add((MeasurementFrequencyAccuracy)measurement);
            }
        }

        private void ItmFrequencyAccuracyRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridFrequencyAccuracy.SelectedIndex != -1)
            {
                MeasurementFrequencyAccuracy mfa = LstFrequencyAccuracy[dataGridFrequencyAccuracy.SelectedIndex];
                LstFrequencyAccuracy.Remove(mfa);
            }
        }
    }
}
