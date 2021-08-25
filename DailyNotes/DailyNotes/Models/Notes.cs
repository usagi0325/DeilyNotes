using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyNotes.Models
{
    [Table("Notes")]
    public class Notes
    {
        /// <summary>
        /// ノートID
        /// </summary>
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        /// <summary>
        /// ノート名
        /// </summary>
        [MaxLength(64)]
        public string NoteName { get; set; }

        /// <summary>
        /// ノート本文
        /// </summary>
        [MaxLength(1024)]
        public string NoteContents { get; set; }

        /// <summary>
        /// 登録時間
        /// </summary>
        public DateTime InputDateTime { get; set; }

        /// <summary>
        /// パスワードを掛けるかどうか
        /// </summary>
        public bool IsPassWord { get; set; }

        /// <summary>
        /// パスワード
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// イメージのバイト配列
        /// </summary>
        public byte[] ImageByte { get; set; }
    }
}
