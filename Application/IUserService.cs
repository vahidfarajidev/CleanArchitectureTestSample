﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IUserService
    {
        void AddUser(AddUserDto dto);
        void EditUser(EditUserDto dto);
    }
}
