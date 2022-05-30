using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Data
{
    public interface IArticleService
    {
        List<Article> GetAllArticles();
        Article GetArticleById(int id);
        void UpdateArticle(int id, Article newArticle);
        void DeleteArticle(int id);
        void AddArticle(Article newArticle);
    }
}
