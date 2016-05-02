namespace FizzBuzzBL
{
    using FizzBuzzDomainModel;
    /// <summary>
    /// Abstract class which implements the ICreateList. This will be used by all Patterns
    /// </summary>
    public abstract class AbstractPattern : ICreateList
    {
        protected ICreateList ICreateList;

        public void SetComponent(ICreateList createList)
        {
            this.ICreateList = createList;
        }

        public abstract FizzBuzzDomainModel Generate(int InputNumber);
    }
}
