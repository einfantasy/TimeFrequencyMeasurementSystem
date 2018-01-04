using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimeFrequencyMeasurementSystem.Data;
using TimeFrequencyMeasurementSystem.Forms;
using TimeFrequencyMeasurementSystem.Forms.Wizard;
using TimeFrequencyMeasurementSystem.Functions;
using TimeFrequencyMeasurementSystem.Structs;

namespace TimeFrequencyMeasurementSystem
{

    

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
       
        public MainWindow()
        {
            InitializeComponent();
          
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }




        
        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {
            WindowWizard wizard = new WindowWizard();
            wizard.ShowDialog();
        }

        private void toolBar_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.ToolBar tbar = (System.Windows.Controls.ToolBar)sender;
            if (tbar != null)
            {
                var overflowgrid = tbar.Template.FindName("OverflowGrid", tbar) as FrameworkElement;
                if (overflowgrid != null)
                {
                    overflowgrid.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
