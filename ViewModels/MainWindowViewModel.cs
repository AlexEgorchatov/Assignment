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
        private DelegateCommand<TabViewModel> _closeTabCommand;
        private double _headerWidth = 100;
        private ObservableCollection<TabViewModel> _tabs;

        #endregion

        #region Public Properties

        public DelegateCommand AddTabCommand
        {
            get
            {
                return _addTabCommand ?? (_addTabCommand = new DelegateCommand(() =>
                {
                    Tabs.Add(new TabViewModel(_headerWidth));
                }));
            }
        }

        public Thickness ButtonAddMargin => new Thickness(Tabs.Count * (_headerWidth + _headerMargin) + 10, 0, 0, 0);

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

        public ObservableCollection<TabViewModel> Tabs
        {
            get { return _tabs; }
            set { SetProperty(ref _tabs, value); }
        }

        #endregion

        #region Public Constructors

        public MainWindowViewModel()
        {
            Tabs = new ObservableCollection<TabViewModel>() { new TabViewModel(_headerWidth) };
            Tabs.CollectionChanged += OnTabsCollectionChanged;
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