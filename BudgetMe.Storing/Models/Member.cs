using System.Collections.Generic;

namespace BudgetMe.Storing.Models
{
  public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Budget Budget { get; set; }
    }
}
