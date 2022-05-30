using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Data;

namespace Warehouse.Controllers
{
    [Route("api/[controller]")]
    public class ArticlesController : Controller
    {
        private IArticleService _articleService;
        private IStockData _stockData;

        public ArticlesController(IArticleService prodcutService,
            IStockData stockData)
        {
            _stockData = stockData;
            _articleService = prodcutService;
            _stockData.LoadInventory();
        }
        // Create/Add a new article
        [HttpPost("AddArticle")]
        public IActionResult AddArticle([FromBody] Article article)
        {
            try
            {
                if (article != null)
                {
                    _articleService.AddArticle(article);
                    return Ok();
                }
                return BadRequest("Article was not added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // Get all articles
        [HttpGet("GetArticles")]
        public IActionResult GetArticles()
        {
            var allArticles = _articleService.GetAllArticles();
            return Ok(allArticles);
        }

        // Update an exesting article
        [HttpPut("UpdateArticle/{id}")]
        public IActionResult UpdateArticle(int id, [FromBody] Article article)
        {
            _articleService.UpdateArticle(id, article);
            return Ok(article);
        }

        // Delete a article
        [HttpDelete("DeleteArticle/{id}")]
        public IActionResult DeleteArticle(int id)
        {
            _articleService.DeleteArticle(id);
            return Ok();
        }

        // Get a single article
        [HttpGet("SingleArticle/{id}")]
        public IActionResult SingleArticle(int id)
        {
            var article = _articleService.GetArticleById(id);
            return Ok(article);
        }
    }
}
