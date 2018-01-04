using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ScreenCut.Controls
{
    public class MoveThumb : Thumb
    {
        private MoveChorme moveChorme;
        public event Action LocationChanged;

        public MoveThumb()
        {
            this.DragStarted += MoveThumb_DragStarted;
            this.DragDelta += MoveThumb_DragDelta;
        }

        void MoveThumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            this.moveChorme = DataContext as MoveChorme;
        }

        private void MoveThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (this.moveChorme != null)
            {
                double x = Canvas.GetLeft(this.moveChorme.Container);
                double y = Canvas.GetTop(this.moveChorme.Container);

                Point dragDelta = new Point(e.HorizontalChange, e.VerticalChange);

                SetLeft(x, dragDelta.X);
                SetTop(y, dragDelta.Y);

                if (LocationChanged != null)
                    LocationChanged();
            }
        }

        private void SetLeft(double x, double dragDeltaX)
        {
            dragDeltaX = double.IsNaN(x) ? 0 : dragDeltaX;

            if (x + dragDeltaX < 0)
                x = 0;
            else if (SystemParameters.PrimaryScreenWidth < this.moveChorme.Container.Width + dragDeltaX + x)
                x = SystemParameters.PrimaryScreenWidth - this.moveChorme.Container.Width;
            else
                x = dragDeltaX + x;

            Canvas.SetLeft(this.moveChorme.Container, x);
        }

        private void SetTop(double y, double dragDeltaY)
        {
            dragDeltaY = double.IsNaN(y) ? 0 : dragDeltaY;

            if (y + dragDeltaY <= 0)
                y = 0;
            else if (SystemParameters.PrimaryScreenHeight < this.moveChorme.Container.Height + dragDeltaY + y)
                y = SystemParameters.PrimaryScreenHeight - this.moveChorme.Container.Height;
            else
                y = dragDeltaY + y;

            Canvas.SetTop(this.moveChorme.Container, y);
        }
    }
}
