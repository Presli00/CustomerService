namespace CustomerService.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string FamilyName { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
