using Salon.Application.DTO;
using Salon.Application.Interfaces;
using Salon.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Salon.Application.Helper;
using Salon.Domain.Enumerations;

namespace Salon.Application.Services
{
    class UserServices: IUserRepository
    {
    

    private readonly UserManager<AppUser> _userManager;
        // private readonly IMapper _mapper;
        //, IMapper mapper
        public UserServices(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
      //  _mapper = mapper;
    }

     // public async Task<UserResponce> Create(User user, string password)


        public async Task<UserResponce> CreateUser(AppUser user, string password)
    {
      //  var appUser = _mapper.Map<AppUser>(user);
        var identityResult = await _userManager.CreateAsync(user, password);
        return new UserResponce(user.Id, identityResult.Succeeded, identityResult.Succeeded ? null : identityResult.Errors.Select(e => new Error(e.Code, e.Description)));
    }

    public async Task<AppUser> FindByName(string userName)

    {
           // return _mapper.Map<User>(await _userManager.FindByNameAsync(userName));
            return  (await _userManager.FindByNameAsync(userName));
    }

    public async Task<bool> CheckPassword(AppUser user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }


        public async Task<IPagedList<AppUser>> GetUsersAsync(UserPagedDataRequest request)
        {
            var query = _userManager.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.LastName))
                query = query.Where(x => x.LastName.StartsWith(request.LastName));

            if (!string.IsNullOrWhiteSpace(request.RoleName))
                query = query.Where(x => x.Role.Name == request.RoleName);

            if (request.Active.HasValue)
                query = query.Where(x => x.IsActive == request.Active.Value);

            string orderBy = request.SortField.ToString();
            if (QueryHelper.PropertyExists<AppUser>(orderBy))
                query = request.SortOrder == SortOrder.Ascending ? query.OrderByProperty(orderBy) : query.OrderByPropertyDescending(orderBy);
            else
                query = query.OrderBy(x => x.LastName);

            var result = new PagedList<AppUser>();
            await result.CreateAsync(query, request.PageIndex, request.PageSize);
            return result;
        }


    }
}
