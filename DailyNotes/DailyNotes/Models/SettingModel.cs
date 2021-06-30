using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DailyNotes.Models
{
    [Table("setting")]
    public class SettingModel
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [MaxLength(8)]
        public string Symbol { get; set; }

        public bool SwitchState { get; set;}
    }
}
