using BudgetMe.Domain.Models;

namespace BudgetMe.Domain.Abstracts
{
    public abstract class ABalance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public Budget Budget { get; set; }
    }
}