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

        public ObservableCollection<Notes> TestCollection { get; set; } = new ObservableCollection<Notes>();

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            // タイトルの設定
            Title = "メイン画面";

            TestCollection = new ObservableCollection<Notes>()
                    {
                        new Notes() { Id = 999 ,
                                      NoteName = "テストだよ",
                                      NoteContents = "テストテストテストテスト",
                                      Done = true}
                    };



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

                foreach (var list in lists)
                {
                    // DBの値をコレクションに代入
                    TestCollection.Add(list);
                }
                TestCollection.ToCollectionChanged();
            });
        }


    }
}
