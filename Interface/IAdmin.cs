﻿using RailwayReservationJWT.Models;

namespace RailwayReservationJWT.Interface
{
    public interface IAdmin
    {
        public Admin Get(string name);
        public List<Admin> GetAll();
        public Admin Delete(string name);
        public void Add(Admin admin);
        public Admin Update(string name, Admin admin);
    }
}