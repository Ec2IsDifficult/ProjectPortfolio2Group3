namespace WebServiceToken.Services
{
    using System;
    using WebServiceAPI.Models;

    public interface IUriService
    {
        Uri GetAllPostUri(PaginationQuery pagination = null);
    }
}