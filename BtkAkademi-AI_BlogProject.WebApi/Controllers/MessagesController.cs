using AutoMapper;
using BtkAkademi_AI_BlogProject.WebApi.Context;
using BtkAkademi_AI_BlogProject.WebApi.DTO_s.MessageDtos;
using BtkAkademi_AI_BlogProject.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BtkAkademi_AI_BlogProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessagesController : ControllerBase
	{
		private readonly BlogIAContext _context;
		private readonly IMapper _mapper;
		public MessagesController(BlogIAContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult MessageList()
		{
			var values = _context.Messages.ToList();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDto createMessageDto)
		{
			var value = _mapper.Map<Message>(createMessageDto);
			_context.Messages.Add(value);
			_context.SaveChanges();
			return Ok("Ekleme İşlemi Başarılı..!");
		}

		[HttpPut]
		public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
		{
			var value = _mapper.Map<Message>(updateMessageDto);
			_context.Messages.Update(value);
			_context.SaveChanges();
			return Ok("Güncelleme Başarılı..!");
		}

		[HttpGet("GetMessage")]
		public IActionResult GetMessage(int id)
		{
			var value = _context.Messages.Find(id);
			return Ok(value);
		}

		[HttpDelete]
		public IActionResult RemoveMessage(int id)
		{
			var value = _context.Messages.Find(id);
			_context.Messages.Remove(value);
			_context.SaveChanges();
			return Ok("Silme İşlemi Başarılı..!");
		}

		[HttpGet("GetUnreadMessageList")]
		public IActionResult GetUnreadMessageList()
		{
			var values = _context.Messages.Where(x => x.IsRead == false).ToList();
			return Ok(values);
		}
	}
}
