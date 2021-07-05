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
    public class NoteAddViewModel : ViewModelBase
    {
        public ReactiveProperty<string> Name { get; } = new ReactiveProperty<string>();

        public ReactiveProperty<string> Contents { get; } = new ReactiveProperty<string>();

        public ReactiveProperty<DateTime> Input { get; } = new ReactiveProperty<DateTime>();

        public ReactiveProperty<bool> IsDone { get; } = new ReactiveProperty<bool>();

        /// <summary>
        /// 登録ボタン
        /// </summary>
        public AsyncReactiveCommand NoteSubmitCommand { get; } = new AsyncReactiveCommand();

        /// <summary>
        /// 削除ボタン
        /// </summary>
        public AsyncReactiveCommand NoteDeleteCommand { get; } = new AsyncReactiveCommand();


        /// <summary>
        /// 名前
        /// </summary>
        public ReactiveCommand<string> name { get; set; } = new ReactiveCommand<string>();

        public NoteAddViewModel(INavigationService navigationService) : base(navigationService)
        {
            NoteSubmitCommand.Subscribe(async _ =>
            {
                Notes notes = new Notes { NoteName = Name.Value, NoteContents = Contents.Value, InputDateTime = Input.Value, Done = IsDone.Value };

                NotesDatabase notesDatabase = await NotesDatabase.Instance;
                // 入力内容を保存
                await notesDatabase.SaveNoteAsync(notes);
            }).AddTo(Disposable);

            NoteDeleteCommand.Subscribe(async _ =>
            {
                await Task.Delay(10);
                Console.WriteLine("押されました");
            });
        }
    }
}
