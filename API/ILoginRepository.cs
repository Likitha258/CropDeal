using CropAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CropAPI.Repository
{
    internal interface ILoginRepository
    {
        UserProfile VerifyLogin(string Email, string password);
        
    }
}