using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using DailyNotes.Models;
using DailyNotes.Service;
using DailyNotes.Properties;

namespace DailyNotes.Data
{
    public class NotesDatabase
    {
        static SQLiteAsyncConnection Database;

        /// <summary>
        /// インスタンスを生成し、テーブルを作成する
        /// </summary>
        public static readonly AsyncLazy<NotesDatabase> Instance = new AsyncLazy<NotesDatabase>(async () =>
        {
            var instance = new NotesDatabase();
            CreateTableResult result = await Database.CreateTableAsync<Notes>();
            return instance;
        });

        /// <summary>
        /// コンストラクタ（DBファイルパスと、DBの状態を定義）
        /// </summary>
        public NotesDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        /// <summary>
        /// DBに登録しているアイテムをリスト形式で取得する。
        /// </summary>
        /// <returns></returns>
        public Task <List<Notes>> GetNotesAsync()
        {
            return Database.Table<Notes>().ToListAsync();
        }
        /// <summary>
        /// 登録されていない場合アイテム
        /// </summary>
        /// <returns></returns>
        public Task <List<Notes>> GetNoteNotDoneAsync()
        {
            return Database.QueryAsync<Notes>("SELECT * FROM [Notes] WHERE [Done] = 0");
        }

        public Task<Notes> GetNoteAsync(int idNo)
        {
            return Database.Table<Notes>().Where(x => x.Id == idNo).FirstOrDefaultAsync();
        }

        public Task<Notes> GetNoteAsync(DateTime dateTime){
            return Database.Table<Notes>().Where(x => x.InputDateTime == dateTime).FirstOrDefaultAsync();
		}

        /// <summary>
        /// ノートを登録する
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public Task<int> SaveNoteAsync(Notes note)
        {
            // ほかに登録しているアイテムがあればアップデート
            if(note.Id != 0)
            {
                return Database.UpdateAsync(note);
            }
            // ほかに登録しているアイテムがなければインサート
            else
            {
                return Database.InsertAsync(note);
            }
        }
        /// <summary>
        /// ノートを削除する
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public Task<int> DeleteNoteAsync(Notes note)
        {
            return Database.DeleteAsync(note);
        }
    }
}
