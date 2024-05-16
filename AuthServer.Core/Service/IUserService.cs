﻿using AuthServer.Core.Dtos;
using SharedLibrary.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Service
{
    public interface IUserService
    {
        Task<ResponseDto<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);

        Task<ResponseDto<UserAppDto>> GetUserByUserNameAsync(string userName);

        Task<ResponseDto<NoDataDto>> CreateRoleAsync(string roleName);

        Task<ResponseDto<NoDataDto>> AssignRoleToUserAsync(AssignRoleToUserDto dto);
    }
}
