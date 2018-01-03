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

namespace TimeFrequencyMeasurementSystem.Forms.SubForm
{
    /// <summary>
    /// ParseNoise.xaml 的交互逻辑
    /// </summary>
    public partial class ParseNoiseForm : UserControl, INotifyPropertyChanged
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
            set
            {
                MeasurementData.LstPhaseNoise = value;
                Changed("LstPhaseNoise");
            }
        }

        public BitmapImage ImgPhaseNoise
        {
            get
            {
                return MeasurementData.ImgPhaseNoise;
            }
        }
        public ParseNoiseForm()
        {
            InitializeComponent();
            LstPhaseNoise = new ObservableCollection<MeasurementPhaseNoise>();
            this.DataContext = this;
        }

        private void ItmPhaseNoiseRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPhaseNoise.SelectedIndex != -1)
            {
                MeasurementPhaseNoise mpn = LstPhaseNoise[dataGridPhaseNoise.SelectedIndex];
                LstPhaseNoise.Remove(mpn);
            }
        }

        private void BtnAddRecord3_Click(object sender, RoutedEventArgs e)
        {
            WindowPhaseNoise windowPN = new WindowPhaseNoise();
            if (windowPN.ShowDialog() == true)
            {
                MeasurementBase measurement = new MeasurementPhaseNoise(windowPN.Now, windowPN.FrequencyOffset, windowPN.Noise);
                LstPhaseNoise.Add((MeasurementPhaseNoise)measurement);
            }
        }

        private void BtnPrintScreen1_Click(object sender, RoutedEventArgs e)
        {
            Window mainwd = App.Current.MainWindow;
            WindowState state = mainwd.WindowState;
            mainwd.WindowState = WindowState.Minimized;
            try
            {

                ScreenCut.MaskWindow scwd = new ScreenCut.MaskWindow();
                if (scwd.ShowDialog() == true)
                {
                    MeasurementData.ImgPhaseNoise = Common.BitmapToBitmapImage(scwd.BMP);
                    Changed("ImgPhaseNoise");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                mainwd.WindowState = state;
            }
        }

    }

}
