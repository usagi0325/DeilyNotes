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
using DailyNotes.Views;

namespace DailyNotes.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        /// <summary>
        /// 設定画面を開くコマンド
        /// </summary>
        public AsyncReactiveCommand ShowSettingCommand { get; } = new AsyncReactiveCommand();

        /// <summary>
        /// テストReactivePropaty 
        /// </summary>
        public ReactiveProperty<string> testMozi { get; set; } = new ReactiveProperty<string>("こんばんわ");

        public ReactiveProperty<string> testMozi2 { get; set; } = new ReactiveProperty<string>();

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            // タイトルの設定
            Title = "メイン画面";

            testMozi2.Value = "テストバインディング";

            ShowSettingCommand.Subscribe(async _ =>
            {
                Console.WriteLine("ボタンが押されたよ");
                await NavigationService.NavigateAsync(typeof(SettingView).Name);
            }).AddTo(Disposable);

        }

        
    }
}
