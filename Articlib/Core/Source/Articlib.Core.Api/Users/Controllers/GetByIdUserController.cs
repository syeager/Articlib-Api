using System.Net;
using Articlib.Core.Domain.Users;
using AutoMapper;
using LittleByte.Extensions.AspNet.Responses;
using LittleByte.Infra.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Articlib.Core.Api.Users;

public sealed class GetByIdUserController : UserController
{
    private readonly IFindByIdQuery<User> findByIdQuery;
    private readonly IMapper mapper;

    public GetByIdUserController(IMapper mapper, IFindByIdQuery<User> findByIdQuery)
    {
        this.mapper = mapper;
        this.findByIdQuery = findByIdQuery;
    }

    [HttpGet(Routes.FindById)]
    [ResponseType(HttpStatusCode.OK, typeof(UserDto))]
    [ResponseType(HttpStatusCode.NotFound)]
    public async Task<ApiResponse<UserDto>> Get(Guid id)
    {
        var user = await findByIdQuery.FindRequiredAsync(id);
        var dto = mapper.Map<UserDto>(user);
        return new OkResponse<UserDto>(dto);
    }
}
