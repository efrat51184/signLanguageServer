using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class User
    {
        public int UserId { get; set; }
        [Required]
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        [Required]
        public string UserPassword { get; set; }
        [EmailAddress]
        [Required]
        public string UserEmail { get; set; }
        public int? LastMark { get; set; }
        public int? HighestMark { get; set; }
        [NotMapped]
        public string Token { get; set; }
        [JsonIgnore]
        public string UserSalt { get; set; }
    }
}
