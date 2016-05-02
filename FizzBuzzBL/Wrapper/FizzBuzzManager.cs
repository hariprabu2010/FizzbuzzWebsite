using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzBL
{
    using FizzBuzzDomainModel;
    using Microsoft.Practices.Unity;

    public class FizzBuzzManager : IFizzBuzzManager
    {
        /// <summary>
        /// Main Logic that wraps all Patterns with Basic Create List
        /// DI has been used to here so dependency can be removed if a new layer is added in later stage.
        /// </summary>
        /// <param name="inputNumber"></param>
        /// <returns>List of ModelCollection</returns>
        /// 
        private ICreateList createList;
        private AbstractPattern fizzPattern;
        private AbstractPattern buzzPattern;
        private AbstractPattern fizzbuzzPattern;
        private AbstractPattern wizzwuzzPattern;

        public FizzBuzzManager([Dependency("CreateList")]ICreateList createList,
                                   [Dependency("FizzPattern")]AbstractPattern fizzPattern,
                                   [Dependency("BuzzPattern")]AbstractPattern buzzPattern,
                                   [Dependency("FizzBuzzPattern")]AbstractPattern fizzbuzzPattern,
                                   [Dependency("WizzWuzzPattern")]AbstractPattern wizzwuzzPattern)
        {
            this.createList = createList;
            this.fizzPattern = fizzPattern;
            this.buzzPattern = buzzPattern;
            this.fizzbuzzPattern = fizzbuzzPattern;
            this.wizzwuzzPattern = wizzwuzzPattern;
        }

        public FizzBuzzDomainModel Generate(int inputNumber)
        {
            //var displayList = new WizzWuzzPattern(new FizzBuzzPattern(new BuzzPattern(new FizzPattern(new CreateList()))));
            this.fizzPattern.SetComponent(this.createList);
            this.buzzPattern.SetComponent(this.fizzPattern);
            this.fizzbuzzPattern.SetComponent(this.buzzPattern);
            this.wizzwuzzPattern.SetComponent(this.fizzbuzzPattern);
            var returnList = this.wizzwuzzPattern.Generate(inputNumber);
            return returnList;
        }
    }
}
