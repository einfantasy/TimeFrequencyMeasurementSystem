using System;
using System.Collections.Generic;
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

namespace TimeFrequencyMeasurementSystem.Forms.Wizard
{
    /// <summary>
    /// ControlOverview.xaml 的交互逻辑
    /// </summary>
    public partial class ControlOverview : ControlBase, INotifyPropertyChanged
    {
        private bool bFrequencyCount = false;
        public bool BFrequencyCount
        {
            get
            {
                return bFrequencyCount;
            }
            set
            {
                bFrequencyCount = value;
                OnPropertyChanged("BFrequencyCount");
            }
        }

        private bool bBootFeature = false;
        public bool BBootFeature
        {
            get
            {
                return bBootFeature;
            }
            set
            {
                bBootFeature = value;
                OnPropertyChanged("BBootFeature");
            }
        }

        private bool bPhaseNoise = false;
        public bool BPhaseNoise
        {
            get
            {
                return bPhaseNoise;
            }
            set
            {
                bPhaseNoise = value;
                OnPropertyChanged("BPhaseNoise");
            }
        }

        private bool bShortTermStability = false;
        public bool BShortTermStability
        {
            get
            {
                return bShortTermStability;
            }
            set
            {
                bShortTermStability = value;
                OnPropertyChanged("BShortTermStability");
            }
        }

        private bool bFrequencyAccuracy = false;
        public bool BFrequencyAccuracy
        {
            get
            {
                return bFrequencyAccuracy;
            }
            set
            {
                bFrequencyAccuracy = value;
                OnPropertyChanged("BFrequencyAccuracy");
            }
        }

        private bool bFrequencyReproducibility = false;
        public bool BFrequencyReproducibility
        {
            get
            {
                return bFrequencyReproducibility;
            }
            set
            {
                bFrequencyReproducibility = value;
                OnPropertyChanged("BFrequencyReproducibility");
            }
        }

        private bool bDriftRate = false;
        public bool BDriftRate
        {
            get
            {
                return bDriftRate;
            }
            set
            {
                bDriftRate = value;
                OnPropertyChanged("BDriftRate");
            }
        }

        private bool bBurnInRate = false;
        public bool BBurnInRate
        {
            get
            {
                return bBurnInRate;
            }
            set
            {
                bBurnInRate = value;
                OnPropertyChanged("BBurnInRate");
            }
        }

        private bool bInterval = false;
        public bool BInterval
        {
            get
            {
                return bInterval;
            }
            set
            {
                bInterval = value;
                OnPropertyChanged("BInterval");
            }
        }

        private bool bFrequencyCountEnabled;
        public bool BFrequencyCountEnabled
        {
            get
            {
                return bFrequencyCountEnabled;
            }
            set
            {
                bFrequencyCountEnabled = value;
                OnPropertyChanged("BFrequencyCountEnabled");
            }
        }

        private bool bBootFeatureEnabled;
        public bool BBootFeatureEnabled
        {
            get
            {
                return bBootFeatureEnabled;
            }
            set
            {
                bBootFeatureEnabled = value;
                OnPropertyChanged("BBootFeatureEnabled");
            }
        }

        private bool bPhaseNoiseEnabled;
        public bool BPhaseNoiseEnabled
        {
            get
            {
                return bPhaseNoiseEnabled;
            }
            set
            {
                bPhaseNoiseEnabled = value;
                OnPropertyChanged("BPhaseNoiseEnabled");
            }
        }

        private bool bShortTermStabilityEnabled;
        public bool BShortTermStabilityEnabled
        {
            get
            {
                return bShortTermStabilityEnabled;
            }
            set
            {
                bShortTermStabilityEnabled = value;
                OnPropertyChanged("BShortTermStabilityEnabled");
            }
        }

        private bool bFrequencyAccuracyEnabled;
        public bool BFrequencyAccuracyEnabled
        {
            get
            {
                return bFrequencyAccuracyEnabled;
            }
            set
            {
                bFrequencyAccuracyEnabled = value;
                OnPropertyChanged("BFrequencyAccuracyEnabled");
            }
        }

        private bool bFrequencyReproducibilityEnabled;
        public bool BFrequencyReproducibilityEnabled
        {
            get
            {
                return bFrequencyReproducibilityEnabled;
            }
            set
            {
                bFrequencyReproducibilityEnabled = value;
                OnPropertyChanged("BFrequencyReproducibilityEnabled");
            }
        }

        private bool bDriftRateEnabled;
        public bool BDriftRateEnabled
        {
            get
            {
                return bDriftRateEnabled;
            }
            set
            {
                bDriftRateEnabled = value;
                OnPropertyChanged("BDriftRateEnabled");
            }
        }

        private bool bBurnInRateEnabled;
        public bool BBurnInRateEnabled
        {
            get
            {
                return bBurnInRateEnabled;
            }
            set
            {
                bBurnInRateEnabled = value;
                OnPropertyChanged("BBurnInRateEnabled");
            }
        }

        private bool bIntervalEnabled;
        public bool BIntervalEnabled
        {
            get
            {
                return bIntervalEnabled;
            }
            set
            {
                bIntervalEnabled = value;
                OnPropertyChanged("BIntervalEnabled");
            }
        }

        private int activeBias = 0;
        public int ActiveBias
        {
            get
            {
                return activeBias;
            }
            set
            {
                activeBias = value;
                OnPropertyChanged("ActiveBias");
            }
        }

        public ControlOverview(int enabledBias = 0xff)
        {
            InitializeComponent();
            if ((enabledBias & 0x01) == 0x01)
                this.BFrequencyCountEnabled = true;
            else
                this.BFrequencyCountEnabled = false;
            if ((enabledBias & 0x02) == 0x02)
                this.BBootFeatureEnabled = true;
            else
                this.BBootFeatureEnabled = false;
            if ((enabledBias & 0x04) == 0x04)
                this.BPhaseNoiseEnabled = true;
            else
                this.BPhaseNoiseEnabled = false;
            if ((enabledBias & 0x08) == 0x08)
                this.BShortTermStabilityEnabled = true;
            else
                this.BShortTermStabilityEnabled = false;
            if ((enabledBias & 0x10) == 0x10)
                this.BFrequencyAccuracyEnabled = true;
            else
                this.BFrequencyAccuracyEnabled = false;
            if ((enabledBias & 0x20) == 0x20)
                this.BFrequencyReproducibilityEnabled = true;
            else
                this.BFrequencyReproducibilityEnabled = false;
            if ((enabledBias & 0x40) == 0x40)
                this.BDriftRateEnabled = true;
            else
                this.BDriftRateEnabled = false;
            if ((enabledBias & 0x80) == 0x80)
                this.BBurnInRateEnabled = true;
            else
                this.BBurnInRateEnabled = false;
            if ((enabledBias & 0x100) == 0x100)
                this.BIntervalEnabled = true;
            else
                this.BIntervalEnabled = false;
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}
