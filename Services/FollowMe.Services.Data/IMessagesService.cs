﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FollowMe.Services.Data
{
    public interface IMessagesService
    {
        IEnumerable<T> GetAll<T>();
    }
}