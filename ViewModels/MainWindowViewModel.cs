using Prism.Commands;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows;

namespace Assignment.ViewModels
{
    internal class MainWindowViewModel : BindableBase
    {
        #region Private Fields

        private const double _headerMargin = 12;
        private DelegateCommand _addTabCommand;
        private DelegateCommand<Window> _closeCommand;
        private DelegateCommand<TabViewModel> _closeTabCommand;
        private double _headerWidth = 100;
        private DelegateCommand<Window> _minimizeCommand;
        private TabViewModel _selectedTab;
        private ObservableCollection<TabViewModel> _tabs;
        private string _toggleButtonContent;
        private DelegateCommand<Window> _toggleCommand;

        #endregion

        #region Public Properties

        public DelegateCommand AddTabCommand
        {
            get
            {
                return _addTabCommand ?? (_addTabCommand = new DelegateCommand(() =>
                {
                    var tab = new TabViewModel(_headerWidth);
                    Tabs.Add(tab);
                    SelectedTab = tab;
                }));
            }
        }

        public Thickness ButtonAddMargin => new Thickness(Tabs.Count * (_headerWidth + _headerMargin) + 10, 0, 0, 0);

        public DelegateCommand<Window> CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new DelegateCommand<Window>((window) =>
                {
                    if (window != null)
                    {
                        Application.Current.Shutdown();
                    }
                }));
            }
        }

        public DelegateCommand<TabViewModel> CloseTabCommand
        {
            get
            {
                return _closeTabCommand ?? (_closeTabCommand = new DelegateCommand<TabViewModel>((tab) =>
                {
                    Tabs.Remove(tab);
                }));
            }
        }

        public DelegateCommand<Window> MinimizeCommand
        {
            get
            {
                return _minimizeCommand ?? (_minimizeCommand = new DelegateCommand<Window>((window) =>
                {
                    if (window != null)
                    {
                        window.WindowState = WindowState.Minimized;
                    }
                }));
            }
        }

        public TabViewModel SelectedTab
        {
            get { return _selectedTab; }
            set { SetProperty(ref _selectedTab, value); }
        }

        public ObservableCollection<TabViewModel> Tabs
        {
            get { return _tabs; }
            set { SetProperty(ref _tabs, value); }
        }

        public string ToggleButtonContent
        {
            get { return _toggleButtonContent; }
            set { SetProperty(ref _toggleButtonContent, value); }
        }

        public DelegateCommand<Window> ToggleCommand
        {
            get
            {
                return _toggleCommand ?? (_toggleCommand = new DelegateCommand<Window>((window) =>
                {
                    if (window != null)
                    {
                        if (ToggleButtonContent == "\uE003")
                        {
                            window.WindowState = WindowState.Maximized;
                            ToggleButtonContent = "\uE923";
                        }
                        else if (ToggleButtonContent == "\uE923")
                        {
                            window.WindowState = WindowState.Normal;
                            ToggleButtonContent = "\uE003";
                        }
                    }
                }));
            }
        }

        #endregion

        #region Public Constructors

        public MainWindowViewModel()
        {
            Tabs = new ObservableCollection<TabViewModel>() { new TabViewModel(_headerWidth) };
            SelectedTab = Tabs[0];
            Tabs.CollectionChanged += OnTabsCollectionChanged;
            ToggleButtonContent = "\uE003";
        }

        #endregion

        #region Private Methods

        private void OnTabsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(ButtonAddMargin));
        }

        #endregion
    }
}