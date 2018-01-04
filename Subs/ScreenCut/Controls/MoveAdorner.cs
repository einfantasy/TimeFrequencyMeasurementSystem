using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace ScreenCut.Controls
{
    public class MoveAdorner : Adorner
    {
        private FrameworkElement _adornedElement;
        private MoveChorme chorme;

        public event Action LocationChanged;

        public MoveAdorner(UIElement adornedElement)
            : base(adornedElement)
        {
            if (adornedElement is FrameworkElement)
            {
                _adornedElement = adornedElement as FrameworkElement;
                CreateControl();
            }
        }

        private void CreateControl()
        {
            this.chorme = new MoveChorme(_adornedElement);
            this.chorme.LocationChanged += chorme_LocationChanged;
            AddVisualChild(this.chorme);
        }

        private void chorme_LocationChanged()
        {
            if (LocationChanged != null)
                LocationChanged();
        }

        #region Adorner Override Method
        protected override int VisualChildrenCount
        {
            get
            {
                return 1;
            }
        }

        protected override System.Windows.Media.Visual GetVisualChild(int index)
        {
            return this.chorme;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            chorme.Arrange(new Rect(finalSize));
            return base.ArrangeOverride(finalSize);
        }
        #endregion
    }
}
