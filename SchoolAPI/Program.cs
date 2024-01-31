var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) { }

app.MapGet("/hello", () =>
{
  return "Hello World!";
});

app.Run();
