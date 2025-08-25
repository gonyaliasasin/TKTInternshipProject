var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});
builder.Services.AddControllers(option => { }).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthorization();

var app = builder.Build();
var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
context.Database.Migrate();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
