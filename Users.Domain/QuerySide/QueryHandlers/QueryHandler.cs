using System;
using System.Collections.Generic;
using System.Text;
using Users.Domain.Core.Bus;

namespace Users.Domain.QuerySide.QueryHandlers
{
    public class QueryHandler<TRequest, TResponse>
    {
        private readonly IMediatorHandler mediatorHandler;

        public QueryHandler(IMediatorHandler mediatorHandler)
        {
            this.mediatorHandler = mediatorHandler;
        }
    }
}
