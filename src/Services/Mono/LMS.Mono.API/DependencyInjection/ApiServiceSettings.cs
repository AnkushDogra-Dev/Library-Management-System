namespace src.Services.Mono.DependencyInjection 
{
    public record ApiServiceSettings
    {
        public Dictionary<string, ApiSettings> Apis { get; set; } = new();

        public Uri? GetBaseUri(string key)
        {
            var settings = Apis.GetValueOrDefault(key);
            if (settings is not null)
            {
                return new Uri(settings.BaseUrl);
            }
            return null;
        }
    }

    public record ApiSettings
    {
        public string BaseUrl { get; set; } = string.Empty;

    }
}