﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;


namespace Dal
{
    public interface IDal
    {
        bool DBUserSaveCredentials(string login, string password, string firstName, string lastName, string email, string sex, string phone, string isDeleted, string isBanned);
        bool IsPersonEmailInDb(string loginOrEmail);
        bool IsPersonInDb(string loginOrEmail, string password);
    }
}
