using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WebIdentity.Models;

namespace WebIdentity.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
        [Required]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = "";
    }
    public class RegisterListViewModel
    {
        public List<AppliactionUser> Users { get; set; } = new List<AppliactionUser>();
    }
    public class RegisterEditViewModel
    {
        public string Id { get; set; } = "";
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";
    }
}

