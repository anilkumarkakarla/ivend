using System.Runtime.Serialization;

namespace CXS.Core.Entities
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string UserName { get; set; }
    }
}
