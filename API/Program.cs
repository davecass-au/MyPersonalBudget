using API.Data;
using API.Services.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddDbContext<MyBudgetDbContext>(opts => opts.UseSqlServer(builder.Configuration["ConnectionString:MyBudgetDB"]));
builder.Services.AddScoped<IServicesRepository, ServicesRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, 
        policy =>
        {
            policy.WithOrigins("https://localhost:7124", "https://localhost:7272")
                .AllowAnyHeader()
                .WithMethods("PUT", "DELETE", "POST", "GET");
        }
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Must be placed after UseRouting and before UseAuthorization. 
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
