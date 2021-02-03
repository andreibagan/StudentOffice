namespace StudentOffice.Models
{
    public class Spravka
    {
        public int SpravkaId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public string OrganizationName { get; set; }
        public TypeOfSpravka TypeOfSpravka { get; set; }
        public string AdditionalInformation { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
