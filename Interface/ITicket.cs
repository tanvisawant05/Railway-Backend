using RailwayReservationJWT.Models;

namespace RailwayReservationJWT.Interface
{
    public interface ITicket
    {
        public Ticket Get(int id);
        public List<Ticket> GetAll();
        public Ticket Delete(int id);
        public void Add(Ticket bookingDetail);
        public Ticket Update(int id, Ticket bookingDetail);
    }
}