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
    /// ControlFrequencyCount.xaml 的交互逻辑
    /// </summary>
    public partial class ControlFrequencyCount : ControlBase, INotifyPropertyChanged
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

        private MeasurementFrequencyCount selectedFrequencyCount;
        public MeasurementFrequencyCount SelectedFrequencyCount
        {
            get
            {
                return selectedFrequencyCount;
            }
            set
            {
                selectedFrequencyCount = value;
                TxtSelectedItem = string.Format("{0}, {1}", selectedFrequencyCount.Now, selectedFrequencyCount.Frequency);
                Changed("SelectedFrequencyCount");
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

        public ControlFrequencyCount()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
