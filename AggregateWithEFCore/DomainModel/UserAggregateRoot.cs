using System.Collections.Generic;

namespace AggregateWithEFCore.DomainModel
{
    public class UserAggregateRoot
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        // C'est une Value Object
        public Address Address { get; private set; }

        // Une collection d'entités en Read Only

        private readonly List<Role> _roles = new List<Role>();
        public IReadOnlyCollection<Role> Roles => _roles;


        // Pour EF Core
        private UserAggregateRoot() { }

        public UserAggregateRoot(string firstName, string lastName, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }

        public void AddRole(Role role)
        {
            _roles.Add(role);
        }
    }
}
