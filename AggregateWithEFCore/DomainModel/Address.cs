namespace AggregateWithEFCore.DomainModel
{
    public class Address
    {
        public string AddressLine { get; private set; }

        private Address() { }

        public Address(string addressLine)
        {
            AddressLine = addressLine;
        }
    }
}
