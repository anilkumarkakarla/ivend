using System;

namespace CXS.Mpos.Core
{
	//[Serializable]
	public  class OfflineUser: User
    {
        public string HashedPwd { get; set; }
    }
}
