namespace MyShop.Domain
{
    public class Customer
    {
        public Guid CustomerId { get; set; }

        public virtual string Name { get; set; }
        public virtual string ShippingAddress { get; set; }
        public virtual string City { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Country { get; set; }
        ////The properties on the entity uses the value holder to lazily retrieve the data
        //public byte[] ProfilePicture {
        //    get
        //    {
        //        return ProfilePictureValueHolder.Value;
        //    }
        //}
        //public Lazy<byte[]> ProfilePictureValueHolder { get; set; }

        public virtual byte[] ProfilePicture { get; set; }

        public Customer()
        {
            CustomerId = Guid.NewGuid();
        }
    }
}