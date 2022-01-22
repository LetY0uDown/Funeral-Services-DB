using System;

namespace Funeral_Services_DB.MVVM.Model
{
    public class Ceremony
    {
        public Grave Grave { get; set; }
        public Client Client { get; set; }

        public DateTime CeremonyDate { get; set; } = DateTime.Today;
        public string StartTime { get; set; }

        public decimal Price { get; set; }

        public bool IsComplited { get; set; }
    }
}
