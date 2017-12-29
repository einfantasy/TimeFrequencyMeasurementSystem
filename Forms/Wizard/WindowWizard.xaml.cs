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
using System.Windows.Shapes;
using TimeFrequencyMeasurementSystem.Structs;

namespace TimeFrequencyMeasurementSystem.Forms.Wizard
{
    /// <summary>
    /// WindowWizard.xaml 的交互逻辑
    /// </summary>
    public partial class WindowWizard : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        private List<ControlBase> lstControls = new List<ControlBase>();

        private int index = 0;
        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                index = value;
                if (index == 0)
                    BPrevEnable = false;
                else
                    BPrevEnable = true;

                if (index == lstControls.Count - 1)
                    BtnNext.Content = "完成";
                else
                    BtnNext.Content = "下一步";
            }
        }

        private bool bPrevEnable = false;
        public bool BPrevEnable
        {
            get
            {
                return bPrevEnable;
            }
            set
            {
                bPrevEnable = value;
                OnPropertyChanged("BPrevEnable");
            }
        }

        private bool bNextEnable = true;
        public bool BNextEnable
        {
            get
            {
                return bNextEnable;
            }
            set
            {
                bNextEnable = value;
                OnPropertyChanged("BNextEnable");
            }
        }

        ControlOverview controlOverview;
        ControlFrequencyCount controlFrequencyCount;
        ControlBootFeature controlBootFeature;
        ControlPhaseNoise controlPhaseNoise;
        ControlShortTermStability controlShortTermStability;
        ControlFrequencyAccuracy controlFrequencyAccuracy;
        ControlFrequencyReproducibility controlFrequencyReproducibility;
        ControlDriftRate controlDriftRate;
        ControlBurnInRate controlBurnInRate;
        ControlInterval controlInterval;
        ControlReportParam controlReportParam;

        public WindowWizard()
        {
            InitializeComponent();
            controlOverview = new ControlOverview();
            controlFrequencyCount = new ControlFrequencyCount();
            controlBootFeature = new ControlBootFeature();
            controlPhaseNoise = new ControlPhaseNoise();
            controlShortTermStability = new ControlShortTermStability();
            controlFrequencyAccuracy = new ControlFrequencyAccuracy();
            controlFrequencyReproducibility = new ControlFrequencyReproducibility();
            controlDriftRate = new ControlDriftRate();
            controlBurnInRate = new ControlBurnInRate();
            controlInterval = new ControlInterval();
            controlReportParam = new ControlReportParam();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lstControls.Add(controlOverview);
            lstControls.Add(controlFrequencyCount);
            lstControls.Add(controlBootFeature);
            lstControls.Add(controlPhaseNoise);
            lstControls.Add(controlShortTermStability);
            lstControls.Add(controlFrequencyAccuracy);
            lstControls.Add(controlFrequencyReproducibility);
            lstControls.Add(controlDriftRate);
            lstControls.Add(controlBurnInRate);
            lstControls.Add(controlInterval);
            lstControls.Add(controlReportParam);
            foreach (var control in lstControls)
            {
                Content.Children.Add(control);
                control.Visibility = Visibility.Hidden;
            }

            lstControls[index].Visibility = Visibility.Visible;
            this.DataContext = this;
        }

        private void BtnPrev_Click(object sender, RoutedEventArgs e)
        {
            lstControls[index].Visibility = Visibility.Hidden;
            do
            {
                Index--;
            } while (lstControls[index].IsActive);

            lstControls[index].Visibility = Visibility.Visible;
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            lstControls[index].Visibility = Visibility.Hidden;
            if(index == 0)
            {

            }

            do
            {
                Index++;
            } while (lstControls[index].IsActive == true || Index >= lstControls.Count);

            if (Index >= lstControls.Count)
                this.Close();
            else
                lstControls[index].Visibility = Visibility.Visible;
        }
    }
}
