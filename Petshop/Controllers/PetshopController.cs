using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Petshop.Models;
using Petshop.Repositories;
using Petshop.Extension;

namespace Petshop.Controllers
{
    [Route("pets")]
    public class PetshopController : ControllerBase
    {
        private readonly IPetsRepository _petsRepository;
        private readonly ICartRepository _cartRepository;
        public PetshopController(IPetsRepository petsRepository, ICartRepository cartRepository)
        {
            _petsRepository = petsRepository;
            _cartRepository = cartRepository;
        }

        [HttpGet]
        public IActionResult GetPets()
        {
            var items = _cartRepository.GetItems();
            var pets = _petsRepository.GetPets().Where(x => !items.Contains(x.Id));
            return Ok(pets);
        }

        [HttpGet]
        [Route("{petId}")]
        public IActionResult GetPetByType([FromRoute] Guid petId)
        {
            var pet = _petsRepository.GetPet(petId);
            return Ok(pet);
        }

        [HttpGet]
        [Route("type/{type}")]
        public IActionResult GetPetByType([FromRoute] String type)
        {
            var pet = _petsRepository.GetPetByType(type);
            return Ok(pet);
        }

        [HttpPost]
        public IActionResult PostPet([FromBody] PetToObjectStucture request)
        {
            var newPet = request.Map();
            var petId = _petsRepository.AddPet(newPet);
            var response = new { Id = petId };
            return Ok(response);
        }

        [HttpDelete]
        [Route("{petId}")]
        public IActionResult DetelePet([FromRoute] Guid petId)
        {
            var pet = _petsRepository.RemovePet(petId);
            var response = pet.Map();
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdatePet([FromBody] PetToObjectStucture request)
        {
            var pet = request.Map();
            _petsRepository.UpdatePet(pet);
            return Ok();
            
        }
    }
}
