﻿using AutoMapper;
using MatchS.Core.Entity.DTO.AdvertDTO;
using MatchS.Core.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MatchS.Core.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IAdvertService _advertService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService,  IMapper mapper, IAdvertService advertService)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _advertService = advertService;
        }

        [HttpGet("GetAdvertsByCategory")]
        public async Task<IActionResult> GetAdvertsByCategory(int id)
        {
            var adverts = await _advertService.GetFilterListByNoTrackAsync(x => x.CategoryId == id);
            var advertsDTO = _mapper.Map<List<ListAdvertDTO>>(adverts);
            return Ok(advertsDTO);
        }

  
    }
}
