using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; 
using ProductCms.Attribute;
using ProductCms.Base.Helper;
using ProductCms.Base.Interface;
using ProductCms.Data.Entity;
using ProductCms.Data.Entity.ApiModels;
using ProductCms.Service.Services;

namespace ProductCms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthenticationAttribute]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        [Route("Search")]
        [ActionLogAttribute]
        public ActionResult Search([FromBody] SearchRequest request)
        {
            try
            {
                ISearchService<ProductSearchModel> searchService = new ProductSearchService();

                var results =  searchService.Search(request.QueryText,request.MinQuantity,request.MaxQuantity);

                var response = new SearchResponse
                {
                    productList = results
                };

                return new JsonResult(response) { StatusCode = StatusCodes.Status200OK };
            }
            catch (Exception ex)
            {
                string errorMessage = string.Format("Error occoured while searching product : {0}", ex.Message);
                LogHelper.Exception(ex, errorMessage);

                return new JsonResult(errorMessage) { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }
    }
}