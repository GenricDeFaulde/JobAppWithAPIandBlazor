using JobAPI.App_Start;
using JobAPI.Areas.Identity.Data;
using JobAPI.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace JobAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        ///

        /// Configures authentication for the web app.  This is abstracted out
        /// so that we can override the authentication middleware for an
        /// integration test, and thus, don't have a dependency on the
        /// identity server for the test.
        ///

        protected virtual void ConfigureAuth(IServiceCollection services)
        {
            // Setting up Identity
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<JobAppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                 .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Adding Factory for additional User Claims
            services.AddScoped<IUserClaimsPrincipalFactory<JobAppUser>, AdditionalUserClaimsPrincipalFactory>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                  "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            // Cookie settings
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(2880);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });


            // Tim Corey auth
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            })
                .AddJwtBearer("JwtBearer", jwtBearerOptions =>
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        //TODO Set actual secret. ONLY FOR TESTING
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MySecretKeyIsSecretSoDoNotTell")),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(5)
                    };
                });

        }

        ///

        /// Configures app insights for the web app.  Under test, we probably
        /// don't want real telemtery, so provide the option to turn it off.
        ///

        protected virtual void ConfigureAppInsights(IServiceCollection services)
        {
        }

        ///

        /// Configures dependencies for the web app.  Under test, we likely
        /// want to use mocks, so this provides a convenient way to register
        /// different implementations.  Additionally or alternatively, calling
        /// services.addSingleton multiple times, when resolved, returns the
        /// last registered instance.
        ///

        protected virtual void ConfigureDependencies(IServiceCollection services)
        {
            services.AddCors(policy => 
            {
                policy.AddPolicy("OpenCorsPolicy", options =>
                    options.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod());
            });


            services.AddDbContext<JobDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));


            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddRazorPages();
            //services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<AuthorizationOperationFilter>();
                //c.DocumentFilter<AuthTokenOperation>();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JobApp API", Version = "v1" });
                
               
            });
        }

        ///

        /// Set up dependency injection, configuration bindings, etc.
        ///

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (bool.Parse(Configuration["AUTHENTICATION_ENABLED"] ?? "true"))
            {
                this.ConfigureAuth(services);
            }
            else
            {
            
            } 
            this.ConfigureAppInsights(services);
            this.ConfigureDependencies(services);

            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("OpenCorsPolicy");

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(x =>
                {
                    x.SwaggerEndpoint("/swagger/v1/swagger.json", "JobApp API v1");
                });
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapRazorPages();
            });
        }
    }
}

