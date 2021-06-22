using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Text;

namespace DailyNotes.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }


        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


        /// <summary>
        /// Disposeが必要なreactivePropertyやReactiveCommandを集約させるための仕掛け
        /// </summary>
        /// <see cref="https://qiita.com/YSRKEN/items/5a36fb8071104a989fb8"/>
        protected CompositeDisposable Disposable { get; } = new CompositeDisposable();

        /// <summary>
        /// Disposeするためにメソッドを用意
        /// </summary>
        public void Diapose() => Disposable.Dispose();

        public ViewModelBase() { }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
