using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Expenses.Web.Models
{
    public class UserIndexModel
    {
        public Contracts.UserLightDto[] Users { get; set; }
    }

    public class UserDetailsModel
    {
        public UserDetailsModel(BL.User user)
        {
            this.User = user;
        }

        public BL.User User { get; set; }
    }

    public class UserCreateAndEditModel
    {
        public UserCreateAndEditModel(bool createNew)
        {
            CreateNew = createNew;
        }
        public bool CreateNew { get; set; }
        public UserModel User { get; set; }
    }

    public class UserModel
    {
        public UserModel()
        {
            // new
        }

        public UserModel(BL.User user)
        {
            this.FullName = user.FullName;
        }

        public void ApplyToBO(BL.User user)
        {
            user.FullName = this.FullName;
        }

        [Required]
        public string FullName { get; set; }
    }
}