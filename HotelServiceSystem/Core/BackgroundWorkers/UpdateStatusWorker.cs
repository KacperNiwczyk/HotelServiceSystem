using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelServiceSystem.Core.Service;
using HotelServiceSystem.Entities;
using HotelServiceSystem.Interfaces.Helpers;
using HotelServiceSystem.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace HotelServiceSystem.Core.BackgroundWorkers
{
	public class UpdateStatusWorker : IUpdateStatusWorker
	{
		private readonly DateTime _localTime;

		public UpdateStatusWorker()
		{
			_localTime = DateTime.Today.ToLocalTime();
		}

		public async Task UpdateReservationsStatus(HotelServiceDatabaseContext context)
		{
			var hotelReservationService = context.GetService<IHotelReservationService>();
			var roomService = context.GetService<IRoomService>();
			
			var activeReservations = hotelReservationService.GetAllHotelReservations(x => !x.HasFinished);
			var newReservations = activeReservations.Where(HasReservationStarted);
			var hotelReservations = newReservations as HotelReservation[] ?? newReservations.ToArray();
			var finishedReservations = activeReservations.Except(hotelReservations);

			if (activeReservations.Count == 0)
			{
				return;
			}
			
			await HandleFinishedReservations(finishedReservations, hotelReservationService, roomService);
			await HandleNewReservations(hotelReservations, roomService);
		}

		private async Task HandleFinishedReservations(IEnumerable<HotelReservation> finishedReservations, IHotelReservationService hotelReservationService, IRoomService roomService)
		{
			foreach (var reservation in finishedReservations.Where(HasReservationFinished))
			{
				reservation.HasFinished = true;
				foreach (var reservedRoom in reservation.RoomReservations.Select(GetRoom))
				{
					reservedRoom.IsFreeNow = true;
					reservedRoom.ShouldBeCleaned = true;
					await roomService.UpdateRoomAsync(reservedRoom);
				}

				await hotelReservationService.UpdateHotelReservationAsync(reservation);
			}
		}

		private async Task HandleNewReservations(IEnumerable<HotelReservation> newReservations, IRoomService roomService)
		{
			foreach (var room in newReservations.SelectMany(reservation => reservation.RoomReservations.Select(GetRoom)))
			{
				room.IsFreeNow = false;
				await roomService.UpdateRoomAsync(room);
			}
		}

		private bool HasReservationFinished(Reservation reservation) => reservation.DateTo <= _localTime;
		private bool HasReservationStarted(Reservation reservation) => reservation.DateFrom >= _localTime;
		private static Room GetRoom(RoomReservation roomReservation) => roomReservation.Room;
	}
}