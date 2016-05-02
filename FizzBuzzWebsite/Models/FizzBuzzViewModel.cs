using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FizzBuzzWebsite.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// View Model collection with the Actual List, Paged List and Pagination details
    /// </summary>
    public class FizzBuzzViewModel
    {
        public FizzBuzzViewModel()
        {
            this.DisplayList = new List<FizzBuzzData>();

        }
        [Required]
        [Range(1, 1000, ErrorMessage = "Please enter value between 1 and 1000.")]
        public int InputNumber { get; set; }
        public List<FizzBuzzWebsite.Models.FizzBuzzData> DisplayList { get; set; }
        //To store FizzBuzz item after applying pagination
        public List<FizzBuzzWebsite.Models.FizzBuzzData> FizzBuzzPagedList { get; set; }
        //Pagination properties
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int CurrentPageIndex { get; set; }
    }
}