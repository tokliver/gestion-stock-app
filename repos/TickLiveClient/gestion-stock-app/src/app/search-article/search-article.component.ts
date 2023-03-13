import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { Article } from '../models/article';
import { ArticleService } from '../services/article.service';

@Component({
  selector: 'app-search-article',
  templateUrl: './search-article.component.html',
  styleUrls: ['./search-article.component.scss']
})
export class SearchArticleComponent implements OnInit {

    articles:any;
    searchForm = new FormGroup({
      id: new FormControl(),
      nom: new FormControl(),
      prixUnitaireMin: new FormControl(),
      prixUnitaireMax: new FormControl(),
  
    })
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
  
    onSubmit(){
      console.log(this.searchForm.value,'********')
    }
  }
  