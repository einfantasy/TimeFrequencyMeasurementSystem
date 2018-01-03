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
    /// ControlFrequencyAccuracy.xaml 的交互逻辑
    /// </summary>
    public partial class ControlFrequencyAccuracy : ControlBase, INotifyPropertyChanged
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
        }

        private ObservableCollection<MeasurementFrequencyAccuracy> lstSelectedFrequencyAccuracy;
        public ObservableCollection<MeasurementFrequencyAccuracy> LstSelectedFrequencyAccuracy
        {
            get
            {
                return lstSelectedFrequencyAccuracy;
            }
            set
            {
                lstSelectedFrequencyAccuracy = value;
                Changed("LstSelectedFrequencyAccuracy");
            }
        }

        private MeasurementFrequencyAccuracy selectedAddItem;
        public MeasurementFrequencyAccuracy SelectedAddItem
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

        private MeasurementFrequencyAccuracy selectedRemoveItem;
        public MeasurementFrequencyAccuracy SelectedRemoveItem
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

        public ControlFrequencyAccuracy()
        {
            InitializeComponent();
            lstSelectedFrequencyAccuracy = new ObservableCollection<MeasurementFrequencyAccuracy>();
            this.DataContext = this;
            Add = new RelayCommand(AddItem);
            Remove = new RelayCommand(RemoveItem);
        }

        private void AddItem(object obj)
        {
            if (SelectedAddItem != null && !LstSelectedFrequencyAccuracy.Contains(SelectedAddItem))
                LstSelectedFrequencyAccuracy.Add(SelectedAddItem);
        }

        private void RemoveItem(object obj)
        {
            LstSelectedFrequencyAccuracy.Remove(SelectedRemoveItem);
        }
    }
}
