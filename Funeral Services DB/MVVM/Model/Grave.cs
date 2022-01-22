namespace Funeral_Services_DB.MVVM.Model
{
    public class Grave
    {
        public Client Client { get; set; }

        public int Number { get; set; }

        public int Row { get; set; }
        public int Place { get; set; }

        public double Lenght { get; set; }
        public double Width { get; set; }

        public decimal Price { get; set; }
    }
}
