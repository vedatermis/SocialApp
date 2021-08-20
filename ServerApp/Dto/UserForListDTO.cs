﻿using ServerApp.Models;
using System;
using System.Collections.Generic;


namespace ServerApp.Dto
{
    public class UserForListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Image> Images { get; set; }
    }
}
