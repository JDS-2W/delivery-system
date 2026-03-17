namespace DeliverySystem.Models
{
    public class Table
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public bool IsOccupied { get; set; } = false;
    }
}