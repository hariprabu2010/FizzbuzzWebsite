using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FizzBuzzWebsite.Models
{
    using AutoMapper;
    using FizzBuzzDomainModel;
    public class MapperClass
    {
        /// <summary>
        /// Method to create and map the domain model with View model
        /// </summary>
        /// <param name="domainModel"></param>
        /// <returns>View Model</returns>
        public FizzBuzzViewModel Map(FizzBuzzDomainModel domainModel)
        {
            var fizzBuzzViewModelCollection = new FizzBuzzViewModel();

            Mapper.CreateMap<FizzBuzzDomainData, FizzBuzzData>()
                .ForMember(x => x.DisplayText, map => map.MapFrom(y => y.DisplayText))
                .ForMember(x => x.ItemValue, map => map.MapFrom(y => y.ItemValue));

            foreach (FizzBuzzDomainData item in domainModel.DisplayList)
            {
                var fizzBuzzViewModel =
                    Mapper.Map<FizzBuzzDomainData, FizzBuzzData>(item);

                fizzBuzzViewModelCollection.DisplayList.Add(fizzBuzzViewModel);
            }

            return fizzBuzzViewModelCollection;
        }
    }
}