namespace FetuerismTask.Models
{
    public class OrderCountModel
    {
        
        public string CustomerName { get; set; }
        public DateTime? OrderDate { get; set; }

        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
       
    }
}
