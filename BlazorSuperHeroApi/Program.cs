using BlazorSuperHeroApi;

var builder = WebApplication.CreateBuilder(args);

LoadDotEnv(builder.Environment.ContentRootPath);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

static void LoadDotEnv(string contentRootPath)
{
    var candidatePaths = new[]
    {
        Path.Combine(contentRootPath, ".env"),
        Path.Combine(Directory.GetCurrentDirectory(), ".env"),
        Path.Combine(contentRootPath, "..", ".env")
    };

    var envFile = candidatePaths.FirstOrDefault(File.Exists);
    if (envFile is null)
    {
        return;
    }

    foreach (var rawLine in File.ReadAllLines(envFile))
    {
        var line = rawLine.Trim();
        if (string.IsNullOrEmpty(line) || line.StartsWith('#'))
        {
            continue;
        }

        var separatorIndex = line.IndexOf('=');
        if (separatorIndex <= 0)
        {
            continue;
        }

        var key = line[..separatorIndex].Trim();
        var value = line[(separatorIndex + 1)..].Trim().Trim('"', '\'');

        if (!string.IsNullOrEmpty(key) && string.IsNullOrEmpty(Environment.GetEnvironmentVariable(key)))
        {
            Environment.SetEnvironmentVariable(key, value);
        }
    }
}
