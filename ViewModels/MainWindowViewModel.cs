using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows;

namespace Assignment.ViewModels
{
    internal class MainWindowViewModel : BindableBase
    {
        #region Private Fields

        private List<string> _tabs;

        #endregion

        #region Public Properties

        public List<string> Tabs
        {
            get { return _tabs; }
            set { SetProperty(ref _tabs, value); }
        }

        private DelegateCommand<MouseButtonEventArgs> _dragCommand;
        public DelegateCommand<MouseButtonEventArgs> DragCommand
        {
            get
            {
                return _dragCommand ?? (_dragCommand = new DelegateCommand<MouseButtonEventArgs>((e) =>
                {
                    
                }));
            }
        }


        #endregion

        #region Public Constructors

        public MainWindowViewModel()
        {
            Tabs = new List<string>() { "New Tab", "Tab1" };
        }

        #endregion
    }
}