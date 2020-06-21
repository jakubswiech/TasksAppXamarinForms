using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;
using Newtonsoft.Json;
using TasksAppXamarin.Configurations;
using TasksAppXamarin.Factories;
using TasksAppXamarin.Models;
using TasksAppXamarin.Pages;
using TasksAppXamarin.Repositories;
using TasksAppXamarin.Services;
using TasksAppXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace TasksAppXamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var assembly = typeof(SignInUserPage).Assembly;
            var builder = new ContainerBuilder();
            builder.Register(ctx => new CurrentUser()).As<ICurrentUser>().SingleInstance();
            builder.RegisterType<RestClientFactory>().As<IRestClientFactory>();
            builder.RegisterType<GenericRepository>().As<IGenericRepository>();
            builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(IView<>));
            builder.RegisterType<SignInUserViewModel>();
            builder.RegisterAssemblyTypes(assembly).Where(x => x.IsAssignableTo<IViewModel>())
                .AsSelf();
            builder.RegisterType<Navigator>().As<INavigator>().InstancePerLifetimeScope();
            builder.Register(ctx => App.Current.MainPage.Navigation).As<INavigation>().SingleInstance();
            builder.Register(ctx =>
                {
                    var appAssembly = Assembly.GetAssembly(typeof(App));
                    var resourceNames = appAssembly.GetManifestResourceNames();
                    var configName = resourceNames.FirstOrDefault(s => s.Contains("config.json"));
                    using (var stream = assembly.GetManifestResourceStream(configName))
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            var json = reader.ReadToEnd();
                            return JsonConvert.DeserializeObject<ApiConfiguration>(json);
                        }
                    }
                    
                })
                .As<IApiConfiguration>().SingleInstance();
            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IService>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            var container = builder.Build();
            DependencyResolver.ResolveUsing(type => container.IsRegistered(type) ? container.Resolve(type) : null);

            var mainPage = container.Resolve<IView<SignInUserViewModel>>();
            MainPage = new NavigationPage(mainPage as Page);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
