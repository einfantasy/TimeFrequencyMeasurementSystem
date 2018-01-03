using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using ScreenCut.Controls;
using System.Windows.Media.Imaging;

namespace ScreenCut
{
    public class MaskCanvas : Canvas
    {
        private readonly Rectangle maskRectLeft = new Rectangle();
        private readonly Rectangle maskRectRight = new Rectangle();
        private readonly Rectangle maskRectTop = new Rectangle();
        private readonly Rectangle maskRectBottom = new Rectangle();

        public MaskCanvas()
        {
            this.Loaded += MaskCanvas_Loaded;
            this.Width = SystemParameters.PrimaryScreenWidth;
            this.Height = SystemParameters.PrimaryScreenHeight;
        }

        private void MaskCanvas_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //maskRectLeft.Fill = maskRectRight.Fill = maskRectTop.Fill = maskRectBottom.Fill = Brushes.Gray;

            maskRectLeft.Fill = Brushes.WhiteSmoke;
            maskRectRight.Fill = Brushes.WhiteSmoke;
            maskRectTop.Fill = Brushes.WhiteSmoke; 
            maskRectBottom.Fill = Brushes.WhiteSmoke;

            maskRectLeft.Opacity = maskRectRight.Opacity = maskRectTop.Opacity = maskRectBottom.Opacity = 0.6;

            this.Children.Add(maskRectLeft);
            this.Children.Add(maskRectRight);
            this.Children.Add(maskRectTop);
            this.Children.Add(maskRectBottom);
        }

        public void Refresh(double width, double height, double x, double y)
        {
            maskRectLeft.Width = x;
            maskRectLeft.Height = this.ActualHeight;

            Canvas.SetLeft(maskRectTop, x);
            maskRectTop.Width = width;
            maskRectTop.Height = y;

            Canvas.SetLeft(maskRectRight, x + width);
            maskRectRight.Width = this.ActualWidth - x - width;
            maskRectRight.Height = this.ActualHeight;

            Canvas.SetLeft(maskRectBottom, x);
            Canvas.SetTop(maskRectBottom, y + height);
            maskRectBottom.Width = width;
            maskRectBottom.Height = this.ActualHeight - y - height;
        }

      
    }
}
