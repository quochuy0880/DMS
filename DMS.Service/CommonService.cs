using DMS.Common;
using DMS.Data.Infrastructure;
using DMS.Data.Repositories;
using DMS.Model.Models;

namespace DMS.Service
{
    public interface ICommonService
    {
        Footer GetFooter();

        //IEnumerable<Slide> GetSlides();
    }

    public class CommonService : ICommonService
    {
        private IFooterRepository _footerRepository;
        private IUnitOfWork _unitOfWork;

        //ISlideRepository _slideRepository;
        public CommonService(IFooterRepository footerRepository, IUnitOfWork unitOfWork)
        {
            _footerRepository = footerRepository;
            _unitOfWork = unitOfWork;
            //_slideRepository = slideRepository;
        }

        public Footer GetFooter()
        {
            return _footerRepository.GetSingleByCondition(x => x.ID == CommonConstants.DefaultFooterId);
        }

        //public IEnumerable<Slide> GetSlides()
        //{
        //    return _slideRepository.GetMulti(x => x.Status);
        //}
    }
}