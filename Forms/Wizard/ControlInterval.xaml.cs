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
    /// ControlInterval.xaml 的交互逻辑
    /// </summary>
    public partial class ControlInterval : ControlBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        public ObservableCollection<MeasurementInterval> LstInterval
        {
            get
            {
                return MeasurementData.LstInterval;
            }
        }

        private ObservableCollection<MeasurementInterval> lstSelectedInterval;
        public ObservableCollection<MeasurementInterval> LstSelectedInterval
        {
            get
            {
                return lstSelectedInterval;
            }
            set
            {
                lstSelectedInterval = value;
                Changed("LstSelectedInterval");
            }
        }

        private MeasurementInterval selectedAddItem;
        public MeasurementInterval SelectedAddItem
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

        private MeasurementInterval selectedRemoveItem;
        public MeasurementInterval SelectedRemoveItem
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

        public ControlInterval()
        {
            InitializeComponent();
            lstSelectedInterval = new ObservableCollection<MeasurementInterval>();
            this.DataContext = this;
            Add = new RelayCommand(AddItem);
            Remove = new RelayCommand(RemoveItem);
        }

        private void AddItem(object obj)
        {
            if (SelectedAddItem != null && !LstSelectedInterval.Contains(SelectedAddItem))
                LstSelectedInterval.Add(SelectedAddItem);
        }

        private void RemoveItem(object obj)
        {
            LstSelectedInterval.Remove(SelectedRemoveItem);
        }
    }
}
