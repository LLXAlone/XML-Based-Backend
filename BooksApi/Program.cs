using Microsoft.AspNetCore.Mvc;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Use CORS middleware
app.UseCors();

app.MapGet("/api/books", () =>
{
    var xmlData = @"<books>
        <book>
            <id>1</id>
            <title>Deep Learning Fundamentals</title>
            <author>Bernard Vic Caay</author>
            <price>29.99</price>
        </book>
        <book>
            <id>2</id>
            <title>Software Engineering 101</title>
            <author>Chloe Angelic Rodriguez</author>
            <price>1500</price>
        </book>
    </books>";
    return Results.Text(xmlData, "application/xml", Encoding.UTF8);
});

app.Run();
