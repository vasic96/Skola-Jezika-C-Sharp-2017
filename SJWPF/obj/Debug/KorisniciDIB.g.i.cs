﻿#pragma checksum "..\..\KorisniciDIB.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2C23B6F61FDF1D3AB91BB1866E7A9C64"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SJWPF;
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


namespace SJWPF {
    
    
    /// <summary>
    /// KorisniciDIB
    /// </summary>
    public partial class KorisniciDIB : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\KorisniciDIB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgKorisnici;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\KorisniciDIB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\KorisniciDIB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\KorisniciDIB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbIme;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\KorisniciDIB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label2;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\KorisniciDIB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPrezime;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\KorisniciDIB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbAktivni;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\KorisniciDIB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbObrisani;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\KorisniciDIB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbSvi;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\KorisniciDIB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDodavanje;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\KorisniciDIB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnIzmena;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\KorisniciDIB.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBrisanje;
        
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
            System.Uri resourceLocater = new System.Uri("/SJWPF;component/korisnicidib.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\KorisniciDIB.xaml"
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
            this.dgKorisnici = ((System.Windows.Controls.DataGrid)(target));
            
            #line 14 "..\..\KorisniciDIB.xaml"
            this.dgKorisnici.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgKorisnici_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.tbIme = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\KorisniciDIB.xaml"
            this.tbIme.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbIme_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.tbPrezime = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\KorisniciDIB.xaml"
            this.tbPrezime.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbPrezime_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.rbAktivni = ((System.Windows.Controls.RadioButton)(target));
            
            #line 20 "..\..\KorisniciDIB.xaml"
            this.rbAktivni.Checked += new System.Windows.RoutedEventHandler(this.rbAktivni_Checked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.rbObrisani = ((System.Windows.Controls.RadioButton)(target));
            
            #line 21 "..\..\KorisniciDIB.xaml"
            this.rbObrisani.Checked += new System.Windows.RoutedEventHandler(this.rbObrisani_Checked);
            
            #line default
            #line hidden
            return;
            case 9:
            this.rbSvi = ((System.Windows.Controls.RadioButton)(target));
            
            #line 22 "..\..\KorisniciDIB.xaml"
            this.rbSvi.Checked += new System.Windows.RoutedEventHandler(this.rbSvi_Checked);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnDodavanje = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\KorisniciDIB.xaml"
            this.btnDodavanje.Click += new System.Windows.RoutedEventHandler(this.btnDodavanje_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnIzmena = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\KorisniciDIB.xaml"
            this.btnIzmena.Click += new System.Windows.RoutedEventHandler(this.btnIzmena_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.btnBrisanje = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\KorisniciDIB.xaml"
            this.btnBrisanje.Click += new System.Windows.RoutedEventHandler(this.btnBrisanje_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

