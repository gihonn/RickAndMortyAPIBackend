using RickAndMortyAPIBackend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin() // Permite cualquier origen
               .AllowAnyMethod() // Permite cualquier método (GET, POST, etc.)
               .AllowAnyHeader(); // Permite cualquier cabecera
    });
});

builder.Services.AddHttpClient<RickAndMortyApiService>();
builder.Services.AddScoped<RickAndMortyApiService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
