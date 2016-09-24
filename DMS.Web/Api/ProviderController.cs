﻿using AutoMapper;
using DMS.Model.Models;
using DMS.Service;
using DMS.Web.Infrastructure.Core;
using DMS.Web.Infrastructure.Extensions;
using DMS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace DMS.Web.Api
{
    [RoutePrefix("api/provider")]
    public class ProviderController : ApiControllerBase
    {
        #region Initialise
        private IProviderService _providerService;

        public ProviderController(IErrorService errorService, IProviderService providerService) :
            base(errorService)
        {
            this._providerService = providerService;
        }
        #endregion

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _providerService.GetById(id);

                var responseData = Mapper.Map<Provider, ProviderViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _providerService.GetAll(keyword);
                totalRow = model.Count();

                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);
                var responseData = Mapper.Map<IEnumerable<Provider>, IEnumerable<ProviderViewModel>>(query);

                var paginationSet = new PaginationSet<ProviderViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };

                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);

                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, ProviderViewModel providerVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newProvider = new Provider();
                    newProvider.UpdateProvider(providerVm);
                    newProvider.CreatedDate = DateTime.Now;
                    _providerService.Add(newProvider);
                    _providerService.Save();

                    var responseData = Mapper.Map<Provider, ProviderViewModel>(newProvider);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, ProviderViewModel providerVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbProvider = _providerService.GetById(providerVm.ID);
                    dbProvider.UpdateProvider(providerVm);
                    _providerService.Update(dbProvider);
                    _providerService.Save();

                    var responseData = Mapper.Map<Provider, ProviderViewModel>(dbProvider);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldProvider=_providerService.Delete(id);
                    _providerService.Save();

                    var responseData = Mapper.Map<Provider, ProviderViewModel>(oldProvider);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("deletemulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkProviders)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listProvider = new JavaScriptSerializer().Deserialize<List<int>>(checkProviders);
                    foreach (var item in listProvider)
                    {
                        _providerService.Delete(item);
                    }
                    _providerService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listProvider.Count);
                }
                return response;
            });
        }
    }
}