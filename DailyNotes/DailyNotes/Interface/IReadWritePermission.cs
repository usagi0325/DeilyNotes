using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DailyNotes.Interface
{
	public interface IReadWritePermission
	{
		Task<PermissionStatus> CheckStatusAsync();

		Task<PermissionStatus> RequestAsync();
	}
}
