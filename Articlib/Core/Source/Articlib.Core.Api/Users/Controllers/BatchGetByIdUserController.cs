using System.Net;
using Articlib.Core.Infra.Users;
using AutoMapper;
using LittleByte.Extensions.AspNet.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Core.Api.Users;

public sealed class BatchGetByIdUserController : UserController
{
    private readonly IFindUsersByIdQuery query;
    private readonly IMapper mapper;

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
        var dtos = users.Select(u => mapper.Map<UserDto>(u)).ToArray();
        return new OkResponse<UserDto[]>(dtos);
    }
}