﻿#pragma checksum "..\..\EliminarCliente.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6D13CAACEA9E70C66D96CCE4F1349EEB9A224B59"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using BeLifeWPF;
using MahApps.Metro.Controls;
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


namespace BeLifeWPF {
    
    
    /// <summary>
    /// EliminarCliente
    /// </summary>
    public partial class EliminarCliente : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 14 "..\..\EliminarCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtRut;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\EliminarCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnEliminarCliente;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\EliminarCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBuscarCliente;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\EliminarCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.Flyout FlyBuscarCliente;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\EliminarCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtRutBuscar;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\EliminarCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboSexoBuscar;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\EliminarCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboEstCivilBuscar;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\EliminarCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnFiltrar;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\EliminarCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DtgClientes;
        
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
            System.Uri resourceLocater = new System.Uri("/BeLifeWPF;component/eliminarcliente.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EliminarCliente.xaml"
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
            this.TxtRut = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.BtnEliminarCliente = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\EliminarCliente.xaml"
            this.BtnEliminarCliente.Click += new System.Windows.RoutedEventHandler(this.BtnEliminarCliente_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnBuscarCliente = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\EliminarCliente.xaml"
            this.BtnBuscarCliente.Click += new System.Windows.RoutedEventHandler(this.BtnBuscarCliente_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.FlyBuscarCliente = ((MahApps.Metro.Controls.Flyout)(target));
            return;
            case 5:
            this.TxtRutBuscar = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.ComboSexoBuscar = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.ComboEstCivilBuscar = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.BtnFiltrar = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.DtgClientes = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 10:
            
            #line 34 "..\..\EliminarCliente.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnSeleccionar_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

