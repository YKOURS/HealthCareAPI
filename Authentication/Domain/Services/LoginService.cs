
using Authentication.Configurations;
using Authentication.Data;
using Authentication.Domain.Dto;
using Authentication.Repo;
using AutoMapper;
using System.Net;

namespace Authentication.Domain.Services
{
    public class LoginService : BaseService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IConfiguration _configuration;

        private readonly IMapper _mapper;

        private readonly ITokenService _token;
        public LoginService(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper, ITokenService token)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
            _token = token;
        }

        public Response<GetClientLogo> GetClientLogo()
        {
            var c = _configuration["CompanyInfo:CompanyName"];
            var t = _configuration["CompanyInfo:CompanyType"];

            var result = (from co in _unitOfWork.GetAll<Company>()
                          join ct in _unitOfWork.GetAll<CompanyType>()
                          on co.CompanyTypeId equals ct.Id
                          where ct.CompanyType1 == t
                          && co.CompanyName == c
                          select new GetClientLogo
                          {
                              ClientLogo = co.CompanyLogo
                          }).FirstOrDefault();

            if (result != null)
            {
                return new Response<GetClientLogo>(result, null, HttpStatusCode.OK);
            }
            else
            {
                return new Response<GetClientLogo>(null, "Client Logo Not Found", HttpStatusCode.NoContent);
            }
        }

        public Response<LoginResponseDto> UserLogin(UserLoginDto req)
        {
            if ((req.Email != null || req.MobileNumber != null) && req.Password != null)
            {
                var user = (from c in _unitOfWork.GetAll<Contact>()
                            join ct in _unitOfWork.GetAll<CompanyTaggedContact>()
                            on c.Id equals ct.ContactId
                            join r in _unitOfWork.GetAll<ComapanyRole>()
                            on ct.RoleId equals r.Id
                            where c.Mobile == req.MobileNumber && c.Password == req.Password
                            select new
                            {
                                ct.CompanyId,
                                ContactId = c.Id,
                                UserName = c.Mobile,
                                RoleId = r.Id,
                                Role = r.RoleKey,
                                Active = c.Active.GetValueOrDefault()
                            }
                           ).FirstOrDefault();

                if (user != null)
                {
                    if (user.Active)
                    {
                        var token = _token.GenerateToken(user.UserName, user.Role);

                        if (!String.IsNullOrEmpty(token))
                        {
                            var res = new LoginResponseDto()
                            {
                                ContactId = user.ContactId,
                                CompanyId = user.CompanyId,
                                Role = user.Role,
                                RoleId = user.RoleId,
                                Active = user.Active,
                                Token = token
                            };
                            return new Response<LoginResponseDto>(res, null, HttpStatusCode.OK);
                        }
                        else
                        {
                            return new Response<LoginResponseDto>(null, "Token Issue", HttpStatusCode.InternalServerError);
                        }
                    }
                    else
                    {
                        return new Response<LoginResponseDto>(null, "User Is InActive", HttpStatusCode.NoContent);
                    }
                }
                else
                {
                    return new Response<LoginResponseDto>(null, "Login Doesn't Exists", HttpStatusCode.NoContent);
                }
            }
            return new Response<LoginResponseDto>(null, "Enter UserName/Password", HttpStatusCode.NoContent);
        }

        //public Response<bool> RegisterCustomer(RegisterUserDto request)
        //{

        //    var c = _configuration["CompanyInfo:CompanyName"];

        //    var customer = _mapper.Map<Contact>(request);

        //    if (request.Id == 0)
        //    {
        //        var roleId = (from cr in _unitOfWork.GetAll<ComapanyRole>()
        //                      where cr.RoleKey == "Patient"
        //                      && cr.Active == true
        //                      select new
        //                      {
        //                          cr.Id
        //                      }).FirstOrDefault();

        //        var companyId = (from co in _unitOfWork.GetAll<Company>()
        //                         where co.CompanyName == c
        //                         select new
        //                         {
        //                             co.Id
        //                         }).FirstOrDefault();

        //        var companyTaggedContact = new CompanyTaggedContact()
        //        {
        //            CompanyId = companyId.Id,

        //        };

        //        customer.CreatedDate = DateTime.Now;

        //    }
        //}
    }
}
