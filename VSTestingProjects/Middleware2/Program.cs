var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();

app.Use(async (context, next) =>
{
    var y = context.Request.Headers["y"].ToString();
    var yConverted = int.Parse(y);
    var path = context.Request.Path;

    if (path.Value != null && yConverted < path.Value.Length)
        throw new ArgumentException("Header y must be greater than path length");

    await next.Invoke();
});

app.Run();