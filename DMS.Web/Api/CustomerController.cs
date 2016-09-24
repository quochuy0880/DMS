using AutoMapper;
using DMS.Model.Models;
using DMS.Service;
using DMS.Web.Infrastructure.Core;
using DMS.Web.Infrastructure.Extensions;
using DMS.Web.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DMS.Web.Api
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiControllerBase
    {
        private ICustomerService _customerService;

        public CustomerController(IErrorService errorService, ICustomerService customerService) :
            base(errorService)
        {
            this._customerService = customerService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listCustomer = _customerService.GetAll();
                var listCustomerVm = Mapper.Map<List<CustomerViewModel>>(listCustomer);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCustomerVm);

                return response;
            });
        }

        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, CustomerViewModel customerVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    Customer newCustomer = new Customer();
                    newCustomer.UpdateCustomer(customerVM);
                    var customer = _customerService.Add(newCustomer);
                    _customerService.Save();

                    response = request.CreateResponse(HttpStatusCode.Created, customer);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, CustomerViewModel customerVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var customerDb = _customerService.GetById(customerVM.ID);
                    customerDb.UpdateCustomer(customerVM);
                    _customerService.Update(customerDb);
                    _customerService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }

        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                else
                {
                    _customerService.Delete(id);
                    _customerService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
    }
}