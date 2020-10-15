namespace APIGateway.Models
{
    public class Visitor
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string GetFullName()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}
