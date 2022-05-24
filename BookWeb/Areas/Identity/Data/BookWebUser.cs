using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BookWeb.Areas.Identity.Data;

// Add profile data for application users by adding properties to the BookWebUser class
public class BookWebUser : IdentityUser
{
    [Required]
    [DisplayName("First Name")]
    public string? FirstName { get; set; }

    [Required]
    [DisplayName("Last Name")]
    public string? LastName { get; set; }

    [Required]
    [DisplayName("Date Of Birth")]
    public DateTime DateOfBirth { get; set; }

    [DisplayName("Date Joined")]
    public DateTime DateJoined { get; set; } = DateTime.Now;

    //public int Age
    //{
    //    get => Age;
    //    set
    //    {
    //        Age = AgeCalculate(DateOfBirth);
    //    }
    //}

    //private static int AgeCalculate(DateTime dateOfBirth)
    //{
    //    // Save today's date.
    //    var today = DateTime.Today;

    //    // Calculate the age.
    //    var age = today.Year - dateOfBirth.Year;

    //    // Go back to the year in which the person was born in case of a leap year
    //    if (dateOfBirth.Date > today.AddYears(-age)) age--;

    //    return age;
    //}
}