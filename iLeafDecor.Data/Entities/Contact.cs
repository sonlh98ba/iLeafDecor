using iLeafDecor.Data.Enum;

namespace iLeafDecor.Data.Entities
{
    public class Contact
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string Message { set; get; }
        public Status Status { set; get; }

    }
}
