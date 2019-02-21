using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
namespace Artech.WcfServices.Service
{
    public class SimpleUserNamePasswordValidator : UserNamePasswordValidator
    {
        public IDictionary<string, string> UserNamePasswords { get; private set; }
        public SimpleUserNamePasswordValidator()
        {
            this.UserNamePasswords = new Dictionary<string, string>();
            this.UserNamePasswords.Add("foo", "Password");
            this.UserNamePasswords.Add("bar", "Password");
            this.UserNamePasswords.Add("baz", "Password");
        }

        public override void Validate(string userName, string password)
        {
            Console.WriteLine("开始认证客户端...");
            bool authenticated = true;
            if(!this.UserNamePasswords.ContainsKey(userName.ToLower()))
            {
                authenticated = false;
            }
            if (authenticated)
            {
                if (this.UserNamePasswords[userName.ToLower()] != password)
                {
                    authenticated = false;
                }
            }

            if (!authenticated)
            {
                throw new SecurityTokenValidationException("用户名不存在，或者用户名与密码不符"); 
            }
        }
    }
}