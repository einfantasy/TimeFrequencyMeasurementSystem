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
    /// ControlShortTermStability.xaml 的交互逻辑
    /// </summary>
    public partial class ControlShortTermStability : ControlBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        public ObservableCollection<MeasurementShortTermStability> LstShortTermStability
        {
            get
            {
                return MeasurementData.LstShortTermStability;
            }
        }

        private ObservableCollection<MeasurementShortTermStability> lstSelectedShortTermStability;
        public ObservableCollection<MeasurementShortTermStability> LstSelectedShortTermStability
        {
            get
            {
                return lstSelectedShortTermStability;
            }
            set
            {
                lstSelectedShortTermStability = value;
                Changed("LstSelectedShortTermStability");
            }
        }

        private MeasurementShortTermStability selectedAddItem;
        public MeasurementShortTermStability SelectedAddItem
        {
            get
            {
                return selectedAddItem;
            }
            set
            {
                selectedAddItem = value;
                Changed("SelectedItem");
            }
        }

        private MeasurementShortTermStability selectedRemoveItem;
        public MeasurementShortTermStability SelectedRemoveItem
        {
            get
            {
                return selectedRemoveItem;
            }
            set
            {
                selectedRemoveItem = value;
                Changed("SelectedItem");
            }
        }

        public BitmapImage SelectedImage
        {
            get
            {
                return MeasurementData.ImgShortTermStability;
            }
        }

        public ICommand Add { get; private set; }
        public ICommand Remove { get; private set; }

        public ControlShortTermStability()
        {
            InitializeComponent();
            lstSelectedShortTermStability = new ObservableCollection<MeasurementShortTermStability>();
            this.DataContext = this;
            Add = new RelayCommand(AddItem);
            Remove = new RelayCommand(RemoveItem);
        }

        private void AddItem(object obj)
        {
            if (SelectedAddItem != null && !lstSelectedShortTermStability.Contains(SelectedAddItem))
                lstSelectedShortTermStability.Add(SelectedAddItem);
        }

        private void RemoveItem(object obj)
        {
            lstSelectedShortTermStability.Remove(SelectedRemoveItem);
        }
    }
}
