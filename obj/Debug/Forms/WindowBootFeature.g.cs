﻿#pragma checksum "..\..\..\Forms\WindowBootFeature.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "431B835EA7C05C4CA41CE1635F479F92"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using NumericUpDownControl;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using TimeFrequencyMeasurementSystem.Forms;


namespace TimeFrequencyMeasurementSystem.Forms {
    
    
    /// <summary>
    /// WindowBootFeature
    /// </summary>
    public partial class WindowBootFeature : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\Forms\WindowBootFeature.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblFrequencyBoot;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Forms\WindowBootFeature.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtFrequencyBoot;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Forms\WindowBootFeature.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblFrequencyStable;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Forms\WindowBootFeature.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblFrequencyStandard;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Forms\WindowBootFeature.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnOk;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Forms\WindowBootFeature.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnCancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TimeFrequencyMeasurementSystem;component/forms/windowbootfeature.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Forms\WindowBootFeature.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\Forms\WindowBootFeature.xaml"
            ((TimeFrequencyMeasurementSystem.Forms.WindowBootFeature)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LblFrequencyBoot = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.TxtFrequencyBoot = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.LblFrequencyStable = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.LblFrequencyStandard = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.BtnOk = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\Forms\WindowBootFeature.xaml"
            this.BtnOk.Click += new System.Windows.RoutedEventHandler(this.BtnOk_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BtnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\Forms\WindowBootFeature.xaml"
            this.BtnCancel.Click += new System.Windows.RoutedEventHandler(this.BtnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

