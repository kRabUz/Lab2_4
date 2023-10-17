namespace Lab2_4.Classes
{
    public class Apartment
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int Floor { get; set; }
        public double Square { get; set; }
        public int Rooms { get; set; }
        public override string ToString()
        {
            return $"{Address}, {Floor}-й поверх, площа - {Square} м.кв., {Rooms} кімнат";
        }
    }
}
