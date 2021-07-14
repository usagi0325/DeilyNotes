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



        ReactiveProperty<bool> selected { get; set; } = new ReactiveProperty<bool>(false);

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

            ShowNoteAddCommand.Subscribe(async _ =>
            {
                await NavigationService.NavigateAsync(typeof(NoteAddView).Name);
            }).AddTo(Disposable);

            GetDBCommand.Subscribe(async _ =>
            {
                NotesDatabase notesDatabase = await NotesDatabase.Instance;

                var lists = await notesDatabase.GetNotesAsync();
                // 一度現在のコレクションを消す
                TestCollection.Clear();

                lists.ForEach(x => TestCollection.Add(x));
                TestCollection.ToCollectionChanged();

            });

            SelectedItemCommand.Subscribe(async TestCollection =>
            {
                var navigationParameters = new NavigationParameters();
                navigationParameters.Add("Collection", TestCollection);
                //{
                //    {"Id" , TestCollection.Select(x => x.Id)},
                //    { "NoteName" , TestCollection.Select(x => x.NoteName)},
                //    { "NoteContents" , TestCollection.Select(x => x.NoteContents)},
                //    { "InputDateTime", DateTime.Now },
                //    { "Done" , true}
                //};
                await NavigationService.NavigateAsync(typeof(NoteAddView).Name, navigationParameters);
            }).AddTo(Disposable);
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Task.Run(async () =>
            {
                NotesDatabase notesDatabase = await NotesDatabase.Instance;

                var lists = await notesDatabase.GetNotesAsync();
                // 一度現在のコレクションを消す
                TestCollection.Clear();
                lists.ForEach(x => TestCollection.Add(x));
                TestCollection.ToCollectionChanged();
            });
        }
    }
}
