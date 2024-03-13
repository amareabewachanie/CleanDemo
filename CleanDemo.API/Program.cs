using CleanDemo.API;

var builder = WebApplication.CreateBuilder(args);



var app = builder
    .ConfigureServices().ConfgiurePipeline();
await app.ResetDatabaseAsync();

app.Run();
