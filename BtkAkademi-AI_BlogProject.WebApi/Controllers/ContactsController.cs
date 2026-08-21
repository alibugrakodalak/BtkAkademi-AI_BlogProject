using AutoMapper;
using BtkAkademi_AI_BlogProject.WebApi.Context;
using BtkAkademi_AI_BlogProject.WebApi.DTO_s.ContactDtos;
using BtkAkademi_AI_BlogProject.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BtkAkademi_AI_BlogProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly BlogIAContext _context;
		private readonly IMapper _mapper;
		public ContactsController(BlogIAContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult ContactList()
		{
			var values = _context.Contacts.ToList();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateContact(CreateContactDto createContactDto)
		{
			var value = _mapper.Map<Contact>(createContactDto);
			_context.Contacts.Add(value);
			_context.SaveChanges();
			return Ok("İletişim Bilgisi Ekleme İşlemi Başarılı..!");
		}

		[HttpPut]
		public IActionResult UpdateContact(UpdateContactDto updateContactDto)
		{
			var value = _mapper.Map<Contact>(updateContactDto);
			_context.Contacts.Update(value);
			_context.SaveChanges();
			return Ok("Güncelleme Başarılı..!");
		}

		[HttpGet("GetContact")]
		public IActionResult GetContact(int id)
		{
			var value = _context.Contacts.Find(id);
			return Ok(value);
		}

		[HttpDelete]
		public IActionResult RemoveContact(int id)
		{
			var value = _context.Contacts.Find(id);
			_context.Contacts.Remove(value);
			_context.SaveChanges();
			return Ok("Silme İşlemi Başarılı..!");
		}

		[HttpGet("GetFirstContact")]
		public IActionResult GetFirstContact()
		{
			var values = _context.Contacts.FirstOrDefault();
			return Ok(values);
		}
	}
}
