var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.lovedmemory_web>("lovedmemory-web");

builder.Build().Run();
