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

namespace TimeFrequencyMeasurementSystem.Forms.Wizard
{
    /// <summary>
    /// ControlPeportParam.xaml 的交互逻辑
    /// </summary>
    public partial class ControlReportParam : ControlBase, INotifyPropertyChanged
    {
        #region 属性更改通知
        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string PropertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion

        public class Device : INotifyPropertyChanged
        {
            #region 属性更改通知
            public event PropertyChangedEventHandler PropertyChanged;
            private void Changed(string PropertyName)
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
            #endregion

            public string Name { get; set; }
        }

        public class Document : INotifyPropertyChanged
        {
            #region 属性更改通知
            public event PropertyChangedEventHandler PropertyChanged;
            private void Changed(string PropertyName)
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
            #endregion

            public string ID { get; set; }
            public string Name { get; set; }
        }

        public ObservableCollection<Device> LstDevices { get; set; }
        public ObservableCollection<Document> LstDocuments { get; set; }

        public ControlReportParam()
        {
            InitializeComponent();
            LstDevices = new ObservableCollection<Device>();
            LstDocuments = new ObservableCollection<Document>();
            this.DataContext = this;
            base.IsActive = true;
        }

        private void ItmDeviceRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridDevice.SelectedIndex != -1)
            {
                LstDevices.RemoveAt(dataGridDevice.SelectedIndex);
            }
        }

        private void ItmDocumentRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridDocument.SelectedIndex != -1)
            {
                LstDevices.RemoveAt(dataGridDocument.SelectedIndex);
            }
        }
    }
}
