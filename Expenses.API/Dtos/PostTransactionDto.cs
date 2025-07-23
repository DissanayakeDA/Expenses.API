namespace Expenses.API.Dtos
{
    public class PostTransactionDto
    {

        public String Type { get; set; }
        public double Amount { get; set; }

        public String Category { get; set; }
        public int UserId { get; set; }

    }
}
