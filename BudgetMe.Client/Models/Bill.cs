﻿namespace BudgetMe.Client.Models
{
  public class Bill 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public int? BudgetId { get; set; }

    }
}
