﻿using BookWebApi.Entities.Enums;

namespace BookWebApi.Comunication.Response
{
    public class ResponseBookJson
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public double Price { get; set; }
        public int QuantityStock { get; set; }
    }
}
