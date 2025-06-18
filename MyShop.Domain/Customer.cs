namespace MyShop.Domain
{
    public class Customer
    {
        public Guid CustomerId { get; set; }

        public string Name { get; set; }
        public string ShippingAddress { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        //The properties on the entity uses the value holder to lazily retrieve the data
        public byte[] ProfilePicture {
            get
            {
                return ProfilePictureValueHolder.Value;
            }
        }
        public Lazy<byte[]> ProfilePictureValueHolder { get; set; }

        public Customer()
        {
            CustomerId = Guid.NewGuid();
        }
    }
}