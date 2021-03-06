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
using Xamarin.Forms;
using Xamarin.Essentials;
using DailyNotes.Interface;
using System.IO;
using Android.Graphics;
using DailyNotes.Converter;

namespace DailyNotes.ViewModels
{
	public class NoteAddViewModel : ViewModelBase
	{
		public ReactiveProperty<int> Id { get; } = new ReactiveProperty<int>();
		public ReactiveProperty<string> Name { get; } = new ReactiveProperty<string>();

		public ReactiveProperty<string> Contents { get; } = new ReactiveProperty<string>();

		public ReactiveProperty<DateTime> Input { get; } = new ReactiveProperty<DateTime>();

		public ReactiveProperty<bool> IsPassWord { get; } = new ReactiveProperty<bool>();

		public ReactiveProperty<byte[]> SelectImage { get; } = new ReactiveProperty<byte[]>();

		public ReactiveProperty<bool> SelectedImage { get; } = new ReactiveProperty<bool>(false);


		/// <summary>
		/// 登録ボタン
		/// </summary>
		public AsyncReactiveCommand NoteSubmitCommand { get; } = new AsyncReactiveCommand();

		/// <summary>
		/// 削除ボタン
		/// </summary>
		public AsyncReactiveCommand NoteDeleteCommand { get; } = new AsyncReactiveCommand();

		public AsyncReactiveCommand PermissionCheck { get; } = new AsyncReactiveCommand();

		public AsyncReactiveCommand ImageSelection { get; } = new AsyncReactiveCommand();

		public ObservableCollection<Notes> TestCollection { get; set; } = new ObservableCollection<Notes>();


		/// <summary>
		/// 名前
		/// </summary>
		public ReactiveCommand<string> name { get; set; } = new ReactiveCommand<string>();

		public NoteAddViewModel(INavigationService navigationService) : base(navigationService)
		{
			NoteSubmitCommand.Subscribe(async _ =>
			{
				Notes notes = new Notes
				{
					Id = Id.Value,
					NoteName = Name.Value,
					NoteContents = Contents.Value,
					InputDateTime = Input.Value,
					IsPassWord = IsPassWord.Value,
					ImageByte = SelectImage.Value
				};

				NotesDatabase notesDatabase = await NotesDatabase.Instance;
				// 入力内容を保存
				await notesDatabase.SaveNoteAsync(notes);

				await App.Current.MainPage.DisplayAlert("確認", "データベースに保存されました", "OK");

				// メインページに戻る
				await NavigationService.GoBackAsync();

			}).AddTo(Disposable);

			NoteDeleteCommand.Subscribe(async _ =>
			{
				// 削除対象
				Notes notes = new Notes
				{
					Id = Id.Value,
					NoteName = Name.Value,
					NoteContents = Contents.Value,
					InputDateTime = Input.Value,
					IsPassWord = IsPassWord.Value,
					ImageByte = SelectImage.Value
				};

				NotesDatabase notesDatabase = await NotesDatabase.Instance;

				await notesDatabase.DeleteNoteAsync(notes);

				await App.Current.MainPage.DisplayAlert("確認", "データベースから削除されました", "OK");

				await NavigationService.GoBackAsync();
			});

			PermissionCheck.Subscribe(async _ =>
			{
				var readWritePermission = DependencyService.Get<IReadWritePermission>();

				var status = await readWritePermission.CheckStatusAsync();

				if (status != PermissionStatus.Granted)
				{
					status = await readWritePermission.RequestAsync();
				}
			});

			ImageSelection.Subscribe(async _ =>
			{
				Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
				if (stream != null)
				{
					byte[] imageByte = StreamToByteConverter.StreamToByte(stream);

					SelectImage.Value = imageByte;
					SelectedImage.Value = true;
				}
			});
		}
		public override void OnNavigatedTo(INavigationParameters parameters)
		{
			base.OnNavigatedTo(parameters);

			var note = parameters.GetValue<Notes>("NoteData");
			var selectDate = parameters.GetValue<DateTime>("SelectDate");

			// DBに登録されている場合
			if (note != null)
			{
				Id.Value = note.Id;
				Name.Value = note.NoteName;
				Contents.Value = note.NoteContents;
				Input.Value = note.InputDateTime;
				IsPassWord.Value = note.IsPassWord;
				SelectImage.Value = note.ImageByte;
			}
			// DBに登録されていない場合
			else
			{
				Name.Value = "";
				Contents.Value = "";
				Input.Value = selectDate;
				IsPassWord.Value = false;
				SelectImage.Value = null;
			}

			if (SelectImage.Value == null)
			{
				SelectedImage.Value = false;
			}
			else
			{
				SelectedImage.Value = true;
			}
		}
	}
}
