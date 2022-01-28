using System.Net;
using Articlib.Core.Infra.Users.Queries;
using AutoMapper;
using LittleByte.Extensions.AspNet.Responses;
using LittleByte.Extensions.AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Core.Api.Users;

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
    [ResponseType(HttpStatusCode.OK, typeof(List<UserDto>))]
    public async Task<ApiResponse<List<UserDto>>> Get(Guid[] ids)
    {
        var users = await query.SendAsync(ids);
        var dtos = mapper.MapRange<UserDto>(users).ToList();
        return new OkResponse<List<UserDto>>(dtos);
    }
}
