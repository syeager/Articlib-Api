using System.Net;
using Articlib.Core.Domain.Users;
using Articlib.Core.Infra.Users;
using AutoMapper;
using LittleByte.Extensions.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Core.Api.Users;

public sealed class CreateUserController : UserController
{
    private readonly IMapper mapper;
    private readonly IUserRegisterService registerService;
    private readonly IUserWriteRepo userRepo;

    public CreateUserController(IMapper mapper, IUserRegisterService registerService, IUserWriteRepo userRepo)
    {
        this.mapper = mapper;
        this.registerService = registerService;
        this.userRepo = userRepo;
    }

    [HttpPost("create")]
    [ResponseType(HttpStatusCode.Created, typeof(UserDto))]
    [ResponseType(HttpStatusCode.BadRequest)]
    public async Task<ApiResponse<UserDto>> Create(UserRegisterRequest request)
    {
        var user = registerService.Register(request.Email, request.Name);
        var dto = mapper.Map<UserDto>(user.GetModelOrThrow());
        await userRepo.SaveChangesAsync(); // TODO: Repo usage is not obvious.
        return new CreatedResponse<UserDto>(dto);
    }
}