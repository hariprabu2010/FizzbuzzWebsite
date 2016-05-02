namespace FizzBuzzBL
{
    using FizzBuzzDomainModel;
    using System;

    public class FizzPattern : AbstractPattern
    {
        /// <summary>
        /// Override method for abstract method in Abstract Decorator
        /// </summary>
        /// <param name="InputNumber"></param>
        /// <returns>DomainModelCollection</returns>
        public override FizzBuzzDomainModel Generate(int InputNumber)
        {
            var fizzBuzzListFizz = ICreateList.Generate(InputNumber);

            foreach (var item in fizzBuzzListFizz.DisplayList)
            {

                if (Convert.ToInt32(item.ItemValue) % 3 == 0)
                {

                    item.DisplayText = "Fizz";
                }

            }
            return fizzBuzzListFizz;
        }
    }
}
