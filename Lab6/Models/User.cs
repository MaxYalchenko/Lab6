using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab6.Models
{
    [Table("AspNetUsers")]
    public class User : IdentityUser
    {
        
    }
}
