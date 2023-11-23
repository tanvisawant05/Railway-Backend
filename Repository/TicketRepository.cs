﻿using RailwayReservationJWT.Data;
using RailwayReservationJWT.Interface;
using RailwayReservationJWT.Models;


namespace RailwayReservationJWT.Repository
{
    public class TicketRepository : ITicket
    {
        private readonly RailwayContext _context;
        public TicketRepository(RailwayContext context)
        {
            _context = context;
        }
        public Ticket Get(int id)
        {
            return _context.tickets.FirstOrDefault(u => u.TicketNo == id);
        }
        public List<Ticket> GetAll()
        {
            return _context.tickets.ToList();
        }
        public Ticket Delete(int id)
        {
            Ticket ticket = _context.tickets.FirstOrDefault(u => u.TicketNo == id);
            if (ticket != null)
            {
                _context.tickets.Remove(ticket);
                _context.SaveChanges();
            }
            return ticket;
        }
        public void Add(Ticket ticket)
        {
            _context.tickets.Add(ticket);
            _context.SaveChanges();
        }
        public Ticket Update(int id, Ticket ticket)
        {
            Ticket ticket1 = _context.tickets.FirstOrDefault();
            if (ticket1 != null)
            {
                ticket1 = ticket;
                _context.SaveChanges();
            }
            return ticket1;
        }
    }
}