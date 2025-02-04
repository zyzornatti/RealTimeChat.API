using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealTimeChat.API.CustomActionFilters;
using RealTimeChat.API.Interfaces;
using RealTimeChat.API.Models.Domain;
using RealTimeChat.API.Models.DTO;
using System.Security.Claims;

namespace RealTimeChat.API.Controllersc
{
    //[Route("api/[controller]")]
    [Route("api/chatrooms")]
    [ApiController]
    [Authorize]
    public class ChatRoomController : ControllerBase
    {
        private readonly IChatRoomService _chatRoomService;
        private readonly IMapper _mapper;

        public ChatRoomController(IChatRoomService chatRoomService, IMapper mapper)
        {
            _chatRoomService = chatRoomService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _chatRoomService.GetAllRooms();
            return Ok(_mapper.Map<List<ChatRoomDto>>(rooms));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetRoomById([FromRoute] Guid id)
        {
            var existingRoom = await _chatRoomService.GetRoomDetails(id);
            if (existingRoom == null)
            {
                return NotFound($"Chat Room with ID {id} not found.");
            }
            
            return Ok(_mapper.Map<ChatRoomDto>(existingRoom));
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateRoom([FromBody] AddChatRoomRequestDto chatRoomRequestDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var parsedUserId))
            {
                return BadRequest("User not authenticated");
            }

            var room = _mapper.Map<ChatRoom>(chatRoomRequestDto);
            room = new ChatRoom
            {
                RoomName = room.RoomName,
                Description = null ?? room.Description,
                CreatedByUserId = Guid.Parse(userId),
                CreatedAt = DateTime.UtcNow
            };

            room = await _chatRoomService.CreateRoom(room);

            return Ok(_mapper.Map<ChatRoom>(room));

        }
    }
}
