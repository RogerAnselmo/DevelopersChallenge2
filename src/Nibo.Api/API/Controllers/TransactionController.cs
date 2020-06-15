using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionRepository _transactionRepository;
        public TransactionController(TransactionRepository transactionRepository) => 
            _transactionRepository = transactionRepository;

        [HttpGet]
        public async Task<ObjectResult> Get()
        {
            var result = await _transactionRepository.GetAsync();
            return Ok(result.OrderBy(x => x.DatePosted));
        }

        [HttpPost]
        public async Task<ObjectResult> Post([FromBody] Transaction[] transactions)
        {
            var result = await _transactionRepository.AddAsync(transactions);

            if (!result)
                return BadRequest(new { message = "erro ao salvar transações." });

            return Created("", new { message = "transações salvas com sucesso." });
        }

        [HttpPost]
        [Route("VerifyNewTransactions")]
        public ObjectResult VerifyNewTransactions([FromBody] Transaction[] transactions)
        {
            var result = _transactionRepository.VerifyNewTransactions(transactions);
            return Ok(result);
        }
    }
}