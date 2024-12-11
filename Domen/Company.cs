using System.Drawing;

namespace Domain
{
    public class Company
    {
        private Company(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Guid Id { get; set; }    
        public string Name { get; set; }
        public string Description { get; set; }

        public Company Create(string name, string description)
        {            
            ArgumentNullException.ThrowIfNull(name);
            ArgumentNullException.ThrowIfNull(description);

            var company = new Company(new Guid(), name, description);

            return company;
        }
    }
}
