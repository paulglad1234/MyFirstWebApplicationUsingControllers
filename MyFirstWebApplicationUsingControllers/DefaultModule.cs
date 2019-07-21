using Autofac;

namespace MyFirstWebApplicationUsingControllers
{
    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Services.DbWorker>().As<Services.IDataWorker>();
        }
    }
}