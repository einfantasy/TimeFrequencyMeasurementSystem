using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace TimeFrequencyMeasurementSystem.Forms.Wizard
{
    public abstract class ControlBase : UserControl, IDisposable
    {
        public bool IsActive { get; set; }

        public void Dispose()
        {
            dispose();
        }

        public virtual void dispose() { }

        public ControlBase()
        {

        }
    }
}
