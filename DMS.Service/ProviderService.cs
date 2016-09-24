using DMS.Common;
using DMS.Data.Infrastructure;
using DMS.Data.Repositories;
using DMS.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DMS.Service
{
    public interface IProviderService
    {
        Provider Add(Provider provider);

        void Update(Provider provider);

        Provider Delete(int id);

        IEnumerable<Provider> GetAll();

        IEnumerable<Provider> GetAll(string keyword);

        IEnumerable<string> GetListProviderByName(string name);

        IEnumerable<Provider> Search(string keyword, int page, int pageSize, string sort, out int totalRow);

        Provider GetById(int id);

        void Save();
    }

    public class ProviderService : IProviderService
    {
        private IProviderRepository _providerRepository;
        private ITagRepository _tagRepository;
        private IProviderTagRepository _providerTagRepository;
        private IUnitOfWork _unitOfWork;

        public ProviderService(IProviderRepository providerRepository, IProviderTagRepository providerTagRepository, ITagRepository tagRepository, IUnitOfWork unitOfWork)
        {
            this._providerRepository = providerRepository;
            this._providerTagRepository = providerTagRepository;
            this._tagRepository = tagRepository;
            this._unitOfWork = unitOfWork;
        }

        public Provider Add(Provider provider)
        {
            var _provider = _providerRepository.Add(provider);
            _unitOfWork.Commit();
            if (!string.IsNullOrEmpty(provider.Tags))
            {
                string[] tags = provider.Tags.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (_tagRepository.Count(x => x.ID == tagId) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagId;
                        tag.Name = tags[i];
                        tag.Type = CommonConstants.ProviderTag;
                        _tagRepository.Add(tag);
                    }
                    ProviderTag providerTag = new ProviderTag();
                    providerTag.ProviderID = provider.ID;
                    providerTag.TagID = tagId;
                    _providerTagRepository.Add(providerTag);
                }
            }
            return _provider;
        }

        public Provider Delete(int id)
        {
            return _providerRepository.Delete(id);
        }

        public IEnumerable<Provider> GetAll()
        {
            return _providerRepository.GetAll();
        }

        public IEnumerable<Provider> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _providerRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            else
                return _providerRepository.GetAll();
        }

        public Provider GetById(int id)
        {
            return _providerRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Provider provider)
        {
            _providerRepository.Update(provider);
            _unitOfWork.Commit();
            if (!string.IsNullOrEmpty(provider.Tags))
            {
                string[] tags = provider.Tags.Split(',');
                for (var i = 0; i < tags.Length; i++)
                {
                    var tagId = StringHelper.ToUnsignString(tags[i]);
                    if (_tagRepository.Count(x => x.ID == tagId) == 0)
                    {
                        Tag tag = new Tag();
                        tag.ID = tagId;
                        tag.Name = tags[i];
                        tag.Type = CommonConstants.ProviderTag;
                        _tagRepository.Add(tag);
                    }
                    _providerTagRepository.DeleteMulti(x => x.ProviderID == provider.ID);
                    ProviderTag proivderTag = new ProviderTag();
                    proivderTag.ProviderID = provider.ID;
                    proivderTag.TagID = tagId;
                    _providerTagRepository.Add(proivderTag);
                }
            }
        }

        public IEnumerable<string> GetListProviderByName(string name)
        {
            return _providerRepository.GetMulti(x => x.Status && x.Name.Contains(name)).Select(y => y.Name);
        }

        public IEnumerable<Provider> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
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