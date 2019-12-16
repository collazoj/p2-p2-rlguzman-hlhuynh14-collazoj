using System.Collections.Generic;

namespace BudgetMe.Client.Models
{
  public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Budget> BudgetList { get; set; }

    }
}
