using DMS.Data.Infrastructure;
using DMS.Data.Repositories;
using DMS.Model.Models;
using System.Collections.Generic;

namespace DMS.Service
{
    public interface IBranchService
    {
        Branch Add(Branch branch);

        void Update(Branch branch);

        Branch Delete(string id);

        IEnumerable<Branch> GetAll();

        IEnumerable<Branch> GetAll(string keyword);

        Branch GetById(string id);

        void Save();
    }

    public class BranchService : IBranchService
    {
        private IBranchRepository _branchRepository;
        private IUnitOfWork _unitOfWork;

        public BranchService(IBranchRepository branchRepository, IUnitOfWork unitOfWork)
        {
            this._branchRepository = branchRepository;
            this._unitOfWork = unitOfWork;
        }

        public Branch Add(Branch branch)
        {
            return _branchRepository.Add(branch);
        }

        public Branch Delete(string id)
        {
            return _branchRepository.Delete(id);
        }

        public IEnumerable<Branch> GetAll()
        {
            return _branchRepository.GetAll();
        }

        public IEnumerable<Branch> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _branchRepository.GetMulti(x => x.Name.Contains(keyword) || x.ID.Contains(keyword));
            else
                return _branchRepository.GetAll();
        }

        public Branch GetById(string id)
        {
            return _branchRepository.GetSingleByCondition(x => x.ID == id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Branch branch)
        {
            _branchRepository.Update(branch);
        }
    }
}