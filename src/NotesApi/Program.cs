global using FastEndpoints;
using Google.Cloud.Firestore;
using NotesApi.Repository;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";

var url = $"http://0.0.0.0:{port}";

builder.Services.AddFastEndpoints();

builder.Services.AddSingleton<FirestoreDb>(FirestoreDb.Create("backup-photos-1234"));

builder.Services.AddScoped<INotesRepository, NotesRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseFastEndpoints();

app.Run(url);
