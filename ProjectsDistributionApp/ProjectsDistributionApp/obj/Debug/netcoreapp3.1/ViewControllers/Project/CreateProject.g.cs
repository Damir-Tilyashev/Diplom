﻿#pragma checksum "..\..\..\..\..\ViewControllers\Project\CreateProject.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5EEC6C323B708F55DFB30C63070AB1323973C8CD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
    /// CreateProject
    /// </summary>
    public partial class CreateProject : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\..\ViewControllers\Project\CreateProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ProjectName;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\ViewControllers\Project\CreateProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Description;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\ViewControllers\Project\CreateProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Status;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\..\ViewControllers\Project\CreateProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Priority;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\..\ViewControllers\Project\CreateProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Calendar Start;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\..\ViewControllers\Project\CreateProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Calendar End;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\..\ViewControllers\Project\CreateProject.xaml"
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
            System.Uri resourceLocater = new System.Uri("/ProjectsDistributionApp;component/viewcontrollers/project/createproject.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\ViewControllers\Project\CreateProject.xaml"
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
            this.ProjectName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Description = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Status = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Priority = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Start = ((System.Windows.Controls.Calendar)(target));
            return;
            case 6:
            this.End = ((System.Windows.Controls.Calendar)(target));
            return;
            case 7:
            this.SkillsList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 8:
            
            #line 83 "..\..\..\..\..\ViewControllers\Project\CreateProject.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddRole);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 93 "..\..\..\..\..\ViewControllers\Project\CreateProject.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancel);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

