using HaliSaham.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace HaliSaham.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected RepositoryWrapper repo;
        protected IMemoryCache cache;

        public BaseController(RepositoryWrapper repo, IMemoryCache cache)
        {
            this.repo = repo;
            this.cache = cache;
        }
    }
}
