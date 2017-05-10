using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeworkApp.Models
{
    public class UserModel
    {
        [Key, Required]
        public string UserID { get; set; }
        [Required, DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required, DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required, DisplayName("Email")]
        public string EmailAddress { get; set; }
        public Nullable<System.DateTime> JoinedDate { get; set; }
    }

    public class UserListModel
    {
        public string UserID { get; set; }
        public string Name { get; set; }
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }
        [DisplayName("Joined")]
        public Nullable<System.DateTime> JoinedDate { get; set; }
    }
}