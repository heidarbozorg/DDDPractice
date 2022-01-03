using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<Domain.Entities.User>> GetAllAsync()
        {
            var repository = _unitOfWork.GetRepository<Domain.Entities.User>();
            var rst = await repository.GetAllAsync();
            return rst;
        }

        [HttpGet("GetById")]
        public async Task<Domain.Entities.User> Search(int id)
        {
            var repository = _unitOfWork.GetRepository<Domain.Entities.User>();
            var rst = await repository.GetByIdAsync(id);
            return rst;
        }

        [HttpPost]
        public async Task<Domain.Entities.User> AddAsync(Domain.Entities.User data)
        {
            var repository = _unitOfWork.GetRepository<Domain.Entities.User>();
            var rst = await repository.AddAsync(data);
            await _unitOfWork.Complete();
            return rst;
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(Domain.Entities.User data)
        {
            var repository = _unitOfWork.GetRepository<Domain.Entities.User>();
            var rst = await repository.UpdateAsync(data);
            if (rst == null)
                return NotFound();

            await _unitOfWork.Complete();
            return Ok(rst);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var repository = _unitOfWork.GetRepository<Domain.Entities.User>();
            var rst = await repository.DeleteAsync(id);
            await _unitOfWork.Complete();
            return Ok(rst);
        }
    }
}