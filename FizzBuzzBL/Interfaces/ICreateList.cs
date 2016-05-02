namespace FizzBuzzBL
{
    using FizzBuzzDomainModel;
    public interface ICreateList
    {
        FizzBuzzDomainModel Generate(int inputNum);
    }
}
