using AutoMapper;
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
    [RoutePrefix("api/unitproduct")]
    public class UnitProductController : ApiControllerBase
    {
        #region Initialise

        private IUnitProductService _unitProductService;

        public UnitProductController(IErrorService errorService, IUnitProductService unitProductService) :
            base(errorService)
        {
            this._unitProductService = unitProductService;
        }

        #endregion Initialise

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _unitProductService.GetById(id);

                var responseData = Mapper.Map<UnitProduct, UnitProductViewModel>(model);
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
                var model = _unitProductService.GetAll(keyword);
                totalRow = model.Count();

                var query = model.OrderByDescending(x => x.ID).Skip(page * pageSize).Take(pageSize);
                var responseData = Mapper.Map<IEnumerable<UnitProduct>, IEnumerable<UnitProductViewModel>>(query);

                var paginationSet = new PaginationSet<UnitProductViewModel>()
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
        public HttpResponseMessage Create(HttpRequestMessage request, UnitProductViewModel unitProductVm)
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
                    var newUnitProduct = new UnitProduct();
                    newUnitProduct.UpdateUnitProduct(unitProductVm);
                    _unitProductService.Add(newUnitProduct);
                    _unitProductService.Save();

                    var responseData = Mapper.Map<UnitProduct, UnitProductViewModel>(newUnitProduct);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, UnitProductViewModel unitProductVm)
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
                    var dbUnitProduct = _unitProductService.GetById(unitProductVm.ID);
                    dbUnitProduct.UpdateUnitProduct(unitProductVm);
                    _unitProductService.Update(dbUnitProduct);
                    _unitProductService.Save();

                    var responseData = Mapper.Map<UnitProduct, UnitProductViewModel>(dbUnitProduct);
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
                    var oldUnitProduct = _unitProductService.Delete(id);
                    _unitProductService.Save();

                    var responseData = Mapper.Map<UnitProduct, UnitProductViewModel>(oldUnitProduct);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("deletemulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkUnitProducts)
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
                    var listUnitProduct = new JavaScriptSerializer().Deserialize<List<int>>(checkUnitProducts);
                    foreach (var item in listUnitProduct)
                    {
                        _unitProductService.Delete(item);
                    }
                    _unitProductService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listUnitProduct.Count);
                }
                return response;
            });
        }
    }
}