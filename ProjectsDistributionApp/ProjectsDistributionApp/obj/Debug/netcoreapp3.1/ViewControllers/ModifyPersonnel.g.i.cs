﻿#pragma checksum "..\..\..\..\ViewControllers\ModifyPersonnel.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6CF9C8B15741718EDBF7A9C18A01B9A2F3602B92"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjectsDistributionApp.ViewControllers;
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


namespace ProjectsDistributionApp.ViewControllers {
    
    
    /// <summary>
    /// ModifyPersonnel
    /// </summary>
    public partial class ModifyPersonnel : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\ViewControllers\ModifyPersonnel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Panel;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\ViewControllers\ModifyPersonnel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SecondName;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\ViewControllers\ModifyPersonnel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FirstName;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\ViewControllers\ModifyPersonnel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Patronymic;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\ViewControllers\ModifyPersonnel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MaxLoad;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\ViewControllers\ModifyPersonnel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox SkillsList;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ProjectsDistributionApp;component/viewcontrollers/modifypersonnel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\ViewControllers\ModifyPersonnel.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Panel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.SecondName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.FirstName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Patronymic = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.MaxLoad = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.SkillsList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 7:
            
            #line 21 "..\..\..\..\ViewControllers\ModifyPersonnel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddSkill);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 29 "..\..\..\..\ViewControllers\ModifyPersonnel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Submit);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 36 "..\..\..\..\ViewControllers\ModifyPersonnel.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancel);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
