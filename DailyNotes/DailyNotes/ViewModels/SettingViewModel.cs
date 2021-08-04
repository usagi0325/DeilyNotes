﻿using Prism.Commands;
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

		public AsyncReactiveCommand test2 { get; } = new AsyncReactiveCommand();

		public AsyncReactiveCommand test3 { get; } = new AsyncReactiveCommand();

		public AsyncReactiveCommand test4 { get; } = new AsyncReactiveCommand();

		public ReactiveProperty<string> AppName { get; } = new ReactiveProperty<string>();

		public ReactiveProperty<string> AppVersion { get; } = new ReactiveProperty<string>();


		public SettingViewModel()
		{

		}
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

			test2.Subscribe(async _ =>
			{
				await NavigationService.NavigateAsync(typeof(MainPage).Name);

			}).AddTo(Disposable);

			test3.Subscribe(async _ =>
			{
				await NavigationService.NavigateAsync(typeof(ItemsPage).Name);

			}).AddTo(Disposable);

			test4.Subscribe(async _ =>
			{
				await NavigationService.NavigateAsync(typeof(LoginPage).Name);

			}).AddTo(Disposable);



			Diapose();
		}
	}
}
