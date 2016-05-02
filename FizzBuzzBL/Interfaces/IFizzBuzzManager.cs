namespace FizzBuzzBL
{
    using FizzBuzzDomainModel;
    public interface IFizzBuzzManager
    {
        FizzBuzzDomainModel Generate(int inputNumber);
    }
}
