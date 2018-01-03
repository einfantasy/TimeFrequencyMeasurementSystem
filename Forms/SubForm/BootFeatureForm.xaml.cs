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
    /// BootFeatureForm.xaml 的交互逻辑
    /// </summary>
    public partial class BootFeatureForm : UserControl, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        public ObservableCollection<MeasurementBootFeature> LstBootFeature
        {
            get
            {
                return MeasurementData.LstBootFeature;
            }
            set
            {
                MeasurementData.LstBootFeature = value;
                Changed("LstBootFeature");
            }
        }


        public BootFeatureForm()
        {
            InitializeComponent();
            LstBootFeature = new ObservableCollection<MeasurementBootFeature>();
            this.DataContext = this;
        }

        
      

        private void ItmBootFeatureRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridBootFeature.SelectedIndex != -1)
            {
                MeasurementBootFeature mbf = LstBootFeature[dataGridBootFeature.SelectedIndex];
                LstBootFeature.Remove(mbf);
            }
        }

        private void BtnAddRecord2_Click(object sender, RoutedEventArgs e)
        {
            WindowBootFeature windowBF = new WindowBootFeature();
            if (windowBF.ShowDialog() == true)
            {
                MeasurementBase measurement = new MeasurementBootFeature(windowBF.Now, windowBF.FrequencyBoot, windowBF.FrequencyStable, windowBF.FrequencyStandard.ToString());
                LstBootFeature.Add((MeasurementBootFeature)measurement);
            }
        }

    }



}
