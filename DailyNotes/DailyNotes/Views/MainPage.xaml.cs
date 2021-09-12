using DailyNotes.Models;
using System.Threading.Tasks;
using Xamarin.Forms;
using PublicHoliday;
using System;
using System.Collections.Generic;

namespace DailyNotes.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var nowYear = DateTime.Now.Year;

            SetHoliday(nowYear);
            SetWeekend(nowYear);
        }
        /// <summary>
        /// カレンダーの祝日の色を赤色にする(VMに移動できたらしたい・・)
        /// </summary>
        /// <param name="year"></param>
        private void SetHoliday(int year){

            IList<DateTime> result = new JapanPublicHoliday().PublicHolidays(year);

            foreach(var holiday in result){
                _calendar.SpecialDates.Add(new XamForms.Controls.SpecialDate(holiday)
                {
                    TextColor = Color.Red
				});
			}
		}
        /// <summary>
        /// カレンダーの土日の色を変更する（こちらもVMに移動できたらしたい・・・）
        /// </summary>
        /// <param name="year"></param>
        private void SetWeekend(int year){
            DateTime starDate = new DateTime(year, 1, 1);
            DateTime endDate = new DateTime(year, 12, 31);

            // 元旦から正月までの曜日確認
            for(var day = starDate.Date; day.Date <= endDate.Date; day = day.AddDays(1)){

                if(DayOfWeek.Saturday == day.DayOfWeek){
                    _calendar.SpecialDates.Add(new XamForms.Controls.SpecialDate(day) {
                        TextColor = Color.Blue
                    });
				}
                else if(DayOfWeek.Sunday == day.DayOfWeek){
                    _calendar.SpecialDates.Add(new XamForms.Controls.SpecialDate(day)
                    { 
                        TextColor = Color.Red
                    });
				}
			}
		}
    }
}
