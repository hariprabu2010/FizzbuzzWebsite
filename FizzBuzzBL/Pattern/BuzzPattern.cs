namespace FizzBuzzBL
{
    using FizzBuzzDomainModel;
    using System;

    public class BuzzPattern : AbstractPattern
    {
        /// <summary>
        /// Override method for abstract method in Abstract Decorator
        /// </summary>
        /// <param name="InputNumber"></param>
        /// <returns>DomainModelCollection</returns>
        public override FizzBuzzDomainModel Generate(int InputNumber)
        {
            var fizzBuzzListBuzz = ICreateList.Generate(InputNumber);

            foreach (var item in fizzBuzzListBuzz.DisplayList)
            {

                if (Convert.ToInt32(item.ItemValue) % 5 == 0)
                {

                    item.DisplayText = "Buzz";
                }

            }
            return fizzBuzzListBuzz;
        }
    }
}
