namespace FizzBuzzBL
{
    using FizzBuzzDomainModel;
    public class CreateList : ICreateList
    {
        public FizzBuzzDomainModel Generate(int inputNumber)
        {
            var fizzBuzzDomainModelCollection = new FizzBuzzDomainModel();
            for (int i = 1; i <= inputNumber; i++)
            {
                fizzBuzzDomainModelCollection.DisplayList.Add(new FizzBuzzDomainData { ItemValue = i.ToString(), DisplayText = i.ToString() });
            }

            return fizzBuzzDomainModelCollection;
        }
    }
}
