using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ZY.Util
{
    [Serializable]
    [DataContract]
    public class OAuth2Token
    {
        [DataMember]
        public string access_token { get; set; }

        [DataMember]
        public int expires_in { get; set; }

        [DataMember]
        public string refresh_token { get; set; }

        [DataMember]
        public string openid { get; set; }

        [DataMember]
        public string scope { get; set; }

        [DataMember]
        public string unionid { get; set; }
    }
}
