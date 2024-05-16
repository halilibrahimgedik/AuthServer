using SharedLibrary.Configuration;
using SharedLibrary.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();






// ! Options Pattern
builder.Services.Configure<CustomTokenOptions>(builder.Configuration.GetSection("TokenOption"));
// object instance
var tokenOptions = builder.Configuration.GetSection("TokenOption").Get<CustomTokenOptions>();

// Extension Method for Validating  AccessToken
builder.Services.AddCustomTokenAuth(tokenOptions);


// *** Claim-Based Authorization ***
// .net bizden bir policy, bir �artname tan�mlamam�z� istiyor;

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("IstanbulPolicy", policy =>
    {
        policy.RequireClaim("city", "Istanbul");
        // gelen Token'�n Claims'lerinde city adl� claims'in de�eri istanbulsa okey do�rula
        // �imdi bu IstanbulPolicy adl� policy'i  istedi�imiz Controller'a yada metot'a verebiliriz
    });
});





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
