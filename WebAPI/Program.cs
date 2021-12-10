using BusinessLayer.Abstracts;
using BusinessLayer.Concretes;
using BusinessLayer.Mapping;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Concretes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Token:Issuer"],
        ValidAudience = builder.Configuration["Token:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddSingleton<ICustomerDal>(new CustomerDal());
builder.Services.AddSingleton<ICustomerService,CustomerService>();

builder.Services.AddScoped<IMovieDal, MovieDal>();
builder.Services.AddScoped<IMovieService,MovieService>();

builder.Services.AddSingleton<IDirectorDal>(new DirectorDal());
builder.Services.AddSingleton<IDirectorService, DirectorService>();

builder.Services.AddSingleton<IMoviePlayerDal>(new MoviePlayerDal());

builder.Services.AddSingleton<IPlayerDal>(new PlayerDal());
builder.Services.AddSingleton<IPlayerService, PlayerService>();

builder.Services.AddScoped<IOrderDal,OrderDal>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

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

//app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
