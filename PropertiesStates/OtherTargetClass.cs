using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesStates
{
    internal class OtherTargetClass
    {
        public string Username { get; set; } = "John Doe";

        [PasswordPropertyText]
        public string Password { get; set; } = "password123";
    }
}
