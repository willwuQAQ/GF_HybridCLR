#region Request

namespace Game.Hotfix
{
    [System.Serializable]
    public class RequestConfig
    {
        public RequestData login;
        public RequestData logout;
    }

    [System.Serializable]
    public class RequestData
    {
        public string url;
        public RequestBody body;
    }

    [System.Serializable]
    public class RequestBody
    {
        public RequestPublicData @public;
        public RequestParamsData @params;
    }

    [System.Serializable]
    public class RequestPublicData
    {
        public string version;
        public string lang;
        public string sig;
        public string channel;
        public string system_model;
        public string system_os;
        public string system_version;
        public string app_version;
        public string system_supported_abis;
        public string network_type;
        public string device_brand_name;
        public string package_name;
        public string android_id;
    }

    [System.Serializable]
    public class RequestParamsData
    {
        public int user_id;
        public int debug;
    }

}

#endregion

