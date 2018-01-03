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

namespace TimeFrequencyMeasurementSystem.Forms.Wizard
{
    /// <summary>
    /// ControlFrequencyReproducibility.xaml 的交互逻辑
    /// </summary>
    public partial class ControlFrequencyReproducibility : ControlBase, INotifyPropertyChanged
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
        }

        private MeasurementFrequencyReproducibility selectedItem;
        public MeasurementFrequencyReproducibility SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                TxtSelectedItem = string.Format("{0}, {1}, {2}, {3}, {4}", selectedItem.Now, selectedItem.FrequencyI, selectedItem.FrequencyII, selectedItem.FrequencyStandard, selectedItem.Reproducibility);
                Changed("SelectedItem");
            }
        }

        private string txtSelectedItem;
        public string TxtSelectedItem
        {
            get
            {
                return txtSelectedItem;
            }
            set
            {
                txtSelectedItem = value;
                Changed("TxtSelectedItem");
            }
        }

        public ControlFrequencyReproducibility()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
