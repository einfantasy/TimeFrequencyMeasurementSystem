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
    /// ShortTermStabilityFrom.xaml 的交互逻辑
    /// </summary>
    public partial class ShortTermStabilityFrom : UserControl, INotifyPropertyChanged
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
            set
            {
                MeasurementData.LstShortTermStability = value;
                Changed("LstShortTermStability");
            }
        }

        public BitmapImage ImgShortTermStability
        {
            get
            {
                return MeasurementData.ImgShortTermStability;
            }
        }


        public ShortTermStabilityFrom()
        {
            InitializeComponent();
            LstShortTermStability = new ObservableCollection<MeasurementShortTermStability>();
            this.DataContext = this;
        }


        private void ItmShortTermStabilityRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridShortTermStability.SelectedIndex != -1)
            {
                MeasurementShortTermStability msts = LstShortTermStability[dataGridShortTermStability.SelectedIndex];
                LstShortTermStability.Remove(msts);
            }
        }

        private void BtnAddRecord4_Click(object sender, RoutedEventArgs e)
        {
            WindowShortTermStability windowSTS = new WindowShortTermStability();
            if (windowSTS.ShowDialog() == true)
            {
                MeasurementBase measurement = new MeasurementShortTermStability(windowSTS.Now, windowSTS.Tau, windowSTS.Sigma);
                LstShortTermStability.Add((MeasurementShortTermStability)measurement);
            }
        }

        private void BtnPrintScreen2_Click(object sender, RoutedEventArgs e)
        {


            Window mainwd = App.Current.MainWindow;
            WindowState state = mainwd.WindowState;
            mainwd.WindowState = WindowState.Minimized;
            try
            {

                ScreenCut.MaskWindow scwd = new ScreenCut.MaskWindow();
                if (scwd.ShowDialog() == true)
                {
                    MeasurementData.ImgShortTermStability = Common.BitmapToBitmapImage(scwd.BMP);
                    Changed("ImgShortTermStability");
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
