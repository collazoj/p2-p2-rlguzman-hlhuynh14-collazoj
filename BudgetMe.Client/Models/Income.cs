namespace BudgetMe.Client.Models
{
  public class Income
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public Budget Budget { get; set; }
        public int? BudgetId { get; set; }
    }
}
