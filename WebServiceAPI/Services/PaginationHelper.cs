namespace WebServiceToken.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Dataservices.Domain;
    using Dataservices.Domain.FunctionObjects;
    using WebServiceAPI.Models;

    public class PaginationHelper
    {
        public static PagedResponse<T> CreatePagenatedResponse<T>(UriService _uriService, PaginationFilter paginationFilter, IEnumerable<T> all, int totalResultLength)
        {
            var nextPage = paginationFilter.PageNumber >= 1 && paginationFilter.PageNumber <= totalResultLength/paginationFilter.PageSize
                ? _uriService.GetAllPostUri(new PaginationQuery(paginationFilter.PageNumber + 1, paginationFilter.PageSize)).ToString() : null;
            
            var previousPage = paginationFilter.PageNumber - 1 >= 1
                ? _uriService.GetAllPostUri(new PaginationQuery(paginationFilter.PageNumber - 1, paginationFilter.PageSize)).ToString() : null;

            var paginationResponse = new PagedResponse<T>
            {
                Data = all,
                PageNumber = paginationFilter.PageNumber >= 1 ? paginationFilter.PageNumber : (int?) null,
                PageSize = paginationFilter.PageSize >= 1 ? paginationFilter.PageSize : (int?) null,
                NextPage = all.Any() ? nextPage : null,
                PreviousPage = previousPage
            };
            return paginationResponse;
        }
    }
}