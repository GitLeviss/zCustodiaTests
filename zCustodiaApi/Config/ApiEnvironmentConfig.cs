using System.Text.Json;

namespace zCustodiaApi.Config;

public static class ApiEnvironmentConfig
{
    private static readonly JsonElement _config;

    static ApiEnvironmentConfig()
    {
        var env = Environment.GetEnvironmentVariable("env") ?? "api";
        var path = Path.Combine(AppContext.BaseDirectory, "environments", $"{env}.json");
        if (!File.Exists(path))
            throw new FileNotFoundException($"Arquivo de configuração não encontrado: {path}");

        var json = File.ReadAllText(path);
        // 💡 Tolerante a //comentários e vírgulas no final
        var options = new JsonDocumentOptions
        {
            CommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true
        };
        using var doc = JsonDocument.Parse(json, options);
        _config = doc.RootElement.Clone();
    }

    public static string Get(string key)
    {
        var parts = key.Split('.');
        JsonElement current = _config;
        foreach (var part in parts)
        {
            if (!current.TryGetProperty(part, out var next))
                throw new KeyNotFoundException($"Chave '{key}' não encontrada no arquivo JSON");
            current = next;
        }
        return current.ValueKind switch
        {
            JsonValueKind.String => current.GetString() ?? string.Empty,
            _ => current.ToString() // permite ler objetos/arrays como string JSON
        };
    }
}
