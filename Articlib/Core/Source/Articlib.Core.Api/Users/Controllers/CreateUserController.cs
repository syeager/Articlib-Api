using System.Net;
using Articlib.Core.Domain.Users;
using Articlib.Core.Infra.Users;
using AutoMapper;
using LittleByte.Extensions.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Core.Api.Users;

[Route("users", Name = "Users")]
[ApiController]
public class CreateUserController : Controller
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
        await userRepo.SaveChangesAsync();
        return new CreatedResponse<UserDto>(dto);
    }
}