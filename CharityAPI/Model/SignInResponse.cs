using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharityAPI.Model
{
    public class SignInResponse
    {
        public int Id { get; set; }           
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
