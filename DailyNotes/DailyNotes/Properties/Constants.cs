using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DailyNotes.Properties
{
    static class Constants
    {
        /// <summary>
        /// 日々ノートの情報を保存しているDBパス
        /// </summary>
        public const string DailyNotes_DBname = "DailyNotes.db";

        /// <summary>
        /// SQLがどの状態かのフラグ
        /// </summary>
        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath , DailyNotes_DBname);
            }
        }
    }
}
