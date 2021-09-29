using AutoMapper;
using CleanArchitecture.Api.Responses;
using CleanArchitecture.ApplicationCore.CustomEntities;
using CleanArchitecture.ApplicationCore.DTOs;
using CleanArchitecture.ApplicationCore.Entities;
using CleanArchitecture.ApplicationCore.Interfaces.Services;
using CleanArchitecture.ApplicationCore.QueryFilters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieve all users
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetUsers))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<UserDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetUsers([FromQuery] UserQueryFilter filters)
        {
            var users = _userService.GetUsers(filters);
            var usersDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            var metadata = new Metadata(users.TotalCount, users.PageSize, users.CurrentPage, users.TotalPages, users.HasNextPage, users.HasPreviousPage);
            var response = new ApiResponse<IEnumerable<UserDto>>(usersDtos, metadata);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        /// <summary>
        /// Retrieve an user by Id
        /// </summary>
        /// <param name="id">Id of the User</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<UserDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUser(id);
            var userDto = _mapper.Map<UserDto>(user);
            var response = new ApiResponse<UserDto>(userDto);
            return Ok(response);
        }

        /// <summary>
        /// Add an User
        /// </summary>
        /// <param name="userDto">User to add</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<UserDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userService.InsertUser(user);
            userDto = _mapper.Map<UserDto>(user);
            var response = new ApiResponse<UserDto>(userDto);
            return Ok(response);
        }

        /// <summary>
        /// Update an User
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="userDto">User to update</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<bool>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateUser(int id, UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.Id = id;
            var result = await _userService.UpdateUser(user);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        /// <summary>
        /// Delete an User
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<bool>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUser(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
