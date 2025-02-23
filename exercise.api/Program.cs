using exercise.api.DataContext;
using exercise.api.EndPoint;
using exercise.api.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<ISalaryRepo, SalaryRepo>();
builder.Services.AddScoped<IDepartRepo, DepartRepo>();

builder.Services.AddDbContext<EmployeeContext>();



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

app.ConfigureEmployeeApi();
app.ConfigureSalaryApi();
app.ConfigureDepartmentApi();

app.Seed();

app.Run();
