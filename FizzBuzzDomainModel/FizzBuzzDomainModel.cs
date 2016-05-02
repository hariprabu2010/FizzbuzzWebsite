namespace FizzBuzzDomainModel
{
    using System.Collections.Generic;
    public class FizzBuzzDomainModel
    {
         /// <summary>
        /// Constructor for domain model collection class
        /// </summary>
        public FizzBuzzDomainModel()
        {
            this.DisplayList = new List<FizzBuzzDomainData>();
        }
        /// <summary>
        /// List using the Domain model properties
        /// </summary>
        public List<FizzBuzzDomainData> DisplayList { get; set; }

    }
}
