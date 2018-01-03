using System;
using System.Windows;
using System.Windows.Controls;

namespace ScreenCut.Controls
{
    [TemplatePart(Name = resizeThumbName, Type = typeof(ResizeThumb))]
    public class ResizeChorme : ContentControl
    {
        #region Private Field
        private const string resizeThumbName = "resizeThumb";
        #endregion

        public event Action ThumbSizeChanged;

        /// <summary>
        /// container为包含此装饰器的控件
        /// </summary>
        /// <param name="container"></param>
        public ResizeChorme(FrameworkElement container)
        {
            this.container = container;
            this.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/ScreenCut;component/Controls/Control.ResizeChorme.xaml", UriKind.Relative)
        });
            this.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("/ScreenCut;component/Controls/Control.MoveChorme.xaml", UriKind.Relative) });
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
            var resizeThumb = GetTemplateChild(resizeThumbName) as ResizeThumb;
            if(resizeThumb!= null)
            {
                resizeThumb.ThumbSizeChanged += resizeThumb_ThumbSizeChanged;
            }
            
        }

        private void resizeThumb_ThumbSizeChanged()
        {
            if (ThumbSizeChanged != null)
                ThumbSizeChanged();
        }
    }
}
