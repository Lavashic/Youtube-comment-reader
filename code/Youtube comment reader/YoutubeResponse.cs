// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

using System.Collections.Generic;
using Newtonsoft.Json;

public class Param
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class ServiceTrackingParam
    {
        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("params")]
        public List<Param> Params { get; set; }
    }

    public class MainAppWebResponseContext
    {
        [JsonProperty("loggedOut")]
        public bool LoggedOut { get; set; }
    }

    public class WebResponseContextExtensionData
    {
        [JsonProperty("hasDecorated")]
        public bool HasDecorated { get; set; }
    }

    public class ResponseContext
    {
        [JsonProperty("serviceTrackingParams")]
        public List<ServiceTrackingParam> ServiceTrackingParams { get; set; }

        [JsonProperty("mainAppWebResponseContext")]
        public MainAppWebResponseContext MainAppWebResponseContext { get; set; }

        [JsonProperty("webResponseContextExtensionData")]
        public WebResponseContextExtensionData WebResponseContextExtensionData { get; set; }
    }

    public class TimedContinuationData
    {
        [JsonProperty("timeoutMs")]
        public int TimeoutMs { get; set; }

        [JsonProperty("continuation")]
        public string Continuation { get; set; }
    }

    public class Continuation
    {
        [JsonProperty("timedContinuationData")]
        public TimedContinuationData TimedContinuationData { get; set; }
        [JsonProperty("reloadContinuationData")]
        public TimedContinuationData ReloadContinuationData { get; set; }
    }

    public class Thumbnail
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }

    public class AccessibilityData
    {
        [JsonProperty("label")]
        public string Label { get; set; }
    }

    public class Accessibility
    {
        [JsonProperty("accessibilityData")]
        public AccessibilityData AccessibilityData { get; set; }
    }

    public class Image
    {
        [JsonProperty("thumbnails")]
        public List<Thumbnail> Thumbnails { get; set; }

        [JsonProperty("accessibility")]
        public Accessibility Accessibility { get; set; }
    }

    public class Emoji
    {
        [JsonProperty("emojiId")]
        public string EmojiId { get; set; }

        [JsonProperty("shortcuts")]
        public List<string> Shortcuts { get; set; }

        [JsonProperty("searchTerms")]
        public List<string> SearchTerms { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("supportsSkinTone")]
        public bool? SupportsSkinTone { get; set; }
    }

    public class Run
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("emoji")]
        public Emoji Emoji { get; set; }
    }

    public class Message
    {
        [JsonProperty("runs")]
        public List<Run> Runs { get; set; }
    }

    public class AuthorName
    {
        [JsonProperty("simpleText")]
        public string SimpleText { get; set; }
    }

    public class AuthorPhoto
    {
        [JsonProperty("thumbnails")]
        public List<Thumbnail> Thumbnails { get; set; }
    }

    public class WebCommandMetadata
    {
        [JsonProperty("ignoreNavigation")]
        public bool IgnoreNavigation { get; set; }
    }

    public class CommandMetadata
    {
        [JsonProperty("webCommandMetadata")]
        public WebCommandMetadata WebCommandMetadata { get; set; }
    }

    public class LiveChatItemContextMenuEndpoint
    {
        [JsonProperty("params")]
        public string Params { get; set; }
    }

    public class ContextMenuEndpoint
    {
        [JsonProperty("commandMetadata")]
        public CommandMetadata CommandMetadata { get; set; }

        [JsonProperty("liveChatItemContextMenuEndpoint")]
        public LiveChatItemContextMenuEndpoint LiveChatItemContextMenuEndpoint { get; set; }
    }

    public class ContextMenuAccessibility
    {
        [JsonProperty("accessibilityData")]
        public AccessibilityData AccessibilityData { get; set; }
    }

    public class LiveChatTextMessageRenderer
    {
        [JsonProperty("message")]
        public Message Message { get; set; }

        [JsonProperty("authorName")]
        public AuthorName AuthorName { get; set; }

        [JsonProperty("authorPhoto")]
        public AuthorPhoto AuthorPhoto { get; set; }

        [JsonProperty("contextMenuEndpoint")]
        public ContextMenuEndpoint ContextMenuEndpoint { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("timestampUsec")]
        public string TimestampUsec { get; set; }

        [JsonProperty("authorExternalChannelId")]
        public string AuthorExternalChannelId { get; set; }

        [JsonProperty("contextMenuAccessibility")]
        public ContextMenuAccessibility ContextMenuAccessibility { get; set; }
    }

    public class Item
    {
        [JsonProperty("liveChatTextMessageRenderer")]
        public LiveChatTextMessageRenderer LiveChatTextMessageRenderer { get; set; }
    }

    public class AddChatItemAction
    {
        [JsonProperty("item")]
        public Item Item { get; set; }

        [JsonProperty("clientId")]
        public string ClientId { get; set; }
    }

    public class Action
    {
        [JsonProperty("addChatItemAction")]
        public AddChatItemAction AddChatItemAction { get; set; }
    }

    public class LiveChatContinuation
    {
        [JsonProperty("continuations")]
        public List<Continuation> Continuations { get; set; }

        [JsonProperty("actions")]
        public List<Action> Actions { get; set; }
    }

    public class ContinuationContents
    {
        [JsonProperty("liveChatContinuation")]
        public LiveChatContinuation LiveChatContinuation { get; set; }
    }

    public class YoutubeResponse
    {
        [JsonProperty("responseContext")]
        public ResponseContext ResponseContext { get; set; }

        [JsonProperty("continuationContents")]
        public ContinuationContents ContinuationContents { get; set; }
    }

