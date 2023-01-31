using AutoMapper;
using DSortAPI.Dto;
using DSortAPI.Dto.Document;
using DSortAPI.Model;

namespace DSortAPI.Helpers.Mapper
{
    public class AutoMapperProfiles : Profile
		{
		public AutoMapperProfiles()
			{
			CreateMap<Document, Document>();
			CreateMap<Person, Person>();
			//CreateMap<Scan, CreateScanDTO>();
			//CreateMap<CreateScanDTO, Scan>();
			//CreateMap<Scan, Scan>();
			CreateMap<CreateDocumentDto,Document>();
			CreateMap<Document, ReadDocumentDto>();
			}





		}
	}
