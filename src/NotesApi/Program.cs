global using FastEndpoints;
global using FluentValidation;
using Google.Cloud.Firestore;
using NotesApi.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.AddSingleton<FirestoreDb>(FirestoreDb.Create("backup-photos-1234"));
builder.Services.AddScoped<INotesRepository, NotesRepository>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseFastEndpoints();
app.Run();
