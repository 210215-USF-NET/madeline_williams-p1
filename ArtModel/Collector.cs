﻿using System;


namespace ArtModel
{
    public class Collector : ICollector
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Location { get; set; }
        public String Email { get; set; }
    }
}