﻿using AppointmentManagementModelLibrary;
using System.Collections.Generic;
using System.Linq;

namespace AppointmentManagementDALLibrary
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        private readonly Dictionary<int, Appointment> _appointments;

        public AppointmentRepository()
        {
            _appointments = new Dictionary<int, Appointment>();
        }

        private int GenerateId()
        {
            if (_appointments.Count == 0)
                return 1;
            int id = _appointments.Keys.Max();
            return ++id;
        }

        public Appointment Add(Appointment item)
        {
            if (_appointments.ContainsValue(item))
            {
                return null;
            }
            item.Id = GenerateId();
            _appointments.Add(item.Id, item);
            return item;
        }

        public Appointment Delete(int key)
        {
            if (_appointments.ContainsKey(key))
            {
                var appointment = _appointments[key];
                _appointments.Remove(key);
                return appointment;
            }
            return null;
        }

        public Appointment Get(int key)
        {
            return _appointments.ContainsKey(key) ? _appointments[key] : null;
        }

        public List<Appointment> GetAll()
        {
            if (_appointments.Count == 0)
                return null;
            return _appointments.Values.ToList();
        }

        public Appointment Update(Appointment item)
        {
            if (_appointments.ContainsKey(item.Id))
            {
                _appointments[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}
