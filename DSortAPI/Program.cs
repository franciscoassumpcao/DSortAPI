global using DSortAPI.Data;
global using Microsoft.EntityFrameworkCore;
global using Azure.Storage.Blobs;
using DSortAPI.Controllers;
using DSortAPI.Services;
using Microsoft.Extensions.Azure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



var configAzure = builder.Configuration.GetSection("Storage:ConnectionString").Value;
builder.Services.AddAzureClients(builder =>
{
	builder.AddBlobServiceClient(configAzure);
});

builder.Services.AddTransient<IStorageService, StorageServices>();
builder.Services.AddControllers();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<DataContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddHttpClient<DocumentController>(client =>
{
	client.BaseAddress = new Uri("https://localhost:7135");
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
	{
	app.UseSwagger();
	app.UseSwaggerUI();	
	}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
    {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    }

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.Run();
