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

namespace DailyNotes.ViewModels
{
    public class NoteAddViewModel : ViewModelBase
    {
        /// <summary>
        /// 登録ボタン
        /// </summary>
        AsyncReactiveCommand NoteSubmitCommand { get; } = new AsyncReactiveCommand();

        /// <summary>
        /// 削除ボタン
        /// </summary>
        AsyncReactiveCommand NoteDeleteCommand { get; } = new AsyncReactiveCommand();

        /// <summary>
        /// 名前
        /// </summary>
        public ReactiveCommand<string> name { get; set; } = new ReactiveCommand<string>();
    }
}
