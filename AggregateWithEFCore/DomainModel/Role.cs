namespace AggregateWithEFCore.DomainModel
{
    public class Role
    {
        public int Id { get; private set; }
        public string RoleName { get; private set; }

        private Role() { }

        public Role(string roleName)
        {
            RoleName = roleName;
        }
    }
}
