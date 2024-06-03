var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();

app.Use(async (context, next) =>
{
    await next.Invoke(context);

    if (context.Response.StatusCode == 200)
    {
        var streamWriter = new StreamWriter(context.Response.Body);
        await streamWriter.WriteAsync("Hello from middleware!");
        await streamWriter.FlushAsync();
    }
});

app.Run();