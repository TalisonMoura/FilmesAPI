﻿using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using FilmesAPI.Models;

namespace FilmesAPI.Controllers
{
    public class AddressController : ControllerBase
    {
        public MovieContext _context;
        public IMapper _mapper;

        public AddressController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IEnumerable GetAllAdresses()
        {
            var allAdresses = _context.Adresses.ToList();
            var response = _mapper.Map<List<ReadAdressDTO>>(allAdresses);
            return response;
        }

        [HttpGet("{id}")]
        public IActionResult GetAddressById(int id)
        {
            var addresId = _context.Adresses.FirstOrDefault(x => x.Id == id);
            if (addresId != null)
            {
                ReadAdressDTO readAdressDTO = _mapper.Map<ReadAdressDTO>(addresId);
                return Ok(readAdressDTO);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult CreateAddress([FromBody] CreateAddressDTO addressDTO)
        {
            Address address = _mapper.Map<Address>(addressDTO);
            _context.Adresses.Add(address);
            _context.SaveChanges();
            var created = CreatedAtAction((nameof(GetAddressById)), new { Id = address.Id }, addressDTO);
            return created;
        }

        [HttpPut]
        public IActionResult UpdateAddress(int id, [FromBody] UpdateAddressDTO addressDTO)
        {
            var addressId = GetAddressById(id);
            if (addressId == null) return NotFound();
            _mapper.Map(addressDTO, addressId);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete]
        public IActionResult DeleteAddress(int id)
        {
            var addressId = GetAddressById(id);
            if (addressId == null) return NotFound();
            _context.Remove(addressId);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
