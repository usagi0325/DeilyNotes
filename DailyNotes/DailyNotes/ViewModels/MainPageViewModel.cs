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
using DailyNotes.Service;
using System.Collections.ObjectModel;
using DailyNotes.Models;
using DailyNotes.Data;
using System.Threading.Tasks;

namespace DailyNotes.ViewModels
{
	public class MainPageViewModel : ViewModelBase
	{
		/// <summary>
		/// 設定画面を開くコマンド
		/// </summary>
		public AsyncReactiveCommand ShowSettingCommand { get; } = new AsyncReactiveCommand();

		/// <summary>
		/// 登録画面を開くコマンド
		/// </summary>
		public AsyncReactiveCommand ShowNoteAddCommand { get; } = new AsyncReactiveCommand();

		/// <summary>
		/// データベース取得（テスト）
		/// </summary>
		public AsyncReactiveCommand GetDBCommand { get; } = new AsyncReactiveCommand();

		public AsyncReactiveCommand PushSelectedDate { get; } = new AsyncReactiveCommand();

		public ReactiveProperty<DateTime> SelectedDate { get; set; } = new ReactiveProperty<DateTime>();

		/// <summary>
		/// リフレッシュの状態
		/// </summary>
		public ReactiveProperty<bool> IsRefreshing { get; set; } = new ReactiveProperty<bool>(false);


		ReactiveProperty<bool> IsPullToRefreshEnabled { get; set; } = new ReactiveProperty<bool>(true);

		/// <summary>
		/// 一覧を選択した時のコマンド
		/// </summary>
		public AsyncReactiveCommand SelectedItemCommand { get; } = new AsyncReactiveCommand();

		public ObservableCollection<Notes> TestCollection { get; set; } = new ObservableCollection<Notes>();

		public ReactiveProperty<bool> SelectedItem { get; set; } = new ReactiveProperty<bool>();

		public MainPageViewModel(INavigationService navigationService)
			: base(navigationService)
		{
			// タイトルの設定
			Title = "メイン画面";

			ShowSettingCommand.Subscribe(async _ =>
			{
				await NavigationService.NavigateAsync(typeof(SettingView).Name);

			}).AddTo(Disposable);

			PushSelectedDate.Subscribe(async _ =>
			{
				var selectDateTime = SelectedDate.Value;
				try
				{
					NotesDatabase notesDatabase = await NotesDatabase.Instance;

					// 該当する日時のデータを取得する
					var note = await notesDatabase.GetNoteAsync(selectDateTime);

					// DBに登録されていない場合
					if (note != null)
					{
						// 一度現在のコレクションを消す
						TestCollection.Clear();
						TestCollection.Add(note);
						TestCollection.ToCollectionChanged();
					}
					// DBに登録されていた場合
					else
					{
						TestCollection.Clear();
						Notes notes = new Notes
						{
							Id = 0,
							NoteName = "",
							NoteContents = "登録なし",
							InputDateTime = selectDateTime,
							IsPassWord = false,
							PassWord = "",
							ImageByte = null
						};
						TestCollection.Add(notes);
						TestCollection.ToCollectionChanged();
					}
				}
				catch (Exception e)
				{
					TestCollection.Clear();
				}
			});

			ShowNoteAddCommand.Subscribe(async _ =>
			{
				var selectDateTime = SelectedDate.Value;

				NotesDatabase notesDatabase = await NotesDatabase.Instance;

				// 該当する日時のデータを取得する
				var note = await notesDatabase.GetNoteAsync(selectDateTime);
				
				var navigationParameters = new NavigationParameters();
				navigationParameters.Add("NoteData", note);
				navigationParameters.Add("SelectDate", selectDateTime);
				await NavigationService.NavigateAsync(typeof(NoteAddView).Name, navigationParameters);
			}).AddTo(Disposable);

			GetDBCommand.Subscribe(async _ =>
			{
				IsRefreshing.Value = true;
				NotesDatabase notesDatabase = await NotesDatabase.Instance;

				var lists = await notesDatabase.GetNotesAsync();
				// 一度現在のコレクションを消す
				TestCollection.Clear();

				lists.ForEach(x => TestCollection.Add(x));
				TestCollection.ToCollectionChanged();

				IsRefreshing.Value = false;

			});

			SelectedItemCommand.Subscribe(async TestCollection =>
			{

				var navigationParameters = new NavigationParameters();
				navigationParameters.Add("Collection", TestCollection);
				await NavigationService.NavigateAsync(typeof(NoteAddView).Name, navigationParameters);
			}).AddTo(Disposable);
		}
		public override void OnNavigatedTo(INavigationParameters parameters)
		{
			//Task.Run(async () =>
			//{
			//	NotesDatabase notesDatabase = await NotesDatabase.Instance;

			//	var lists = await notesDatabase.GetNotesAsync();
			//	// 一度現在のコレクションを消す
			//	TestCollection.Clear();
			//	lists.ForEach(x => TestCollection.Add(x));
			//	TestCollection.ToCollectionChanged();
			//});
		}
	}
}
