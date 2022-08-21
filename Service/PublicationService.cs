using Microsoft.AspNetCore.Mvc;
using publication.Models;
using publication.Repository.Implementation;
using publication.Repository;
using publication.Dto;
using AutoMapper;

namespace publication.Service;

public class PublicationService 
{
    private readonly IPublicationRepository _publicationrepository;
    private readonly IMapper _mapper;

    public PublicationService(IPublicationRepository publicationrepository, IMapper mapper)
    {
        _publicationrepository = publicationrepository;
        _mapper = mapper;
    }

    //get

    public IEnumerable<PublicationDto> GetPublication()
    {
        var result = _publicationrepository.Get();
        return _mapper.Map<List<PublicationDto>>(result);
    }   

    // post(DateTime errado)
    public string PostPublication(PublicationCreateDto publication)
    {
        var result = _mapper.Map<Publication>(publication);
        _publicationrepository.Post(result);
        return "Publicação criada";
    }

    //delete

    public string DeletePublication(int id)
    {
        Publication publication = _publicationrepository.GetById(id);
        if (publication == null) return "Id inválido";
        _publicationrepository.Delete(publication);
        return "Publicação deletada";
    }

    //update (Precisa resolver a questão do DTO do upadte)

    public string UpdatePublication(int id, Publication publication)
    {   
        if(id != publication.Id) return "Id não encontrada";
        _publicationrepository.Put(publication);
        return "Publicação alterada";
    }
    
    public PublicationDetailsDto DetailsPublication(int id)
    {
        var result = _publicationrepository.GetById(id);
        return _mapper.Map<PublicationDetailsDto>(result);
    }
}
