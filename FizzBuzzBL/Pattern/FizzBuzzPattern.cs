using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzBL
{
    using FizzBuzzDomainModel;
    using System;

    public class FizzBuzzPattern : AbstractPattern
    {
        /// <summary>
        /// Override method for abstract method in Abstract Decorator
        /// </summary>
        /// <param name="InputNumber"></param>
        /// <returns>DomainModelCollection</returns>
        public override FizzBuzzDomainModel Generate(int InputNumber)
        {
            var fizzBuzzListFizzBuzz = ICreateList.Generate(InputNumber);

            foreach (var item in fizzBuzzListFizzBuzz.DisplayList)
            {
                if (Convert.ToInt32(item.ItemValue) % 3 == 0 && Convert.ToInt32(item.ItemValue) % 5 == 0)
                {
                    item.DisplayText = "FizzBuzz";
                }

            }
            return fizzBuzzListFizzBuzz;
        }
    }
}
