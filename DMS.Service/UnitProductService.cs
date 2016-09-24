using DMS.Data.Infrastructure;
using DMS.Data.Repositories;
using DMS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DMS.Service
{
    public interface IUnitProductService
    {
        UnitProduct Add(UnitProduct unitProduct);

        void Update(UnitProduct unitProduct);

        UnitProduct Delete(int id);

        IEnumerable<UnitProduct> GetAll();

        IEnumerable<UnitProduct> GetAll(string keyword);

        IEnumerable<string> GetListUnitProductByName(string name);

        IEnumerable<UnitProduct> Search(string keyword, int page, int pageSize, string sort, out int totalRow);

        UnitProduct GetById(int id);

        void Save();
    }

    public class UnitProductService : IUnitProductService
    {
        private IUnitProductRepository _unitProductRepository;
        private IUnitOfWork _unitOfWork;

        public UnitProductService(IUnitProductRepository unitProductRepository, IUnitOfWork unitOfWork)
        {
            this._unitProductRepository = unitProductRepository;
            this._unitOfWork = unitOfWork;
        }

        public UnitProduct Add(UnitProduct unitProduct)
        {
            return _unitProductRepository.Add(unitProduct);
        }

        public UnitProduct Delete(int id)
        {
            return _unitProductRepository.Delete(id);
        }

        public IEnumerable<UnitProduct> GetAll()
        {
            return _unitProductRepository.GetAll();
        }

        public IEnumerable<UnitProduct> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _unitProductRepository.GetMulti(x => x.Name.Contains(keyword));
            else
                return _unitProductRepository.GetAll();
        }

        public UnitProduct GetById(int id)
        {
            return _unitProductRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(UnitProduct unitProduct)
        {
            _unitProductRepository.Update(unitProduct);
        }

        public IEnumerable<string> GetListUnitProductByName(string name)
        {
            return _unitProductRepository.GetMulti(x => x.Name.Contains(name)).Select(y => y.Name);
        }

        public IEnumerable<UnitProduct> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            throw new NotImplementedException();
            //var query = _providerRepository.GetMulti(x => x.Status && x.ProviderName.Contains(keyword));

            //switch (sort)
            //{
            //    case "popular":
            //        query = query.OrderByDescending(x => x.ViewCount);
            //        break;
            //    case "discount":
            //        query = query.OrderByDescending(x => x.PromotionPrice.HasValue);
            //        break;
            //    case "price":
            //        query = query.OrderBy(x => x.Price);
            //        break;
            //    default:
            //        query = query.OrderByDescending(x => x.CreDate);
            //        break;
            //}
            //totalRow = query.Count();

            //return query.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}