using System;
using System.Threading;
using System.Threading.Tasks;
using HotelServiceSystem.Core;
using HotelServiceSystem.Interfaces.Helpers;
using HotelServiceSystem.Interfaces.Services;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HotelServiceSystem
{
	public class UpdateStatusBackgroundService : BackgroundService
	{
		private readonly IServiceScopeFactory _serviceScopeFactory;
		private readonly IUpdateStatusWorker _updateStatusWorker;

		public UpdateStatusBackgroundService(IServiceScopeFactory serviceScopeFactory, IUpdateStatusWorker updateStatusWorker)
		{
			_serviceScopeFactory = serviceScopeFactory;
			_updateStatusWorker = updateStatusWorker;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			using (var scope = _serviceScopeFactory.CreateScope())
			{
				var context = scope.ServiceProvider.GetRequiredService<HotelServiceDatabaseContext>();

				while (!stoppingToken.IsCancellationRequested)
				{
					await Task.Delay(TimeSpan.FromMinutes(15), stoppingToken);
					await _updateStatusWorker.UpdateReservationsStatus(context);
				}
			}
		}
	}
}