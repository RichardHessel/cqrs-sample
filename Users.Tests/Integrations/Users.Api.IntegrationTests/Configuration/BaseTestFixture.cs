using System;
using System.Net.Http;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Users.Api.Mapping;
using Users.Infra.Persistence.Context;

namespace Users.Api.IntegrationTests.Configuration
{
    public class BaseTestFixture : IDisposable
    {
        public readonly TestServer _server;

        public readonly HttpClient _client;

        public readonly DbContext _dbContext;

        public BaseTestFixture()
        {
            IWebHostBuilder builder = new WebHostBuilder().UseStartup<Startup>();
            builder.ConfigureServices(services =>
            {
                services.AddDbContext<DataContext>(
                  opt => opt.UseSqlite("Data Source=cqrsSample1"));
                services.AddScoped<DbContext, DataContext>();
            });

            _server = new TestServer(builder);
            _client = _server.CreateClient();
            _dbContext = new DataContext(new DbContextOptionsBuilder<DataContext>()
                .UseSqlite("Data Source=cqrsSample1").Options);
            SetupDatabase();
        }

        public void SetupDatabase()
        {
            try
            {
                _dbContext.Database.EnsureDeleted();
                _dbContext.Database.EnsureCreated();
                _dbContext.Database.Migrate();

            }
            catch (Exception)
            {
            }

        }

        public void Dispose()
        {
            _client.Dispose();
            _server.Dispose();
            _dbContext.Dispose();
        }
    }
}
