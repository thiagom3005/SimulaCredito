﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace SimulaCredito.Hypermedia.Abstract
{
    public interface IResponseEnricher
    {
        bool CanEnrich(ResultExecutingContext context);
        Task Enrich(ResultExecutingContext context);

    }
}
