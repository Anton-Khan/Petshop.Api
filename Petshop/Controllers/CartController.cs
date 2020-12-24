using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Petshop.Repositories;

namespace Petshop.Controllers
{
    [Route("cart")]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        private readonly IPetsRepository _petsRepository;
        public CartController(IPetsRepository petsRepository, ICartRepository cartRepository)
        {
            _petsRepository = petsRepository;
            _cartRepository = cartRepository;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            var items = _cartRepository.GetItems();
            var pets = items.Select(x => _petsRepository.GetPet(x));
            return Ok(pets);
        }

        [HttpPost]
        [Route("{petId}")]
        private IActionResult PostItem([FromRoute] Guid petId)
        {
            _cartRepository.AddItem(petId);
            var pet = _petsRepository.GetPet(petId);
            return Ok(pet);
        }

        [HttpDelete]
        [Route("{petId}")]
        private IActionResult DeleteItem([FromRoute] Guid petId)
        {
            _cartRepository.RemoveItem(petId);
            var pet = _petsRepository.GetPet(petId);
            return Ok(pet);
        }

        [HttpDelete]
        private IActionResult DeleteItems()
        {
            _cartRepository.RemoveAllItems();
            return Ok();
        }


    }
}
