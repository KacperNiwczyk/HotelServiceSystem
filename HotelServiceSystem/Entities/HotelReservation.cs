using System;
using System.Collections.Generic;
using System.Linq;
using HotelServiceSystem.ViewModel;

namespace HotelServiceSystem.Entities
{
    public class HotelReservation : Reservation
    {
        public void UpdateFrom(HotelReservationViewModel reservationViewModel)
        {
            Client = reservationViewModel.Client;
            NumberOfGuests = reservationViewModel.NumberOfGuests;
            DateFrom = reservationViewModel.DateRange.Start ?? DateTime.Today.ToLocalTime();
            DateTo = reservationViewModel.DateRange.End ?? DateTime.Today.ToLocalTime();
            Price = reservationViewModel.Price;
            DateOfSubmission = reservationViewModel.DateOfSubmission;
            Discount = reservationViewModel.Discount;
            HasFinished = reservationViewModel.HasFinished;
            RoomReservations = reservationViewModel.SelectedRooms.Select(x => new RoomReservation() {Room = x, Reservation = this})
                .ToList();
            AdditionalServiceReservations = reservationViewModel.SelectedAdditionalServices.Select(x => new AdditionalServiceReservation() {AdditionalService = x, Reservation = this})
                .ToList();
        }
    }
}