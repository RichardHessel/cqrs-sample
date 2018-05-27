using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Users.Domain.Core.Events;

namespace Users.Domain.Core.Queries
{
    public class Query<TResponse> : Message, IRequest<TResponse>
    {
    }
}
