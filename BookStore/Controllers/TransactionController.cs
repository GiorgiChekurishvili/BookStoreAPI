using BookStore.DTOs.Transaction;
using BookStore.Services.TransactionService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        [Authorize(Roles = "Member")]
        [HttpPost("fillbalance/{deposit}")]
        public async Task<ActionResult<decimal>> FillBalance(decimal deposit)
        {
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var balance = await _transactionService.FillBalanceService(deposit, userId);
            if (balance == -1)
            {
                return BadRequest();
            }
            return Ok("balance in your account: " + balance + " $");
        }
        [Authorize(Roles = "Member")]
        [HttpGet("viewmybalance")]
        public async Task<ActionResult<decimal>> ViewMyBalance()
        {
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var balance = await _transactionService.ViewMyBalanceService(userId);
            return Ok("balance: "+ balance + "$");
        }
        [Authorize(Roles = "Member")]
        [HttpPost("buybook/{bookId}/{bookQuantity}")]
        public async Task<ActionResult<decimal>> BuyBook(int bookId, int bookQuantity)
        {
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            BuyBookTransactionDTO buyBook = new BuyBookTransactionDTO()
            {
                BookId = bookId,
                BoughtQuantity = bookQuantity,
                UserId = userId

            };
            var balance = await _transactionService.BuyBookService(buyBook);
            if (balance == -1)
            {
                return BadRequest();
            }
            return Ok("total price: " + balance + " $");
        }
        [Authorize(Roles = "Member")]
        [HttpGet("viewmybooks")]
        public async Task<ActionResult<IEnumerator<TransactionDTO>>> ViewMyBooks()
        {
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var data =  await _transactionService.ViewBoughtBooksService(userId);
            if (data == null)
            {
                return BadRequest("you havent bought any books");
            }
            return Ok(data);
        }

    }
}
