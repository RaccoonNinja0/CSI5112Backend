using csi5112service.services;
using csi5112service.models;

var builder = WebApplication.CreateBuilder(args);

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                      });
});





// Add services to the container.

// builder.Services.AddControllers();
builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ShopDatabaseSettings>(
                builder.Configuration.GetSection(nameof(ShopDatabaseSettings)));

// Add our services for DI
// builder.Services.AddSingleton<ProductService>();
// builder.Services.AddSingleton<OrderService>();
// builder.Services.AddSingleton<OrderDetailsService>();
// builder.Services.AddSingleton<UserService>();
// builder.Services.AddSingleton<ChatboxService>();

var options = builder.Configuration.GetSection(nameof(ShopDatabaseSettings)).Get<ShopDatabaseSettings>();
builder.Services.AddSingleton<ShopDatabaseSettings>(options);

builder.Services.AddSingleton<ProductService>();
builder.Services.AddSingleton<OrderService>();
// builder.Services.AddSingleton<OrderDetailsService>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<ChatboxService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
// useCors must be after use routing and before use authorization
app.UseCors(MyAllowSpecificOrigins);

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
