﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proTaxi.Persistence.Exceptions
{
    public class UserGroupRequestsDataException : Exception
    {
        public UserGroupRequestsDataException(string message) : base(message) { }
    }

}

