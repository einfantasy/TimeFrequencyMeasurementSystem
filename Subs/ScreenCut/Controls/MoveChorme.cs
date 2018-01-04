using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ScreenCut.Controls
{
    [TemplatePart(Name = moveThumbName, Type = typeof(MoveThumb))]
    public class MoveChorme : ContentControl
    {
        #region Private Field
        private const string moveThumbName = "moveThumb";
        #endregion

        public event Action LocationChanged;

        /// <summary>
        /// container为包含此装饰器的控件
        /// </summary>
        /// <param name="container"></param>
        public MoveChorme(FrameworkElement container)
        {
            this.container = container;
        }

        private FrameworkElement container;
        public FrameworkElement Container
        {
            get { return container; }
            set
            {
                container = value;
            }
        }

        public override void OnApplyTemplate()
        {
            var moveThumb = GetTemplateChild(moveThumbName) as MoveThumb;
            if(moveThumb!= null)
            {
                moveThumb.LocationChanged += moveThumb_LocationChanged;
            }
        
        }

        private void moveThumb_LocationChanged()
        {
            if (LocationChanged != null)
                LocationChanged();
        }
    }
}
