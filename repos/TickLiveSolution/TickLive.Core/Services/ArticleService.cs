using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TickLive.Core.Entities;
using TickLive.Core.Interfaces;
using TickLive.Core.QueryFilters;

namespace TickLive.Core.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async  Task<bool> DeleteArticle(int id)
        {
            return await _unitOfWork.ArticleRepository.DeleteAsync(id);
        }

        public async Task<Article> GetArticle(int id)
        {
            return await _unitOfWork.ArticleRepository.SelectAsync(id);
        }

        public  async Task<IEnumerable<Article>> GetArticles()
        {
            return  await _unitOfWork.ArticleRepository.SelectAsync();
        }

        public async Task<IEnumerable<Article>> GetArticles(ArticleQueryFilter filters)
        {
            var articles =await  _unitOfWork.ArticleRepository.SelectAsync();
            if (filters.Id != null)
            {
                articles = articles.Where(x => x.Id == filters.Id);
            }
            if (filters.Nom != null)
            {
                articles = articles.Where(x => x.Nom.ToLower().Contains(filters.Nom.ToLower()));
            }
            if (filters.PrixVenteUnitaireMin != null  && filters.PrixVenteUnitaireMax !=null)
            {
                articles = articles.Where(x =>  filters.PrixVenteUnitaireMin <= x.PrixVenteUnitaire  && x.PrixVenteUnitaire <= filters.PrixVenteUnitaireMax);
            }
            return articles;
        }

        public  async Task<IEnumerable<Article>> GetArticlesByNom(string nom)
        {
            IEnumerable<Article> articles = await  GetArticles();

            return articles.Where(x => x.Nom.Contains(nom));

        }


        public async Task<Article> InsertArticle(Article article)
        {
            return await _unitOfWork.ArticleRepository.InsertAsync(article);
        }

        public async Task<Article> UpdateArticle(Article article)
        {
            return await _unitOfWork.ArticleRepository.UpdateAsync(article);
        }
    }
}
