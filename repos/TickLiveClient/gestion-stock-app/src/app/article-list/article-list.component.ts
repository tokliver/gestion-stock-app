import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ArticleQueryFilter } from '../models/article-query-filter';
import { ArticleService } from '../services/article.service';

@Component({
  selector: 'app-article-list',
  templateUrl: './article-list.component.html',
  styleUrls: ['./article-list.component.scss']
})
export class ArticleListComponent implements OnInit {

  articles:any;
  searchForm =new FormGroup({
    id: new FormControl(''),
    nom: new FormControl(''),
    prixVenteUnitaireMin: new FormControl(''),
    prixVenteUnitaireMax: new FormControl(''),

  });  
  constructor(private articleService: ArticleService) {
  
  }

  ngOnInit(): void {
    this.listArticle();
  }
  listArticle() {
    this.articleService.getArticles().subscribe((resultats:any)=>{
      this.articles = resultats ;
    });
  }
  deleteArticle(id:number){
    this.articleService.deleteArticleById(id).subscribe((article)=>{
      console.log("resultat delete",article);
    });
    this.listArticle();
  }

  onSearchArticles(){
    let filters = this.searchForm.value as ArticleQueryFilter
    console.log('filter ', filters);
    this.articleService.searchArticleQuery(filters)
    .subscribe((resultats)=>{
      this.articles = resultats ;
    });
  }
}
