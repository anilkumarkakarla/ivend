using System.Runtime.Serialization;

namespace CXS.Core.Entities
{
    [DataContract]
    public  class OfflineUser: User
    {
        [DataMember]
        public string HashedPwd { get; set; }
    }
}
