using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ScreenCut.Controls;
using Point = System.Windows.Point;

namespace ScreenCut
{
    /// <summary>
    /// MaskWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MaskWindow : Window
    {

        public double Left { get; set; }
        public double Top { get; set; }
        public double Right { get; set; }
        public double Bottom { get; set; }

        public Bitmap BMP { get; set; }
        public BitmapSource BMPSource { get; set; }
        public MaskWindow()
        {
            InitializeComponent();

            this.MouseLeftButtonDown += MaskWindow_MouseLeftButtonDown;
            this.MouseMove += MaskWindow_MouseMove;
            this.MouseLeftButtonUp += MaskWindow_MouseLeftButtonUp;

            this.MouseDoubleClick += MaskWindow_MouseDoubleClick;
            this.Topmost = true;
        }

        void MaskWindow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CopyFromScreenSnapshot();
        }
        private void CopyFromScreenSnapshot()
        {
            try
            {
                if (double.IsNaN(border.Width) || double.IsNaN(border.Height) || border.Width < 1 || border.Height < 1)
                    return;

                int x = (int)Canvas.GetLeft(border);
                int y = (int)Canvas.GetTop(border);
                int width = (int)border.Width;
                int height = (int)border.Height;

                Bitmap image = new Bitmap(width, height);
                Graphics g = Graphics.FromImage(image);
                g.CopyFromScreen(x, y, 0, 0, new System.Drawing.Size(width, height), CopyPixelOperation.SourceCopy);

                image.Save("1.jpg");
                BMP = image;
                BMPSource = ConvertBitmapToBitmapSource(image);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show(ex.Message);
            }

            
        }

        #region 出现区域
        private Point oldMousePosition;
        void MaskWindow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            fe.ReleaseMouseCapture();
            e.Handled = true;

            //完成后去掉此事件
           
            OprationWindow owd = new OprationWindow();
            double x = e.GetPosition(this).X ;
            double y = e.GetPosition(this).Y;
            owd.Left  = x-owd.Width;
            owd.Top = y;
            if (owd.ShowDialog() == true)
            {
                Right = x;
                Bottom = y;
                CopyFromScreenSnapshot();
                //this.MouseLeftButtonDown -= MaskWindow_MouseLeftButtonDown;
                //this.MouseMove -= MaskWindow_MouseMove;
                //this.MouseLeftButtonUp -= MaskWindow_MouseLeftButtonUp;
                this.DialogResult = true;
            }
            else
            {
                border.Width = 0;border.Height = 0;
                Refresh();
                this.DialogResult = false;
            }
        }

        void MaskWindow_MouseMove(object sender, MouseEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            if (e.LeftButton == MouseButtonState.Released || !fe.IsMouseCaptured) return;

            Point mousePosition = e.GetPosition(this);
            Vector spacing = mousePosition - oldMousePosition;//两次鼠标移动的间距
            oldMousePosition = mousePosition;
            if(spacing.X >=0&&spacing.Y >=0)
            {
                border.Width = this.border.Width + spacing.X;
                border.Height = border.Height + spacing.Y;
            }
            
            Refresh();
            e.Handled = true;
        }

        void MaskWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            oldMousePosition = e.GetPosition(this);

            Canvas.SetLeft(border, oldMousePosition.X);
            Canvas.SetTop(border, oldMousePosition.Y);
            Left = oldMousePosition.X;
            Top = oldMousePosition.Y;
            fe.CaptureMouse();
            e.Handled = true;
        }
        #endregion

        #region Event Handler
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

                AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(border);

                var moveAdorner = new MoveAdorner(border);
                var resizeAdorner = new ResizeAdorner(border);

                moveAdorner.LocationChanged += AdornerChanged;
                resizeAdorner.ThumbSizeChanged += AdornerChanged;

                //注意顺序
                adornerLayer.Add(moveAdorner);
                adornerLayer.Add(resizeAdorner);

                Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show(ex.Message);
            }
            
        }

        private void AdornerChanged()
        {
            Refresh();
        }

        private void Refresh()
        {
            maskCanvas.Refresh(border.Width, border.Height, Canvas.GetLeft(border), Canvas.GetTop(border));
        }
        #endregion


        private BitmapSource ConvertBitmapToBitmapSource(Bitmap bmp)
        {
            BitmapSource bitmapSource = null;

            if (ReferenceEquals(null, bmp)) return null;
            try
            {
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height);
                System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);
                IntPtr ptr = bmpData.Scan0;
                bitmapSource = BitmapSource.Create(bmp.Width, bmp.Height, 96, 96, PixelFormats.Bgra32, null, ptr, bmp.Height * bmpData.Stride, bmpData.Stride);  //10
                bmp.UnlockBits(bmpData);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }

            return bitmapSource;
        }

    }
}
