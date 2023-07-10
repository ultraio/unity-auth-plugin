using System;

namespace Ultraio
{
    public class UltraToken
    {
        public string access_token;
        public string id_token;
        public int expires_in;
        public int refresh_expires_in;
        public string refresh_token;
        public string token_type;
        public string session_state;
        public string scope;
    }
}