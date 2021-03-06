using System.Linq;
using HotelServiceSystem.ViewModel;

namespace HotelServiceSystem.Entities
{
    public class EventReservation : Reservation
    {
        public string Description { get; set; }
        
        public void UpdateFrom(EventReservationViewModel reservationViewModel)
        {
            Client = reservationViewModel.Client;
            NumberOfGuests = reservationViewModel.NumberOfGuests;
            DateFrom = reservationViewModel.DateFrom;
            DateTo = reservationViewModel.DateTo;
            Price = reservationViewModel.Price;
            DateOfSubmission = reservationViewModel.DateOfSubmission;
            Discount = reservationViewModel.Discount;
            HasFinished = reservationViewModel.HasFinished;
            RoomReservations = reservationViewModel.SelectedRooms.Select(x => new RoomReservation() {Room = x, Reservation = this})
                .ToList();
            AdditionalServiceReservations = reservationViewModel.SelectedAdditionalServices.Select(x => new AdditionalServiceReservation() {AdditionalService = x, Reservation = this})
                .ToList();
            Description = reservationViewModel.Description;
        }
    }
}