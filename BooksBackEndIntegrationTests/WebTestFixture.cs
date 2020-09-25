using BooksBackend;
using BooksBackend.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BooksBackEndIntegrationTests
{
    public class WebTestFixture : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Find the sercie that is *currenty;* implementing ISystemTime and remove it.
                var systemTimeDescript = services.SingleOrDefault(
                    d => d.ServiceType == typeof(ISystemTime)
                    );
                // secretly replace it with fake version
                services.Remove(systemTimeDescript);
                services.AddTransient<ISystemTime, FakeSystemTime>();
            });
        }
    }

    public class FakeSystemTime : ISystemTime
    {
        public DateTime GetCurrent()
        {
            return new DateTime(1990, 02, 14, 12, 00, 00);
        }
    }
}
