using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Reactive.Bindings;
using System.ComponentModel;
using Reactive.Bindings.Extensions;

namespace DailyNotes.ViewModels
{
    public class SettingViewModel : ViewModelBase
    {
        public SettingViewModel()
        {

        }
        public SettingViewModel(INavigationService navigationService)
            : base(navigationService)
        {

            // タイトルの設定
            Title = "設定画面";

            Diapose();
        }
    }
}
