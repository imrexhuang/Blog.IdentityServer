using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// https://stackoverflow.com/questions/42787120/how-to-use-identityserver4-with-custom-password-validation-with-asp-net-microsof
//密碼不能全部使用一樣的字元

namespace Blog.IdentityServer.Validator
{
    public class SameCharacterPasswordValidator<TUser> : IPasswordValidator<TUser>
           where TUser : class
    {
        public Task<IdentityResult> ValidateAsync(UserManager<TUser> manager,
                                                  TUser user,
                                                  string password)
        {
            return Task.FromResult(password.Distinct().Count() == 1 ?
                IdentityResult.Failed(new IdentityError
                {
                    Code = "SameChar",
                    Description = "Passwords cannot be all the same character."
                }) :
                IdentityResult.Success);
        }
    }

}
