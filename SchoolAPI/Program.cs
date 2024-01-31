using GraphQL;
using GraphQL.Server.Ui.Playground;
using SchoolAPI;
using SchoolAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<TeacherNotification>();
builder.Services.AddGraphQL(b => b
  .AddSchema<SchoolSchema>()
  .AddSystemTextJson()
  .AddGraphTypes(typeof(SchoolSchema).Assembly)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
  app.UseGraphQLPlayground("/", new PlaygroundOptions());
}

app.UseWebSockets();
app.UseGraphQL<SchoolSchema>();

app.Run();
