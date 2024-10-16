var builder = WebApplication.CreateBuilder(args);
{
    //Configure DI
    builder.Services.AddControllers();
}
var app = builder.Build();
{
    //Configure Middleware (HTTP request pipeline)
    app.MapControllers(); //namapuje všechny controllers v projektu
}

app.Run();
