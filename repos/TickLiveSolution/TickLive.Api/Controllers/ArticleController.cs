using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TickLive.Core.DTOs;
using TickLive.Core.Entities;
using TickLive.Core.Interfaces;
using TickLive.Core.QueryFilters;

namespace TickLive.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {

        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;


        public ArticleController(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetActicles()
        {
            var articles = await _articleService.GetArticles();
            var articlesDto = _mapper.Map<List<ArticleDto>>(articles);

            return Ok(articlesDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle(int id)
        {
            var article = await _articleService.GetArticle(id);
            var articleDto = _mapper.Map<ArticleDto>(article);
            return Ok(articleDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostArticle(ArticleDto articleDto)
        {
            var article = _mapper.Map<Article>(articleDto);
            var articleResponse = await  _articleService.InsertArticle(article);
            var articleDtoResponse = _mapper.Map<ArticleDto>(articleResponse);

            return Ok(articleDtoResponse);

        }

        [HttpPut]
        public async Task<IActionResult> PutArticle(ArticleDto articleDto)
        {
            var article = _mapper.Map<Article>(articleDto);
            var articleResponse = await _articleService.UpdateArticle(article);
            var articleDtoResponse = _mapper.Map<ArticleDto>(articleResponse);

            return Ok(articleDtoResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var isDeleteArticle = await _articleService.DeleteArticle(id);
            return Ok(isDeleteArticle);
        }

        [HttpPost("search")]
        public async Task<IActionResult> GetArticles(ArticleQueryFilter filters)

        {
            var articles = await _articleService.GetArticles(filters);
            var articlesDto = _mapper.Map<List<ArticleDto>>(articles);

            return Ok(articlesDto);
        }
    }
}
