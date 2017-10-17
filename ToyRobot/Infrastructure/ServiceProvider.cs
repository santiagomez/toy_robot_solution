using System;
using StructureMap;
using ToyRobot.UI;
using ToyRobot.Utils;

namespace ToyRobot.Infrastructure
{
    // TODO: This should be internal. 
    public class ServiceProvider
    {
        private static ServiceProvider _instance;
        private static readonly object TheLock = new object();

        private readonly Container _container = new Container();

        public static ServiceProvider Instance
        {
            get
            {
                lock (TheLock) // thread safety
                {
                    if (_instance == null)
                    {
                        _instance = new ServiceProvider();
                        _instance.Init();
                    }
                }

                return _instance;
            }
        }

        public void Init()
        {
            // add StructureMap

            _container.Configure(config =>
            {
                // Register stuff in container, using the StructureMap APIs...
                config.Scan(_ =>
                {
                    _.AssemblyContainingType(typeof(Program));
                    _.WithDefaultConventions();
                });
                config.For<ILogger>().Add(new ConsoleLogger());
                config.For<IUserInterface>().Add(new ConsoleUserInterface());
            });
        }

        public object GetService(Type serviceType)
        {
            return _container.GetInstance(serviceType);
        }

        public T GetService<T>() where T : class
        {
            return _container.GetInstance<T>();
        }

        public void Bind<T>(T implementation) where T : class
        {
            _container.Configure(conf => conf.For<T>().Add(implementation));
        }
    }
}