var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(o => o.AddPolicy("Pwa", p => p.WithOrigins("https://techsofterp.github.io").AllowAnyHeader().AllowAnyMethod()));
var app = builder.Build();
app.UseHttpsRedirection();
app.UseCors("Pwa");
app.MapGet("/api/health", () => Results.Ok(new { ok = true, app = "TechsoftAI API", version = "3.0" }));
app.MapGet("/api/whatsapp/webhook", (HttpRequest req, IConfiguration cfg) => {
    var mode=req.Query["hub.mode"].ToString(); var token=req.Query["hub.verify_token"].ToString(); var challenge=req.Query["hub.challenge"].ToString();
    return mode=="subscribe" && token==cfg["WhatsApp:VerifyToken"] ? Results.Text(challenge) : Results.Unauthorized();
});
app.MapPost("/api/whatsapp/webhook", async (HttpRequest req) => {
    using var sr=new StreamReader(req.Body); var body=await sr.ReadToEndAsync();
    Console.WriteLine(body); return Results.Ok();
});
app.Run();