using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ScreenCut.Controls
{
    public class ResizeThumb : Thumb
    {
        private ResizeChorme resizeChorme;
        public event Action ThumbSizeChanged;
        private int minWidth = 30;
        private int minHeight = 30;

        public ResizeThumb()
        {
            this.DragStarted += ResizeThumb_DragStarted;
            this.DragDelta += ResizeThumb_DragDelta;
        }


        void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            double x = e.HorizontalChange;
            double y = e.VerticalChange;

            switch (resizeChorme.HorizontalAlignment)
            {
                case System.Windows.HorizontalAlignment.Left:
                    Canvas.SetLeft(resizeChorme.Container, Canvas.GetLeft(resizeChorme.Container) + x);
                    resizeChorme.Container.Width = Math.Max(minWidth, resizeChorme.Container.Width - x);
                    break;
                case System.Windows.HorizontalAlignment.Right:
                    resizeChorme.Container.Width = Math.Max(minWidth, resizeChorme.Container.Width + x);
                    break;
            }

            switch (resizeChorme.VerticalAlignment)
            {
                case System.Windows.VerticalAlignment.Top:
                    Canvas.SetTop(resizeChorme.Container, Canvas.GetTop(resizeChorme.Container) + y);
                    resizeChorme.Container.Height = Math.Max(minHeight, resizeChorme.Container.Height - y);
                    break;
                case System.Windows.VerticalAlignment.Bottom:
                    resizeChorme.Container.Height = Math.Max(minHeight, resizeChorme.Container.Height + y);
                    break;
            }

            e.Handled = true;

            if (ThumbSizeChanged != null)
                ThumbSizeChanged();
        }

        void ResizeThumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            resizeChorme = this.DataContext as ResizeChorme;
        }
    }
}
