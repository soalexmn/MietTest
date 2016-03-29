using DbLayer.Interfaces;
using DbLayer.Repositories;
using MietTest.TestCache;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MietTest.Infrastructure
{
    public class NinjectDependencyResolver : System.Web.Mvc.IDependencyResolver
    {

        //Ядро Ninject, объект, ответственныйза распознавание зависимостей и создание новых объектов
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            //Здесь размещаются привязки
            kernel.Bind<ITestRepository>().To<EfTestRepository>();
            kernel.Bind<ITestCache>().To<TestMemoryCache>().InSingletonScope();

            kernel.Bind(typeof(IGenericRepository<>)).To(typeof(EfGenericRepository<>));

        }
    }
}