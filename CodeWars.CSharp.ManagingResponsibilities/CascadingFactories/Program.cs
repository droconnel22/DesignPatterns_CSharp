using System;
using Microsoft.Practices.Unity;

namespace CodeWars.CSharp.ManagingResponsibilities.CascadingFactories
{
    class  Program
    {
        static IUnityContainer InitializeIocContainer()
        {
            return new UnityContainer()
                .RegisterType<Application, Application>()
                .RegisterType<IVacationPartFactory, VacationPartFactory>(
                    new ContainerControlledLifetimeManager())
                .RegisterType<IHotelSelector, HotelSelector>(
                 new ContainerControlledLifetimeManager())
                .RegisterType<IHotelService, HotelService>(
                 new ContainerControlledLifetimeManager())
                .RegisterType<IAirplaneService, AirplaneService>(
                 new ContainerControlledLifetimeManager());
        }


        static void Main(string[] args)
        {
        //    new Application(
        //        new VacationPartFactory(
        //            new HotelService(),
        //            new HotelSelector(),
        //            new AirplaneService()))
        //        .Run();

            InitializeIocContainer()
                .Resolve<Application>()
                .Run();
            Console.ReadLine();
        }
    }
}