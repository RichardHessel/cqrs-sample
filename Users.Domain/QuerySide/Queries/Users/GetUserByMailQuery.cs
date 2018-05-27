using System;
using System.Collections.Generic;
using System.Text;
using Users.Domain.Core.Queries;
using Users.Domain.Entities;

namespace Users.Domain.QuerySide.Queries.Users
{
    public class GetUserByMailQuery : Query<User>
    {
        public GetUserByMailQuery(string email)
        {
            this.Email = email;
        }
        public string Email { get; private set; }
    }
}
