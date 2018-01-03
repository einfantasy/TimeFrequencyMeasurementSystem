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
using TimeFrequencyMeasurementSystem.Functions;
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

        private MeasurementPhaseNoise selectedAddItem;
        public MeasurementPhaseNoise SelectedAddItem
        {
            get
            {
                return selectedAddItem;
            }
            set
            {
                selectedAddItem = value;
                Changed("SelectedAddItem");
            }
        }

        private MeasurementPhaseNoise selectedRemoveItem;
        public MeasurementPhaseNoise SelectedRemoveItem
        {
            get
            {
                return selectedRemoveItem;
            }
            set
            {
                selectedRemoveItem = value;
                Changed("SelectedRemoveItem");
            }
        }

        private ObservableCollection<MeasurementPhaseNoise> lstSelectedPhaseNoise;
        public ObservableCollection<MeasurementPhaseNoise> LstSelectedPhaseNoise
        {
            set
            {
                lstSelectedPhaseNoise = value;
                Changed("LstSelectedPhaseNoise");
            }
            get
            {
                return lstSelectedPhaseNoise;
            }
        }

        public ICommand Add { get; private set; }
        public ICommand Remove { get; private set; }

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
            lstSelectedPhaseNoise = new ObservableCollection<MeasurementPhaseNoise>();
            this.DataContext = this;
            Add = new RelayCommand(AddItem);
            Remove = new RelayCommand(RemoveItem);
        }

        private void AddItem(object obj)
        {
            if (SelectedAddItem != null && !LstSelectedPhaseNoise.Contains(SelectedAddItem))
                LstSelectedPhaseNoise.Add(SelectedAddItem);
        }

        private void RemoveItem(object obj)
        {
            LstSelectedPhaseNoise.Remove(SelectedRemoveItem);
        }
    }
}
