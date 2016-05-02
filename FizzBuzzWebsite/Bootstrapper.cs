using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using FizzBuzzBL;
using FizzBuzzDomainModel;

namespace FizzBuzzWebsite
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      container.RegisterType<IFizzBuzzManager, FizzBuzzManager>();
      container.RegisterType<ICreateList, AbstractPattern>();
      container.RegisterType<ICreateList, CreateList>("CreateList");
      container.RegisterType<AbstractPattern, FizzPattern>("FizzPattern");
      container.RegisterType<AbstractPattern, BuzzPattern>("BuzzPattern");
      container.RegisterType<AbstractPattern, FizzBuzzPattern>("FizzBuzzPattern");


      container.RegisterType<IFizzBuzzManager, FizzBuzzManager>(
          new InjectionConstructor(new ResolvedParameter<ICreateList>("CreateList"),
                                   new ResolvedParameter<AbstractPattern>("FizzPattern"),
                                   new ResolvedParameter<AbstractPattern>("BuzzPattern"),
                                   new ResolvedParameter<AbstractPattern>("FizzBuzzPattern")));

      return container;
    }
  }
}