using AutoMapper;
using CourseLibrary.APII.Entities;
using CourseLibrary.APII.Helpers;
using CourseLibrary.APII.Models;
using CourseLibrary.APII.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CourseLibrary.APII.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly ICourseLibraryRepository _repository;
        private readonly IMapper _mapper;
        public AuthorController(ICourseLibraryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<AuthorDTO>> GetAuthors()
        {
            var authors = _repository.GetAuthors();

            var listAuthorDTO = _mapper.Map<IEnumerable<AuthorDTO>>(authors);

            return Ok(listAuthorDTO);
        }

        [HttpGet("filter")]
        public ActionResult<IEnumerable<AuthorDTO>> GetAuthorsByFilter(string mainCategory)
        {
            var authorsFilter = _repository.GetAllAuthorByFilter(mainCategory);

            return Ok(_mapper.Map<IEnumerable<AuthorDTO>>(authorsFilter));
        }

        [HttpGet("Search")]
        public ActionResult<IEnumerable<AuthorDTO>> GetAuthorsBySearching(string searching)
        {
            var authorSearching = _repository.GetAuthorsBySearching(searching);

            return Ok(_mapper.Map<IEnumerable<AuthorDTO>>(authorSearching));
        }

        [Consumes("application/json")]// this is configured for which type of input can be accepted
        [Produces("application/xml")]// this is configured for which type of output can be accepted
        [HttpGet("{authorId}", Name = "GetAuthorById")]
        public ActionResult<AuthorDTO> GetAuthor(Guid authorId)
        {
            var author = _repository.GetAuthor(authorId);

            var newAuthor = _mapper.Map<AuthorDTO>(author);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(newAuthor);
        }
        [HttpPost]
        public ActionResult<AuthorDTO> AddAuthor(AuthorForCreationDTO author)
        {
            var newAuthor = _mapper.Map<Author>(author);
            var result = _repository.AddAuthor(newAuthor);

            var authorDTO = _mapper.Map<AuthorDTO>(result);
            //return CreatedAtAction(nameof(GetAuthor), new { authorId = authorDTO.Id }, authorDTO);
            return CreatedAtRoute("GetAuthorById", new { authorId = authorDTO.Id }, authorDTO);
        }

        [HttpPost("AuthorCollection")]
        public ActionResult<IEnumerable<AuthorDTO>> AuthorCollection(IEnumerable<AuthorForCreationDTO> authors)
        {
            var listOfAuthors = _mapper.Map<IEnumerable<Author>>(authors);

            foreach (var author in listOfAuthors)
            {
                _repository.AddAuthor(author);
            }
            return Ok(listOfAuthors);
        }
    }
}

