using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyNotes.Models
{
    [Table("Notes")]
    public class Notes
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [MaxLength(64)]
        public string NoteName { get; set; }

        [MaxLength(1024)]
        public string NoteContents { get; set; }

        public bool SwitchState { get; set; }

        public DateTime InputDateTime {get; set;}
    }
}
