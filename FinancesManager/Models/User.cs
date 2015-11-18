using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace FinancesManager.Models
{
    public class User
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        

        /// <summary>
        /// Checks if user with given password exists in the database
        /// </summary>
        /// <param name="username">User name</param>
        /// <param name="password">User password</param>
        /// <returns>True if user exist and password is correct</returns>
        public bool IsValid(string username, string password)
        {
            return System.String.Compare(ConfigurationManager.AppSettings["Username"], username,
                                         System.StringComparison.OrdinalIgnoreCase) == 0 &&
                   System.String.Compare(ConfigurationManager.AppSettings["Password"], password,
                                         System.StringComparison.OrdinalIgnoreCase) == 0;
        }


    }
}