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
using TimeFrequencyMeasurementSystem.Forms;
using TimeFrequencyMeasurementSystem.Forms.Wizard;
using TimeFrequencyMeasurementSystem.Structs;

namespace TimeFrequencyMeasurementSystem
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<MeasurementBase> LstMeasurements { get; set; }
        public ObservableCollection<MeasurementFrequencyCount> LstFrequencyCount
        {
            get
            {
                return MeasurementData.LstFrequencyCount;
            }
            set
            {
                MeasurementData.LstFrequencyCount = value;
                Changed("LstFrequencyCount");
            }
        }
        public ObservableCollection<MeasurementBootFeature> LstBootFeature
        {
            get
            {
                return MeasurementData.LstBootFeature;
            }
            set
            {
                MeasurementData.LstBootFeature = value;
                Changed("LstBootFeature");
            }
        }
        public ObservableCollection<MeasurementPhaseNoise> LstPhaseNoise
        {
            get
            {
                return MeasurementData.LstPhaseNoise;
            }
            set
            {
                MeasurementData.LstPhaseNoise = value;
                Changed("LstPhaseNoise");
            }
        }
        public ObservableCollection<MeasurementShortTermStability> LstShortTermStability
        {
            get
            {
                return MeasurementData.LstShortTermStability;
            }
            set
            {
                MeasurementData.LstShortTermStability = value;
                Changed("LstShortTermStability");
            }
        }
        public ObservableCollection<MeasurementFrequencyAccuracy> LstFrequencyAccuracy
        {
            get
            {
                return MeasurementData.LstFrequencyAccuracy;
            }
            set
            {
                MeasurementData.LstFrequencyAccuracy = value;
                Changed("LstFrequencyAccuracy");
            }
        }
        public ObservableCollection<MeasurementFrequencyReproducibility> LstFrequencyReproducibility
        {
            get
            {
                return MeasurementData.LstFrequencyReproducibility;
            }
            set
            {
                MeasurementData.LstFrequencyReproducibility = value;
                Changed("LstFrequencyReproducibility");
            }
        }
        public ObservableCollection<MeasurementDriftRateParam> LstDriftRateParam
        {
            get
            {
                return MeasurementData.LstDriftRateParam;
            }
            set
            {
                MeasurementData.LstDriftRateParam = value;
                Changed("LstDriftRateParam");
            }
        }
        public ObservableCollection<MeasurementBurnInRateParam> LstBurnInRateParam
        {
            get
            {
                return MeasurementData.LstBurnInRateParam;
            }
            set
            {
                MeasurementData.LstBurnInRateParam = value;
                Changed("LstBurnInRateParam");
            }
        }
        public ObservableCollection<MeasurementInterval> LstInterval
        {
            get
            {
                return MeasurementData.LstInterval;
            }
            set
            {
                MeasurementData.LstInterval = value;
                Changed("LstInterval");
            }
        }

        private DateTime timeDriftRate;
        private DateTime timeBurnInRate;

        public MainWindow()
        {
            InitializeComponent();
            LstMeasurements = new ObservableCollection<MeasurementBase>();
            LstFrequencyCount = new ObservableCollection<MeasurementFrequencyCount>();
            LstBootFeature = new ObservableCollection<MeasurementBootFeature>();
            LstPhaseNoise = new ObservableCollection<MeasurementPhaseNoise>();
            LstShortTermStability = new ObservableCollection<MeasurementShortTermStability>();
            LstFrequencyAccuracy = new ObservableCollection<MeasurementFrequencyAccuracy>();
            LstFrequencyReproducibility = new ObservableCollection<MeasurementFrequencyReproducibility>();
            LstDriftRateParam = new ObservableCollection<MeasurementDriftRateParam>();
            LstBurnInRateParam = new ObservableCollection<MeasurementBurnInRateParam>();
            LstInterval = new ObservableCollection<MeasurementInterval>();
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        private void BtnAddRecord1_Click(object sender, RoutedEventArgs e)
        {
            WindowFrequencyCount windowFC = new WindowFrequencyCount();
            if (windowFC.ShowDialog() == true)
            {
                MeasurementBase measurement = new MeasurementFrequencyCount(windowFC.Now, windowFC.Frequency);
                LstMeasurements.Add(measurement);
                LstFrequencyCount.Add((MeasurementFrequencyCount)measurement);
            }
        }

        private void BtnAddRecord2_Click(object sender, RoutedEventArgs e)
        {
            WindowBootFeature windowBF = new WindowBootFeature();
            if (windowBF.ShowDialog() == true)
            {
                MeasurementBase measurement = new MeasurementBootFeature(windowBF.Now, windowBF.FrequencyBoot, windowBF.FrequencyStable, windowBF.FrequencyStandard.ToString());
                LstMeasurements.Add(measurement);
                LstBootFeature.Add((MeasurementBootFeature)measurement);
            }
        }

        private void BtnAddRecord3_Click(object sender, RoutedEventArgs e)
        {
            WindowPhaseNoise windowPN = new WindowPhaseNoise();
            if (windowPN.ShowDialog() == true)
            {
                MeasurementBase measurement = new MeasurementPhaseNoise(windowPN.Now, windowPN.FrequencyOffset, windowPN.Noise);
                LstMeasurements.Add(measurement);
                LstPhaseNoise.Add((MeasurementPhaseNoise)measurement);
            }
        }

        private void BtnAddRecord4_Click(object sender, RoutedEventArgs e)
        {
            WindowShortTermStability windowSTS = new WindowShortTermStability();
            if (windowSTS.ShowDialog() == true)
            {
                MeasurementBase measurement = new MeasurementShortTermStability(windowSTS.Now, windowSTS.Tau, windowSTS.Sigma);
                LstMeasurements.Add(measurement);
                LstShortTermStability.Add((MeasurementShortTermStability)measurement);
            }
        }

        private void BtnAddRecord5_Click(object sender, RoutedEventArgs e)
        {
            WindowFrequencyAccuracy windowFA = new WindowFrequencyAccuracy();
            if (windowFA.ShowDialog() == true)
            {
                MeasurementBase measurement = new MeasurementFrequencyAccuracy(windowFA.Now, windowFA.FrequencyStandard.ToString(), windowFA.FrequencyActual);
                LstMeasurements.Add(measurement);
                LstFrequencyAccuracy.Add((MeasurementFrequencyAccuracy)measurement);
            }
        }

        private void BtnAddRecord6_Click(object sender, RoutedEventArgs e)
        {
            WindowFrequencyReproducibility windowFR = new WindowFrequencyReproducibility();
            if (windowFR.ShowDialog() == true)
            {
                MeasurementBase measurement = new MeasurementFrequencyReproducibility(windowFR.Now, windowFR.FrequencyI, windowFR.FrequencyII, windowFR.FrequencyStandard.ToString());
                LstMeasurements.Add(measurement);
                LstFrequencyReproducibility.Add((MeasurementFrequencyReproducibility)measurement);
            }
        }

        private void BtnAddRecord7_Click(object sender, RoutedEventArgs e)
        {
            int day = 1;
            if (LstDriftRateParam.Count != 0)
            {
                day = Convert.ToInt32(LstDriftRateParam.Last().Index);
                DateTime temp = DateTime.Now;
                if ((temp - timeDriftRate).TotalHours >= 24)
                    day++;
            }

            timeDriftRate = DateTime.Now;
            WindowDriftRate windowDR = new WindowDriftRate(day);
            if (windowDR.ShowDialog() == true)
            {
                MeasurementBase measurement = new MeasurementDriftRateParam(windowDR.Now, windowDR.Days.ToString(), windowDR.Frequency);
                LstMeasurements.Add(measurement);
                LstDriftRateParam.Add((MeasurementDriftRateParam)measurement);
            }
        }

        private void BtnAddRecord8_Click(object sender, RoutedEventArgs e)
        {
            int count = 1;
            if (LstBurnInRateParam.Count != 0)
            {
                count = Convert.ToInt32(LstBurnInRateParam.Last().Index);
                DateTime temp = DateTime.Now;
                if ((temp - timeBurnInRate).TotalHours >= 24)
                    count++;
            }

            timeBurnInRate = DateTime.Now;
            WindowBurnInRate windowBIR = new WindowBurnInRate(count);
            if (windowBIR.ShowDialog() == true)
            {
                MeasurementBase measurement = new MeasurementBurnInRateParam(windowBIR.Now, windowBIR.Count.ToString(), windowBIR.Frequency);
                LstMeasurements.Add(measurement);
                LstBurnInRateParam.Add((MeasurementBurnInRateParam)measurement);
            }
        }

        private void BtnAddRecord9_Click(object sender, RoutedEventArgs e)
        {
            WindowInterval windowI = new WindowInterval();
            if (windowI.ShowDialog() == true)
            {
                MeasurementBase measurement = new MeasurementInterval(windowI.Now, windowI.Average, windowI.StandardDeviation);
                LstMeasurements.Add(measurement);
                LstInterval.Add((MeasurementInterval)measurement);
            }
        }

        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {
            WindowWizard wizard = new WindowWizard(LstMeasurements);
            wizard.ShowDialog();
        }

        private void ItmFrequencyCountRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridFrequencyCount.SelectedIndex != -1)
            {
                MeasurementFrequencyCount mfc = LstFrequencyCount[dataGridFrequencyCount.SelectedIndex];
                LstFrequencyCount.Remove(mfc);
                LstMeasurements.Remove(mfc);
            }
        }

        private void ItmBootFeatureRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridBootFeature.SelectedIndex != -1)
            {
                MeasurementBootFeature mbf = LstBootFeature[dataGridBootFeature.SelectedIndex];
                LstBootFeature.Remove(mbf);
                LstMeasurements.Remove(mbf);
            }
        }

        private void ItmPhaseNoiseRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPhaseNoise.SelectedIndex != -1)
            {
                MeasurementPhaseNoise mpn = LstPhaseNoise[dataGridPhaseNoise.SelectedIndex];
                LstPhaseNoise.Remove(mpn);
                LstMeasurements.Remove(mpn);
            }
        }

        private void ItmShortTermStabilityRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridShortTermStability.SelectedIndex != -1)
            {
                MeasurementShortTermStability msts = LstShortTermStability[dataGridShortTermStability.SelectedIndex];
                LstShortTermStability.Remove(msts);
                LstMeasurements.Remove(msts);
            }
        }

        private void ItmFrequencyAccuracyRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridShortTermStability.SelectedIndex != -1)
            {
                MeasurementFrequencyAccuracy mfa = LstFrequencyAccuracy[dataGridFrequencyAccuracy.SelectedIndex];
                LstFrequencyAccuracy.Remove(mfa);
                LstMeasurements.Remove(mfa);
            }
        }

        private void ItmFrequencyReproducibilityRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridFrequencyReproducibility.SelectedIndex != -1)
            {
                MeasurementFrequencyReproducibility mfr = LstFrequencyReproducibility[dataGridFrequencyReproducibility.SelectedIndex];
                LstFrequencyReproducibility.Remove(mfr);
                LstMeasurements.Remove(mfr);
            }
        }

        private void ItmDriftRateRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridDriftRate.SelectedIndex != -1)
            {
                MeasurementDriftRateParam mdr = LstDriftRateParam[dataGridDriftRate.SelectedIndex];
                LstDriftRateParam.Remove(mdr);
                LstMeasurements.Remove(mdr);
            }
        }

        private void BtnCalculate1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MeasurementDriftRate mdr = new MeasurementDriftRate(LstDriftRateParam.ToList());
                MessageBox.Show(string.Format("漂移率：{0}", mdr.DriftRate));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ItmBurnInRateRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridBurnInRate.SelectedIndex != -1)
            {
                MeasurementBurnInRateParam mbir = LstBurnInRateParam[dataGridBurnInRate.SelectedIndex];
                LstBurnInRateParam.Remove(mbir);
                LstMeasurements.Remove(mbir);
            }
        }

        private void BtnCalculate2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MeasurementBurnInRate mbir = new MeasurementBurnInRate(LstBurnInRateParam.ToList());
                MessageBox.Show(string.Format("日老化率：{0}", mbir.BurnInRate));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ItmIntervalRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridInterval.SelectedIndex != -1)
            {
                MeasurementInterval mi = LstInterval[dataGridInterval.SelectedIndex];
                LstInterval.Remove(mi);
                LstMeasurements.Remove(mi);
            }
        }
    }
}
