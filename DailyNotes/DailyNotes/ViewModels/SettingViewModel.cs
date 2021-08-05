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
using Xamarin.Forms;
using DailyNotes.Interface;
using Xamarin.Essentials;

namespace DailyNotes.ViewModels
{
	public class SettingViewModel : ViewModelBase
	{

		public AsyncReactiveCommand ShowTermsAndConditions { get; } = new AsyncReactiveCommand();

		public ReactiveProperty<string> AppVersion { get; } = new ReactiveProperty<string>();

		public SettingViewModel(INavigationService navigationService)
			: base(navigationService)
		{

			// タイトルの設定
			Title = "設定画面";

			AppVersion.Value = "バージョン：" + AppInfo.VersionString;

			ShowTermsAndConditions.Subscribe(async _ =>
			{
				await NavigationService.NavigateAsync(typeof(TermsAndConditionsView).Name);
			}).AddTo(Disposable);
		}
	}
}
