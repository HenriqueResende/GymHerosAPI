using GymHerosAPI.BusinessLayer;
using GymHerosAPI.DataLayer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

#region Login
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Gym Heros API", Version = "v1" });

    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Por favor, insira um token válido",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var key = Encoding.ASCII.GetBytes(builder?.Configuration?.GetValue<string>("SecretKey") ?? "");

builder?.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})

.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
#endregion

#region CorsPolicy
builder?.Services.AddCors(option =>
{
    option.AddPolicy("CorsPolicy", builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});
#endregion

#region AddScoped
builder?.Services.AddScoped<IBLCriptografia, BLCriptografia>();
builder?.Services.AddScoped<IBLLogin, BLLogin>();
builder?.Services.AddScoped<IBLWorkout, BLWorkout>();
builder?.Services.AddScoped<IBLExerciseTemplate, BLExerciseTemplate>();
builder?.Services.AddScoped<IBLExercise, BLExercise>();
builder?.Services.AddScoped<IBLSeries, BLSeries>();
builder?.Services.AddScoped<IBLWorkoutHistory, BLWorkoutHistory>();
builder?.Services.AddScoped<IBLExerciseHistory, BLExerciseHistory>();
builder?.Services.AddScoped<IBLSeriesHistory, BLSeriesHistory>();
builder?.Services.AddScoped<IBLUser, BLUser>();
builder?.Services.AddScoped<IBLMission, BLMission>();
builder?.Services.AddScoped<IBLImage, BLImage>();

builder?.Services.AddScoped<IDLUser, DLUser>();
builder?.Services.AddScoped<ICRUD, CRUD>();
#endregion

#region Map
builder?.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

var app = builder?.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
