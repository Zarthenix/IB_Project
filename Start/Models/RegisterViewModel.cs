using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Start.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(15)]
        [DataType(DataType.Text)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(20)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "An e-mailaddress is required.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        [StringLength(20)]
        [DataType(DataType.Text)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        [StringLength(40)]
        [DataType(DataType.Text)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your address.")]
        [StringLength(75)]
        [DataType(DataType.Text)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your Zipcode")]
        [StringLength(7)]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Zipcode")]
        public string Zipcode { get; set; }

        [Required(ErrorMessage = "Please enter your town of residence.")]
        [StringLength(85)]
        [DataType(DataType.Text)]
        [Display(Name = "Town")]
        public string Town { get; set; }


        //public Customer GetModel()
        //{
        //    Customer acc = new Customer
        //    {
        //        Username = this.Username,
        //        Password = this.Password,
        //        Email = this.Email,
        //        FirstName = this.FirstName,
        //        LastName = this.LastName,
        //        Address = this.Address,
        //        ZipCode = this.Zipcode,
        //        Town = this.Town,
        //        CreationDateTime = DateTime.Now
        //    };

        //    return acc;
        //}
    }
}
