using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;
using DailyNotes.Models;
using DailyNotes.Properties;

namespace DailyNotes.Service
{
    public class SqlAccess
    {
        ///// <summary>
        ///// DBのパスからどのDBとコネクションするかを指定
        ///// </summary>
        ///// <param name="dbPath">DBのパス</param>
        ///// <returns></returns>
        //private static SQLiteConnection DBConnection(string dbName)
        //{
        //    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), dbName);
            
        //    SQLiteConnection db = new SQLiteConnection(dbPath);

        //    return db;
        //}
        ///// <summary>
        ///// DBファイルを作成する
        ///// </summary>
        //public static void DBCreate()
        //{
        //    // ログに出す予定
        //    Console.WriteLine("データベースを作成するよ！");

        //    //☆以下は、各画面ごとに処理が変わるようにする予定
        //    // SQLに接続(存在してなければ自動で作成してくれる)
        //    var db = DBConnection(Constants.DailyNotes_DB_Path);

        //    db.CreateTable<SettingModel>();

        //    // DBとのコネクションを切る
        //    db.Close();
        //}

        ///// <summary>
        ///// インサート処理（色々改変が必要そう・・・）
        ///// </summary>
        //public static void DBInsert()
        //{
        //    Console.WriteLine("データベースにインサートするよ！！");

        //    var db = DBConnection(Constants.DailyNotes_DB_Path);

        //    // データベースのテーブルに情報がなければ
        //    if(db.Table<SettingModel>().Count() == 0)
        //    {
        //        // データベースが存在しない場合のみ挿入
        //        var newSettingModel = new SettingModel();

        //        newSettingModel.Symbol = "TEST1";
        //        newSettingModel.SwitchState = true;
        //        db.Insert(newSettingModel);

        //        // 2つ目以降を入れる際は、新しくインスタンスを生成する。
        //        newSettingModel = new SettingModel();
        //        newSettingModel.Symbol = "TEST2";
        //        newSettingModel.SwitchState = false;
        //        db.Insert(newSettingModel);
        //    }
        //    Console.WriteLine("一応読み込むよ");
        //    var table = db.Table<SettingModel>();
        //    foreach(var a in table)
        //    {
        //        Console.WriteLine(a.Id + " " + a.Symbol);
        //    }
        //    db.Close();
        //}

        //public static void DBSelect()
        //{
        //    var db = DBConnection(Constants.DailyNotes_DB_Path);

        //    var table = db.Table<SettingModel>();
        //    foreach (var a in table)
        //    {
        //        Console.WriteLine(a.Id + " " + a.Symbol);
        //    }
        //    db.Close();

        //    //var stocksStartingWithA = db.Query<SettingModel>("SELECT * FROM Items WHERE Symbol = ?", "1");
        //    //foreach (var s in stocksStartingWithA)
        //    //{
        //    //    Console.WriteLine("a " + s.Symbol);
        //    //}
        //    //db.Close();
        //}

        //public static void DBDelete()
        //{
        //    // 主キーを指定して削除しているのかな？　クエリを発行することでもう少し色々できそうだな・・・
        //    var db = DBConnection(Constants.DailyNotes_DB_Path);
        //    var rowCount = db.Delete<SettingModel>(1);
        //    db.Close();
        //}
    }
}
