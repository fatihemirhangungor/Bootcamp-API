namespace Odev2.Models
{
    public class BootCamp
    {
        //List of bootcamps, it is public and static to reach it out from other classes
        //It has two bootcamps as defaults
        public static List<BootCamp> _bootCamps = new List<BootCamp>() {
            new BootCamp(1, "Bootcamp 1", new List<User>()),
            new BootCamp(2, "Bootcamp 2", new List<User>())
        };

        //Bootcamp Id
        public int Id { get; set; }
        //Bootcamp Name
        public string Name { get; set; }
        //List of participants of the bootcamp
        public List<User> Participants { get; set; }

        //Constructor
        public BootCamp(int id, string name, List<User> participants)
        {
            Id = id;
            Name = name;
            Participants = participants;
        }


    }
}
