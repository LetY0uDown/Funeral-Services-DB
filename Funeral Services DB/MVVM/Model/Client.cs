using System;

namespace Funeral_Services_DB.MVVM.Model
{
    public class Client
    {
        public string Name { get; set; }
        public string Surname { get; set; } = "Фамилия";
        public string SecondName { get; set; }

        public DateTime BirthDate { get; set; } = DateTime.Today;
        public DateTime DeathDate { get; set; } = DateTime.Today;

        public double Height { get; set; }

        public Grave Grave { get; set; }
    }
}
