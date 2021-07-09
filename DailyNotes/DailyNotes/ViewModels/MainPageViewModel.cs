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

        ReactiveProperty<bool> _selectedItem;
        public ReactiveProperty<bool> SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;

                if (_selectedItem == null)
                {
                    return;
                }
                SelectedItemCommand.Execute(_selectedItem);

                SelectedItem = null;
            }
        }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            // タイトルの設定
            Title = "メイン画面";

            // 画面表示にDBを読み込む
            Task.Run(async () =>
            {
                NotesDatabase notesDatabase = await NotesDatabase.Instance;

                var lists = await notesDatabase.GetNotesAsync();
                // 一度現在のコレクションを消す
                TestCollection.Clear();
                lists.ForEach(x => TestCollection.Add(x));
                TestCollection.ToCollectionChanged();
            });
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

            SelectedItemCommand.Subscribe(async _ =>
            {
                await NavigationService.NavigateAsync(typeof(NoteAddView).Name);
            }).AddTo(Disposable);
        }


    }
}
