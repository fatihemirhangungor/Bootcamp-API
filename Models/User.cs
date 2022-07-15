namespace Odev2.Models
{
    public class User
    {
        //User Id
        public int Id { get; set; }
        //User Name
        public string Name { get; set; }
        //Control variable if user is accepted for the bootcamp or not
        public bool Confirmed { get; set; }

        //Constructor
        public User(int id, string name, bool confirmed)
        {
            Id = id;
            Name = name;
            Confirmed = confirmed;
        }
    }
}
