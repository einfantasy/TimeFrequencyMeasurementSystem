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
    /// ControlPhaseNoise.xaml 的交互逻辑
    /// </summary>
    public partial class ControlPhaseNoise : ControlBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        public ObservableCollection<MeasurementPhaseNoise> LstPhaseNoise
        {
            get
            {
                return MeasurementData.LstPhaseNoise;
            }
        }

        private MeasurementPhaseNoise selectedItem;
        public MeasurementPhaseNoise SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                TxtSelectedItem = string.Format("{0}, {1}, {2}", selectedItem.Now, selectedItem.FrequencyOffset, selectedItem.Noise);
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

        public BitmapImage SelectedImage
        {
            get
            {
                return MeasurementData.ImgPhaseNoise;
            }
        }

        public ControlPhaseNoise()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
