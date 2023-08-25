using HaliSaham.Repository;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;
using NLog;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
LogManager.Configuration = new NLogLoggingConfiguration(config.GetSection("NLog"));

builder.Services.AddLogging(loggingBuilder => {
    loggingBuilder.ClearProviders();
    loggingBuilder.AddNLog();
});

builder.Services.AddDbContext<RepositoryContext>(opts => opts.UseSqlServer("Data Source =DESKTOP-7HODA89\\SQLEXPRESS; Initial Catalog=HaliSahamDb; Integrated Security=true; TrustServerCertificate=True"));
builder.Services.AddScoped<RepositoryWrapper, RepositoryWrapper>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

/*
 * JWT Authentication için eklenmesi gereken kodlar
 */
builder.Services.AddAuthentication(x => {
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o => {
    var Key = Encoding.UTF8.GetBytes("ETicaretKeyVektorelAhlatciGrupDersi");
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Key)
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/error-development");
}
else
{
    app.UseExceptionHandler("/error");

}

app.UseHttpsRedirection();

app.UseCors(options => { options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });

app.UseAuthorization();

app.MapControllers();


app.Run();
