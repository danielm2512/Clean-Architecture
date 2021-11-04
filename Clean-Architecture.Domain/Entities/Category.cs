using Clean_Architecture.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        public Category(int id, string name)
        {
            DomainExecptionValidation.When(id < 0, "Invalid Id Value");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public ICollection<Product> Products { get; set; }

        private void ValidateDomain(string name)
        {
            DomainExecptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name.Name is required");

            DomainExecptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimun 3 charecters");
            Name = name;
        }
    }
}
