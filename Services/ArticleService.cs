using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Data
{
    public class ArticleService: IArticleService 
    {
        private IStockData _stockData;

        public ArticleService(IStockData stockData)
        {
            _stockData = stockData;
            _stockData.LoadInventory();
        }
        public void AddArticle(Article newArticle)
        {
            StockData.inventory.Add(newArticle);
        }

        public void DeleteArticle(int id)
        {
            var article = StockData.inventory.FirstOrDefault(x => x.ArtId == id);
            StockData.inventory.Remove(article);
        }

        public List<Article> GetAllArticles()
        {
            return StockData.inventory.ToList();
        }

        public Article GetArticleById(int id)
        {
            return StockData.inventory.FirstOrDefault(x => x.ArtId == id);
        }

        public void UpdateArticle(int id, Article newArticle)
        {
            var oldArticle = StockData.inventory.FirstOrDefault(x => x.ArtId == id);
            if (oldArticle != null)
            {
                oldArticle.Name = newArticle.Name;
                oldArticle.Stock = newArticle.Stock;                
            }
        }
    }
}
