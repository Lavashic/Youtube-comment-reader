using System.Collections.Generic;

namespace Youtube_comment_reader
{
    public class ConfigInfo
    {
        [Newtonsoft.Json.JsonProperty("appInstallData")] public string AppInstallData { get; set; }
    }

    public class MainAppWebInfo
    {
        [Newtonsoft.Json.JsonProperty("graftUrl")] public string GraftUrl { get; set; }

        [Newtonsoft.Json.JsonProperty("isWebNativeShareAvailable")]
        public bool IsWebNativeShareAvailable { get; set; }

        [Newtonsoft.Json.JsonProperty("webDisplayMode")] public string WebDisplayMode { get; set; }
    }

    public class Client
    {
        [Newtonsoft.Json.JsonProperty("browserName")] public string BrowserName { get; set; }

        [Newtonsoft.Json.JsonProperty("browserVersion")] public string BrowserVersion { get; set; }

        [Newtonsoft.Json.JsonProperty("clientFormFactor")] public string ClientFormFactor { get; set; }

        [Newtonsoft.Json.JsonProperty("clientName")] public string ClientName { get; set; }

        [Newtonsoft.Json.JsonProperty("clientVersion")] public string ClientVersion { get; set; }

        [Newtonsoft.Json.JsonProperty("configInfo")] public ConfigInfo ConfigInfo { get; set; }

        [Newtonsoft.Json.JsonProperty("connectionType")] public string ConnectionType { get; set; }

        [Newtonsoft.Json.JsonProperty("deviceMake")] public string DeviceMake { get; set; }

        [Newtonsoft.Json.JsonProperty("deviceModel")] public string DeviceModel { get; set; }

        [Newtonsoft.Json.JsonProperty("gl")] public string Gl { get; set; }

        [Newtonsoft.Json.JsonProperty("hl")] public string Hl { get; set; }

        [Newtonsoft.Json.JsonProperty("mainAppWebInfo")] public MainAppWebInfo MainAppWebInfo { get; set; }

        [Newtonsoft.Json.JsonProperty("originalUrl")] public string OriginalUrl { get; set; }

        [Newtonsoft.Json.JsonProperty("osName")] public string OsName { get; set; }

        [Newtonsoft.Json.JsonProperty("osVersion")] public string OsVersion { get; set; }

        [Newtonsoft.Json.JsonProperty("platform")] public string Platform { get; set; }

        [Newtonsoft.Json.JsonProperty("remoteHost")] public string RemoteHost { get; set; }

        [Newtonsoft.Json.JsonProperty("screenDensityFloat")] public int ScreenDensityFloat { get; set; }

        [Newtonsoft.Json.JsonProperty("screenHeightPoints")] public int ScreenHeightPoints { get; set; }

        [Newtonsoft.Json.JsonProperty("screenPixelDensity")] public int ScreenPixelDensity { get; set; }

        [Newtonsoft.Json.JsonProperty("screenWidthPoints")] public int ScreenWidthPoints { get; set; }

        [Newtonsoft.Json.JsonProperty("timeZone")] public string TimeZone { get; set; }

        [Newtonsoft.Json.JsonProperty("userAgent")] public string UserAgent { get; set; }

        [Newtonsoft.Json.JsonProperty("userInterfaceTheme")] public string UserInterfaceTheme { get; set; }

        [Newtonsoft.Json.JsonProperty("utcOffsetMinutes")] public int UtcOffsetMinutes { get; set; }

        [Newtonsoft.Json.JsonProperty("visitorData")] public string VisitorData { get; set; }
    }

    public class User
    {
        [Newtonsoft.Json.JsonProperty("lockedSafetyMode")] public bool LockedSafetyMode { get; set; }
    }

    public class Request
    {
        [Newtonsoft.Json.JsonProperty("consistencyTokenJars")] public List<object> ConsistencyTokenJars { get; set; }

        [Newtonsoft.Json.JsonProperty("internalExperimentFlags")]
        public List<object> InternalExperimentFlags { get; set; }

        [Newtonsoft.Json.JsonProperty("useSsl")] public bool UseSsl { get; set; }
    }

    public class AdSignalsInfo
    {
        [Newtonsoft.Json.JsonProperty("params")] public List<Param> Params { get; set; }
    }

    public class Context
    {
        [Newtonsoft.Json.JsonProperty("adSignalsInfo")] public AdSignalsInfo AdSignalsInfo { get; set; }

        [Newtonsoft.Json.JsonProperty("client")] public Client Client { get; set; }

        [Newtonsoft.Json.JsonProperty("request")] public Request Request { get; set; }

        [Newtonsoft.Json.JsonProperty("user")] public User User { get; set; }
    }

    public class WebClientInfo
    {
        [Newtonsoft.Json.JsonProperty("isDocumentHidden")] public bool IsDocumentHidden { get; set; }
    }

    public class PayloadParameters
    {
        [Newtonsoft.Json.JsonProperty("context")] public Context Context { get; set; }

        [Newtonsoft.Json.JsonProperty("continuation")] public string Continuation { get; set; }

        [Newtonsoft.Json.JsonProperty("webClientInfo")] public WebClientInfo WebClientInfo { get; set; }
    }
}