using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GroupTask_Pizza.Utilies.Validation
{
    internal static class regex
    {
        public static bool MailValidation(string mail)
        {
            Regex regex = new Regex(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$");
            Match match = regex.Match(mail);
            return match.Success;

        }
        public static bool PasswordValidation(string password)
        {
            Regex regex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{6,16}$");
            Match match = regex.Match(password);
            return match.Success;

        }
    }
}
