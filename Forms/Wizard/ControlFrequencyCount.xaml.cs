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
        }

        private ObservableCollection<MeasurementFrequencyCount> lstSelectedFrequencyCount;
        public ObservableCollection<MeasurementFrequencyCount> LstSelectedFrequencyCount
        {
            get
            {
                return lstSelectedFrequencyCount;
            }
            set
            {
                lstSelectedFrequencyCount = value;
                Changed("LstSelectedFrequencyCount");
            }
        }

        private MeasurementFrequencyCount selectedAddItem;
        public MeasurementFrequencyCount SelectedAddItem
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

        private MeasurementFrequencyCount selectedRemoveItem;
        public MeasurementFrequencyCount SelectedRemoveItem
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

        public ICommand Add { get; private set; }
        public ICommand Remove { get; private set; }

        public ControlFrequencyCount()
        {
            InitializeComponent();
            lstSelectedFrequencyCount = new ObservableCollection<MeasurementFrequencyCount>();
            this.DataContext = this;
            Add = new RelayCommand(AddItem);
            Remove = new RelayCommand(RemoveItem);
        }

        private void AddItem(object obj)
        {
            if(SelectedAddItem != null && !LstSelectedFrequencyCount.Contains(SelectedAddItem))
                LstSelectedFrequencyCount.Add(SelectedAddItem);
        }

        private void RemoveItem(object obj)
        {
            LstSelectedFrequencyCount.Remove(SelectedRemoveItem);
        }
    }
}
