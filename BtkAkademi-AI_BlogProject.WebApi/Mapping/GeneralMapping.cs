using AutoMapper;
using BtkAkademi_AI_BlogProject.WebApi.DTO_s.ArticleDtos;
using BtkAkademi_AI_BlogProject.WebApi.DTO_s.CategoryDtos;
using BtkAkademi_AI_BlogProject.WebApi.DTO_s.CommentDtos;
using BtkAkademi_AI_BlogProject.WebApi.DTO_s.ContactDtos;
using BtkAkademi_AI_BlogProject.WebApi.DTO_s.MessageDtos;
using BtkAkademi_AI_BlogProject.WebApi.DTO_s.SliderCarouselDtos;
using BtkAkademi_AI_BlogProject.WebApi.Entities;

namespace BtkAkademi_AI_BlogProject.WebApi.Mapping
{
	public class GeneralMapping : Profile
	{
		public GeneralMapping() 
		{
			CreateMap<Article, ResultArticleWithCategoryDto>()
				.ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.AppUser.Name))
				.ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.AppUser.Surname))
				.ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.AppUser.ImageUrl))
				.ReverseMap();

			CreateMap<Comment, ResultCommentWithArticleAndAuthorDto>()
				.ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Article.Title))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.AppUser.Name))
				.ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.AppUser.Surname))
				.ReverseMap();

			CreateMap<Article, ResultLastPoliticArticleDto>()
				.ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.AppUser.Name))
				.ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.AppUser.Surname))
				.ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.AppUser.ImageUrl))
				.ReverseMap();

			CreateMap<Article, ResultLastTechnologyArticleDto>()
				.ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.AppUser.Name))
				.ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.AppUser.Surname))
				.ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.AppUser.ImageUrl))
				.ReverseMap();

			CreateMap<Article, ResultLastTravelArticleDto>()
				.ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.AppUser.Name))
				.ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.AppUser.Surname))
				.ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.AppUser.ImageUrl))
				.ReverseMap();

			CreateMap<Article, CreateArticleDto>().ReverseMap();
			CreateMap<Article, UpdateArticleDto>().ReverseMap();
			CreateMap<Article, GetArticleByIdDto>().ReverseMap();

			CreateMap<Category, CreateCategoryDto>().ReverseMap();
			CreateMap<Category, UpdateCategoryDto>().ReverseMap();

			CreateMap<Comment, ResultCommentDto>().ReverseMap();
			CreateMap<Comment, CreateCommentDto>().ReverseMap();
			CreateMap<Comment, UpdateCommentDto>().ReverseMap();
			CreateMap<Comment, GetCommentByIdDto>().ReverseMap();

			CreateMap<Contact, ResultContactDto>().ReverseMap();
			CreateMap<Contact, CreateContactDto>().ReverseMap();
			CreateMap<Contact, UpdateContactDto>().ReverseMap();
			CreateMap<Contact, GetContactByIdDto>().ReverseMap();

			CreateMap<SliderCarousel, GetSliderCarouselByIdDto>().ReverseMap();
			CreateMap<SliderCarousel, CreateSliderCarouselDto>().ReverseMap();
			CreateMap<SliderCarousel, UpdateSliderCarouselDto>().ReverseMap();
			CreateMap<SliderCarousel, ResultSliderCarouselDto>().ReverseMap();

			CreateMap<Message, ResultMessageDto>().ReverseMap();
			CreateMap<Message, CreateMessageDto>().ReverseMap();
			CreateMap<Message, UpdateMessageDto>().ReverseMap();
			CreateMap<Message, GetMessageByIdDto>().ReverseMap();
		}
	}
}
