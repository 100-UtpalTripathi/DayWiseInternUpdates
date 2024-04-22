﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApplicationModelLibrary
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }

        public User(string username, string password, UserRole role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }

    public enum UserRole
    {
        Creator,
        Participant
    }
}
