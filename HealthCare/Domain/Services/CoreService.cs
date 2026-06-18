using HealthCare.Data;
using HealthCare.Domain.Dto;
using HealthCare.Repo;
using System.Net;

namespace HealthCare.Domain.Services
{
    public class CoreService : BaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoreService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Response<List<LookUpDto>> GetLookUp(string Type)
        {
            var result = (from l in _unitOfWork.GetAll<Lookup>()
                          where Type == l.Type
                          select new LookUpDto
                          {
                              Id = l.Id,
                              Name = l.Name,
                              Key = l.Key
                          }
                          ).ToList();

            if (result.Count > 0)
            {
                return new Response<List<LookUpDto>>(result, null, HttpStatusCode.OK);
            }

            return new Response<List<LookUpDto>>(null, "No Data Found With This Type", HttpStatusCode.NoContent);
        }
    }
}
