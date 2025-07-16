namespace Expenses.API.Models.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
