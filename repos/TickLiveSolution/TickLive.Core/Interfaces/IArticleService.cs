using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TickLive.Core.Entities;
using TickLive.Core.QueryFilters;

namespace TickLive.Core.Interfaces
{
    public interface IArticleService
    {
        Task<Article> GetArticle(int id);

        Task<Article> InsertArticle(Article article);

        Task<bool> DeleteArticle(int id);

        Task<Article> UpdateArticle(Article article);

        Task<IEnumerable<Article>> GetArticlesByNom(string nom);

        Task<IEnumerable<Article>> GetArticles();
        Task<IEnumerable<Article>> GetArticles(ArticleQueryFilter query);


    }
}
