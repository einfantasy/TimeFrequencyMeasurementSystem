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
    /// ControlBootFeature.xaml 的交互逻辑
    /// </summary>
    public partial class ControlBootFeature : ControlBase, INotifyPropertyChanged
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
        }

        private ObservableCollection<MeasurementBootFeature> lstSelectedBootFeature;
        public ObservableCollection<MeasurementBootFeature> LstSelectedBootFeature
        {
            get
            {
                return lstSelectedBootFeature;
            }
            set
            {
                lstSelectedBootFeature = value;
                Changed("LstSelectedBootFeature");
            }
        }

        private MeasurementBootFeature selectedAddItem;
        public MeasurementBootFeature SelectedAddItem
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

        private MeasurementBootFeature selectedRemoveItem;
        public MeasurementBootFeature SelectedRemoveItem
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

        public ControlBootFeature()
        {
            InitializeComponent();
            lstSelectedBootFeature = new ObservableCollection<MeasurementBootFeature>();
            this.DataContext = this;
            Add = new RelayCommand(AddItem);
            Remove = new RelayCommand(RemoveItem);
        }

        private void AddItem(object obj)
        {
            if (SelectedAddItem != null && !LstSelectedBootFeature.Contains(SelectedAddItem))
                LstSelectedBootFeature.Add(SelectedAddItem);
        }

        private void RemoveItem(object obj)
        {
            LstSelectedBootFeature.Remove(SelectedRemoveItem);
        }
    }
}
