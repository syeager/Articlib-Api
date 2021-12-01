using Articlib.Users.Api.Dtos;
using Articlib.Users.Api.Requests;
using Articlib.Users.Domain.Services;
using Articlib.Users.Infra.Persistence.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Users.Api.Controllers;

[Route("users", Name = "Users")]
[ApiController]
public class UserController : Controller
{
    private readonly IMapper mapper;
    private readonly IUserRegisterService registerService;
    private readonly IUserWriteRepo userRepo;

    public UserController(IMapper mapper, IUserRegisterService registerService, IUserWriteRepo userRepo)
    {
        this.mapper = mapper;
        this.registerService = registerService;
        this.userRepo = userRepo;
    }

    [HttpPost("create")]
    public async Task<ActionResult<UserDto>> Create(UserRegisterRequest request)
    {
        var user = registerService.Register(request.Email, request.Name);
        await userRepo.SaveChangesAsync();
        var dto = mapper.Map<UserDto>(user.GetModelOrThrow());
        return Ok(dto);
    }
}