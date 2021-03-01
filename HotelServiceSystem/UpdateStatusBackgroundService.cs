using System.Threading;
using System.Threading.Tasks;
using HotelServiceSystem.Interfaces;
using HotelServiceSystem.Interfaces.Helpers;
using Microsoft.Extensions.Hosting;

namespace HotelServiceSystem
{
	public class UpdateStatusBackgroundService : BackgroundService
	{
		private readonly IUpdateStatusWorker _updateStatusWorker;
		private readonly IGeneralSettings _generalSettings;

		public UpdateStatusBackgroundService(IUpdateStatusWorker updateStatusWorker, IGeneralSettings generalSettings)
		{
			_updateStatusWorker = updateStatusWorker;
			_generalSettings = generalSettings;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				await Task.Delay((int)_generalSettings.UpdateInterval, stoppingToken);
				_updateStatusWorker.UpdateReservationsStatus();
			}
		}
	}
}