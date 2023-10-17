namespace Lab2_4.Classes
{
    public class Agency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public override string ToString()
        {
            return $"Агенство {Name}, {Address}";
        }
    }
}
