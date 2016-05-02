
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

        public FizzBuzzManager([Dependency("CreateList")]ICreateList createList,
                                   [Dependency("FizzPattern")]AbstractPattern fizzPattern,
                                   [Dependency("BuzzPattern")]AbstractPattern buzzPattern,
                                   [Dependency("FizzBuzzPattern")]AbstractPattern fizzbuzzPattern)
        {
            this.createList = createList;
            this.fizzPattern = fizzPattern;
            this.buzzPattern = buzzPattern;
            this.fizzbuzzPattern = fizzbuzzPattern;
        }

        public FizzBuzzDomainModel Generate(int inputNumber)
        {
            this.fizzPattern.SetComponent(this.createList);
            this.buzzPattern.SetComponent(this.fizzPattern);
            this.fizzbuzzPattern.SetComponent(this.buzzPattern);
            var returnList = this.fizzbuzzPattern.Generate(inputNumber);
            return returnList;
        }
    }
}
