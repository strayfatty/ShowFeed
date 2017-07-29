using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using ShowFeed.Infrastructure;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;

namespace ShowFeed
{
	public class Startup
	{
		private Container container = new Container();

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();

			this.IntegrateSimpleInjector(services);
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			this.InitializeContainer(app);

			app.UseDefaultFiles();
			app.UseStaticFiles();
			app.UseMvc();
		}

		private void IntegrateSimpleInjector(IServiceCollection services)
		{
			this.container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddSingleton<IControllerActivator>(
				new SimpleInjectorControllerActivator(this.container));

			services.UseSimpleInjectorAspNetRequestScoping(this.container);
		}

		private void InitializeContainer(IApplicationBuilder app)
		{
			container.RegisterMvcControllers(app);

			var assemblies = new[] { typeof(Startup).Assembly };
			container.Register(typeof(IRequestHandler<>), assemblies);
			container.Register(typeof(IRequestHandler<,>), assemblies);
			container.Register(typeof(IPagedRequestHandler<,>), assemblies);
		}
	}
}
