using System.Net;
using Articlib.Users.Api.Dtos;
using Articlib.Users.Api.Static;
using Articlib.Users.Infra.Persistence.Queries;
using AutoMapper;
using LittleByte.Extensions.AspNet.Responses;
using LittleByte.Extensions.AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Users.Api.Controllers;

public sealed class BatchGetByIdUserController : UserController
{
    private readonly IMapper mapper;
    private readonly IFindUsersByIdQuery query;

    public BatchGetByIdUserController(IFindUsersByIdQuery query, IMapper mapper)
    {
        this.query = query;
        this.mapper = mapper;
    }

    [HttpPost(Routes.FindByIdBatch)]
    [ResponseType(HttpStatusCode.OK, typeof(UserDto[]))]
    public async Task<ApiResponse<UserDto[]>> Get(Guid[] ids)
    {
        var users = await query.SendAsync(ids);
        var dtos = mapper.MapRange<UserDto>(users);
        return new OkResponse<UserDto[]>(dtos);
    }
}
