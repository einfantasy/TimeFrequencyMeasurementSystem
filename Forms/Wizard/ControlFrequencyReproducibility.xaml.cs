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

        private ObservableCollection<MeasurementFrequencyReproducibility> lstSelectedFrequencyReproducibility;
        public ObservableCollection<MeasurementFrequencyReproducibility> LstSelectedFrequencyReproducibility
        {
            get
            {
                return lstSelectedFrequencyReproducibility;
            }
            set
            {
                lstSelectedFrequencyReproducibility = value;
                Changed("LstSelectedFrequencyReproducibility");
            }
        }

        private MeasurementFrequencyReproducibility selectedAddItem;
        public MeasurementFrequencyReproducibility SelectedAddItem
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

        private MeasurementFrequencyReproducibility selectedRemoveItem;
        public MeasurementFrequencyReproducibility SelectedRemoveItem
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

        public ControlFrequencyReproducibility()
        {
            InitializeComponent();
            lstSelectedFrequencyReproducibility = new ObservableCollection<MeasurementFrequencyReproducibility>();
            this.DataContext = this;
            Add = new RelayCommand(AddItem);
            Remove = new RelayCommand(RemoveItem);
        }

        private void AddItem(object obj)
        {
            if (SelectedAddItem != null && !LstSelectedFrequencyReproducibility.Contains(SelectedAddItem))
                LstSelectedFrequencyReproducibility.Add(SelectedAddItem);
        }

        private void RemoveItem(object obj)
        {
            LstSelectedFrequencyReproducibility.Remove(SelectedRemoveItem);
        }
    }
}
