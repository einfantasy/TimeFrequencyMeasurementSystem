using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace ScreenCut.Controls
{
    public class ResizeAdorner : Adorner
    {
        private List<UIElement> archors = new List<UIElement>();
        private FrameworkElement _adornedElement;

        public event Action ThumbSizeChanged;

        public ResizeAdorner(UIElement adornedElement)
            : base(adornedElement)
        {
            if (adornedElement is FrameworkElement)
            {
                _adornedElement = adornedElement as FrameworkElement;
                CreateAnchors();
            }
        }


        #region Create Controls
        private void CreateAnchors()
        {
            UIElement leftTop = CreateAnchor(HorizontalAlignment.Left, VerticalAlignment.Top);
            UIElement centerTop = CreateAnchor(HorizontalAlignment.Center, VerticalAlignment.Top);
            UIElement rightTop = CreateAnchor(HorizontalAlignment.Right, VerticalAlignment.Top);
            UIElement leftCenter = CreateAnchor(HorizontalAlignment.Left, VerticalAlignment.Center);
            UIElement rightCenter = CreateAnchor(HorizontalAlignment.Right, VerticalAlignment.Center);
            UIElement leftBottom = CreateAnchor(HorizontalAlignment.Left, VerticalAlignment.Bottom);
            UIElement centerBottom = CreateAnchor(HorizontalAlignment.Center, VerticalAlignment.Bottom);
            UIElement rightBottom = CreateAnchor(HorizontalAlignment.Right, VerticalAlignment.Bottom);

            archors.Add(leftTop);
            archors.Add(centerTop);
            archors.Add(rightTop);
            archors.Add(leftCenter);
            archors.Add(rightCenter);
            archors.Add(leftBottom);
            archors.Add(centerBottom);
            archors.Add(rightBottom);

            AddVisualChild(leftTop);
            AddVisualChild(centerTop);
            AddVisualChild(rightTop);
            AddVisualChild(leftCenter);
            AddVisualChild(rightCenter);
            AddVisualChild(leftBottom);
            AddVisualChild(centerBottom);
            AddVisualChild(rightBottom);
        }

        private UIElement CreateAnchor(HorizontalAlignment horizontalAlignment, VerticalAlignment verticalAlignment)
        {
            ResizeChorme chorme = new ResizeChorme(_adornedElement);
            chorme.Width = 10;
            chorme.Height = 10;
            chorme.HorizontalAlignment = horizontalAlignment;
            chorme.VerticalAlignment = verticalAlignment;
            chorme.ThumbSizeChanged += chorme_ThumbSizeChanged;
            return chorme;
        }

        private void chorme_ThumbSizeChanged()
        {
            if (ThumbSizeChanged != null)
                ThumbSizeChanged();
        }

        #endregion

        #region Adorner Override Method
        protected override Visual GetVisualChild(int index)
        {
            return archors[index];
        }

        protected override int VisualChildrenCount
        {
            get { return archors.Count; }
        }

        /// <summary>
        /// 设置附加元素的位置(必须,否则控件不显示)
        /// </summary>
        /// <param name="finalSize"></param>
        /// <returns></returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            foreach (var archor in archors)
            {
                archor.Arrange(new Rect(finalSize));
            }

            Size size = base.ArrangeOverride(finalSize);
            return size;
        }
        #endregion
    }
}
