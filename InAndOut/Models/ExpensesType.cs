namespace InAndOut.Models
{
    public class ExpensesType
    {
        [key]
        public int Id { get; set; }

        [required]
        public string Name { get; set; }
    }
}
