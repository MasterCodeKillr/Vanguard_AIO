﻿#pragma checksum "..\..\..\..\Dialogs\AddCreator.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F5D67D49717E6ECB978E5CAABA4CE777E891CEC6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using Vanguard_AIO.Dialogs;


namespace Vanguard_AIO.Dialogs {
    
    
    /// <summary>
    /// AddCreator
    /// </summary>
    public partial class AddCreator : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\..\Dialogs\AddCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nametb;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Dialogs\AddCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox twitchUrltb;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Dialogs\AddCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox youtubeUrltb;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Dialogs\AddCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox twitterUrltb;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Dialogs\AddCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btAddCreator;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Vanguard_AIO;component/dialogs/addcreator.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Dialogs\AddCreator.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.nametb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.twitchUrltb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.youtubeUrltb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.twitterUrltb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btAddCreator = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\Dialogs\AddCreator.xaml"
            this.btAddCreator.Click += new System.Windows.RoutedEventHandler(this.btAddCreator_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

