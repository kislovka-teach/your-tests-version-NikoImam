﻿namespace VariantOne.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public int Rating { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
