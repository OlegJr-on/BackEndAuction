using System.ComponentModel.DataAnnotations;

namespace Web_API.Models
{
    public class UserRegistrationModel
    {
        public int Id { get; set; }

        [Display(Name="Name")]
        [Required(ErrorMessage ="Please enter your name")]
        [StringLength(maximumLength: 25, MinimumLength = 3, ErrorMessage = "Name is too short")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Please enter your surname")]
        [StringLength(25)]
        [MinLength(2)]
        public string Surname { get; set; }

        [Display(Name = "Location")]
        [Required(ErrorMessage = "Please enter your location")]
        [StringLength(25)] 
        [MinLength(3)]
        public string Location { get; set; }

        [Display(Name = "Number of phone")]
        [Required(ErrorMessage = "Please enter your phone number")]
        [RegularExpression("[0-9]{3}-[0-9]{3}-[0-9]{4}", ErrorMessage = "Format: 999-999-9999")]
        [StringLength(12)]
        [MinLength(12)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter your mail-adress")]
        [UIHint("EmailAdress")]
        [EmailAddress]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [UIHint("Password")]
        [Required(ErrorMessage = "Please enter your password")]
        [Compare("ConfirmPassword",ErrorMessage ="The entered password does not match")]
        [StringLength(maximumLength: 20,MinimumLength = 6,ErrorMessage ="Your password does not fall within the range of 6 to 20 symbols")]
        public string Password { get; set; }


        [Display(Name = "Confirm Password")]
        [UIHint("Password")]
        [Required(ErrorMessage = "Please enter your password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Do you agree with the terms of the agreement?")]
        [Required(ErrorMessage ="Tap on checkbox")]
        public bool IsAgree { get; set; }

    }

}
