import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Article } from '../models/article';
import { ArticleQueryFilter } from '../models/article-query-filter';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {

   apiPort:string  = environment.apiHost ;

  constructor(private http : HttpClient) { 

  }
      

  getArticles() {

    return this.http.get(`${this.apiPort}api/article`);
  }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
    })
  };
  postArticle(article:Article) {
    return this.http.post(`${this.apiPort}api/article`, article, this.httpOptions)
  }

  findArticleById(id:number){
    return   this.http.get(`${this.apiPort}api/article/${id}`);
  }

  putArticle(article:Article) {
    return this.http.put(`${this.apiPort}api/article`, article, this.httpOptions)
  }

  deleteArticleById(id:number) {
    return this.http.delete(`${this.apiPort}api/article/${id}`);
  }

  searchArticleQuery(filters: ArticleQueryFilter){
    return this.http.post(`${this.apiPort}api/article/search`,filters,this.httpOptions)
  }
}
