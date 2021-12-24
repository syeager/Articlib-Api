using System.Net;
using Articlib.Core.Infra.Users;
using AutoMapper;
using LittleByte.Extensions.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Core.Api.Users;

public sealed class GetByIdUserController : UserController
{
    private readonly IMapper mapper;
    private readonly IUserReadRepo userRepo;

    public GetByIdUserController(IMapper mapper, IUserReadRepo userRepo)
    {
        this.mapper = mapper;
        this.userRepo = userRepo;
    }

    [HttpGet(Routes.FindById)]
    [ResponseType(HttpStatusCode.OK, typeof(UserDto))]
    [ResponseType(HttpStatusCode.NotFound)]
    public async Task<ApiResponse<UserDto>> Get(Guid id)
    {
        var user = await userRepo.GetByIdAsync(id);
        var dto = mapper.Map<UserDto>(user);
        return new OkResponse<UserDto>(dto);
    }
}