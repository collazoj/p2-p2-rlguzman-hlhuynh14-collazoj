using System.Collections.Generic;

namespace SaveEm.Domain.Models
{
  public class Member
    {
        // [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Budget> BudgetList { get; set; }
    }
}
