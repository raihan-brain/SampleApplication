﻿namespace SampleApplication.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? Email { get; set; } = "";
        public double BillingRate{ get; set; }
        public string? ImageUrl { get; set; }

    }
}
