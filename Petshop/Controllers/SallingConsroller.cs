using Petshop.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.Controllers
{
    [Route("salling")]
    public class SallingConsroller : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        private readonly IPetsRepository _petsRepository;
        private readonly IUserRepository _userRepository;

        public SallingConsroller(IPetsRepository petsRepository, ICartRepository cartRepository, IUserRepository userRepository)
        {
            _petsRepository = petsRepository;
            _cartRepository = cartRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("balance")]
        public IActionResult GetUserBalance()
        {
            var balance = _userRepository.GetBalance();
            var response = new { Balance = balance };
            return Ok(response);
        }

        [HttpGet]
        [Route("cost")]
        public IActionResult GetCost()
        {
            var items = _cartRepository.GetItems();
            var cost = items
                .Select(item => _petsRepository.GetPet(item).Price)
                .Sum();
            var responce = new { TotalCost = cost };
            return Ok(responce);
        }

        [HttpPost]
        public IActionResult BuyItems()
        {
            var items = _cartRepository.GetItems();
            if (items != null)
            {
                var balance = _userRepository.GetBalance();

                var cost = items
                    .Select(item => _petsRepository.GetPet(item).Price)
                    .Sum();

                if (balance >= cost)
                {
                    items.Select(id => _petsRepository.RemovePet(id));
                    _cartRepository.RemoveAllItems();
                    var newBalance = balance - cost;
                    _userRepository.ChangeBalance(newBalance);

                    var responce = new { Balance = newBalance };

                    return Ok(responce);
                }
                else
                    throw new Exception($"Недостаточно средств на вашем счете. Баланс: {balance}. Стоимость: {cost}.");
            }
            else
                throw new Exception($"Ваша корзина пуста.");
            
        }

    }
}
