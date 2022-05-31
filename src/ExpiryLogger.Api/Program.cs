using ExpiryLogger.Api.Helpers;
using ExpiryLogger.Api.Services;
using ExpiryLogger.DataAccessLayer;
using ExpiryLogger.DataAccessLayer.Entities;
using ExpiryLogger.DataAccessLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();

// configure strongly-typed settings object
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// configure DI for application services
builder.Services
    .AddScoped<IUserService, UserService>()
    .AddEntityFrameworkMySql().AddDbContext<ExpirationLoggerContext>()
    .AddScoped<IRepository<Category>, MariaDbRepository<Category>>()
    .AddScoped<IRepository<Location>, MariaDbRepository<Location>>()
    .AddScoped<IRepository<Product>, MariaDbRepository<Product>>()
    .AddScoped<IRepository<ProductDetail>, ProductDetailsRepository>()
    .AddScoped<IRepository<User>, MariaDbRepository<User>>()
    ;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // global CORS policy
    app.UseCors(cpb => cpb.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

    // custom JWT auth middleware
    app.UseMiddleware<JwtMiddleware>();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
