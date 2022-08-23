using Microsoft.AspNetCore.Mvc;
using publication.Models;
using publication.Repository.Implementation;
using publication.Repository;
using publication.Dto;
using AutoMapper;
using publication.exceptions;
using publication.Enum;
using System.Dynamic;

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

    public IEnumerable<PublicationDto> GetPublication(
        int pageNumber = 1,
        int pageSize = 5,
        string? search = "",
        OrderByColumnPublicationEnum orderByColumn = OrderByColumnPublicationEnum.Id,
        OrderByTypeEnum orderByType = OrderByTypeEnum.ASC)
    {
        var listPublication = _publicationrepository.Get(pageNumber, pageSize, search, orderByColumn, orderByType);

        dynamic result = new ExpandoObject();
        result.currentPage = pageNumber;
        result.pageSize = pageSize;
        result.totalPages = Math.Ceiling((double)listPublication.TotalItemCount / pageSize);
        result.totalItems = listPublication.TotalItemCount;
        result.search = search;
        result.orderByColumn = orderByColumn;
        result.orderByType = orderByType;
        result.data = _mapper.Map<List<PublicationDto>>(listPublication);

        return _mapper.Map<List<PublicationDto>>(listPublication);
    }   

    // post(DateTime errado)
    public async Task<string> PostPublication(PublicationCreateDto publicationdto)
    {
        Publication publicationDb = await GetByTitle(publicationdto.Title!);
        if (publicationDb != null) throw new ErrorException((int)StatusCodes.Status400BadRequest, "Já existe publicação com esse título.");
        var result = _mapper.Map<Publication>(publicationdto);
        _publicationrepository.Post(result);
        return "Publicação criada";
    }

    //delete

    public async Task<string> DeletePublication(int id)
    {
        Publication publication = await _publicationrepository.GetById(id);
        if (publication == null) return "Id inválido";
        _publicationrepository.Delete(publication);
        return "Publicação deletada";
    }

    //update 

    public string UpdatePublication(int id, PublicationDto publication)
    {   
        if(id != publication.Id) return "Id não encontrada";
        Publication publicationModel = _mapper.Map<Publication>(publication);
        _publicationrepository.Put(publicationModel);
        return "Publicação alterada";
    }
    
    public async Task<PublicationDetailsDto> DetailsPublication(int id)
    {
        return _mapper.Map<PublicationDetailsDto>(await _publicationrepository.GetById(id));
    }

    public async Task<Publication> GetByTitle(string title)
    {
        return await _publicationrepository.GetByTitle(title);
    }
}
