using SignalRServerExample.Business;
using SignalRServerExample.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddCors(options=> options.AddDefaultPolicy(policy => 
                                policy.AllowAnyHeader()
                                    .AllowAnyHeader()
                                    .AllowCredentials()
                                    .SetIsOriginAllowed(origin => true)));
builder.Services.AddSignalR();
builder.Services.AddScoped<MyBusiness>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
    
}

app.UseCors();

app.UseRouting();
app.UseHttpsRedirection();
app.MapControllers();


app.MapHub<MyHub>("/myhub");

app.Run();
