namespace Lab2_4.Classes
{
    public class Realtor
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public override string ToString()
        {
            return $"Ріелтор - {Name}, номер телефону - {PhoneNumber}";
        }
    }
}
