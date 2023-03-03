using DAL.Data;
using DAL.IServices;
using DAL.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;

namespace CSharp5
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            services.AddDbContext<DbContexts>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<INguoiDungService, NguoiDungService>();
            services.AddScoped<IDiaChiService, DiaChiService>();
            services.AddScoped<IHoaDonService, HoaDonService>();
            services.AddScoped<ISanPhamService, SanPhamService>();
            services.AddScoped<ISanPhamChiTietService, SanPhamChiTietService>();
            services.AddScoped<IGiamGiaHDService, GiamGiaHDService>();
            services.AddScoped<ITrangThaiService, TrangThaiService>();
            services.AddScoped<IQuanLiService, QuanLiService>();
            services.AddScoped<IPhanQuyenService, PhanQuyenService>();
            services.AddScoped<IGiamGiaSPService, GiamGiaSPService>();
            services.AddScoped<IGioHangService, GioHangService>();
            services.AddScoped<IHoaDonChiTietService, HoaDonChiTietService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
