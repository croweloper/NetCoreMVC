# NetCoreMVC
 
## Creacion de Proyecto

 ## Entity Famework Core
        dotnet add package Microsoft.EntityFrameworkCore.InMemory
        dotnet add package Microsoft.EntityFrameworkCore.Sqlite
        dotnet add package Microsoft.EntityFrameworkCore.SqlServer
        dotnet add package Pomelo.EntityFrameworkCore.MySql
        dotnet add package MySql.Data.EntityFrameworkCore

## Añadiendo Entity Framework en Startup Proyect
      // Version 3

      services.AddDbContext<EscuelaContext>(options => options.UseInMemoryDatabase("testDB"));
      
       
      //Version 6 

      builder.Services.AddDbContext<EscuelaContext>(options => options.UseInMemoryDatabase("testDB"));

      var app = builder.Build();

      // Realizar la importacion
      using NetCoreMVC.Models;
      using Microsoft.EntityFrameworkCore;

      