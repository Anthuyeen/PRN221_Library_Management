﻿#pragma checksum "..\..\..\BookManager.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8798141554240FD1D2C282AD2E57246BB59BF5F1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Project_Library_Management_FA23_BL5;
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


namespace Project_Library_Management_FA23_BL5 {
    
    
    /// <summary>
    /// BookManager
    /// </summary>
    public partial class BookManager : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 20 "..\..\..\BookManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchByName;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\BookManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox gbRadioButtons;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\BookManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReload;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\BookManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteTitle;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\BookManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEditTitle;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\BookManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteBook;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\BookManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddBook;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\BookManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listView;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Project_Library_Management_FA23_BL5;component/bookmanager.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\BookManager.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.searchByName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.gbRadioButtons = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 3:
            
            #line 31 "..\..\..\BookManager.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Search);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnReload = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\BookManager.xaml"
            this.btnReload.Click += new System.Windows.RoutedEventHandler(this.Button_Reload);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnDeleteTitle = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\BookManager.xaml"
            this.btnDeleteTitle.Click += new System.Windows.RoutedEventHandler(this.Button_Delete_Title);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnEditTitle = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\BookManager.xaml"
            this.btnEditTitle.Click += new System.Windows.RoutedEventHandler(this.Button_Edit_Title);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnDeleteBook = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\BookManager.xaml"
            this.btnDeleteBook.Click += new System.Windows.RoutedEventHandler(this.Button_Delete_Book);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnAddBook = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\BookManager.xaml"
            this.btnAddBook.Click += new System.Windows.RoutedEventHandler(this.Button_OpenCreate_Book);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 51 "..\..\..\BookManager.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_OpenCreate_Title);
            
            #line default
            #line hidden
            return;
            case 10:
            this.listView = ((System.Windows.Controls.ListView)(target));
            
            #line 57 "..\..\..\BookManager.xaml"
            this.listView.SizeChanged += new System.Windows.SizeChangedEventHandler(this.ListView_SizeChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 11:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.ListBoxItem.SelectedEvent;
            
            #line 61 "..\..\..\BookManager.xaml"
            eventSetter.Handler = new System.Windows.RoutedEventHandler(this.ListViewItem_Selected);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}

