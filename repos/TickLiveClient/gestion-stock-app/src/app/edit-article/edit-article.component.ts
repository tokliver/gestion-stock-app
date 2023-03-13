import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Article } from '../models/article';
import { ArticleService } from '../services/article.service';
import { StockService } from '../services/stock.service';

@Component({
  selector: 'app-edit-article',
  templateUrl: './edit-article.component.html',
  styleUrls: ['./edit-article.component.scss']
})
export class EditArticleComponent implements OnInit {
  TVA:number = 0.2 ;
  TVA_VENTE_EMPORTER:number = 0.055 ;
  article!: Article ;
  stocks : any ;
  articleForm! : FormGroup ;
  id : any;
  constructor(private route: ActivatedRoute, private articleService: ArticleService,private stockService: StockService) { }
  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    this.id = Number(routeParams.get('ArticleId'));
    this.getStocksListe();
   this.getArticlebyId();
  }

  getArticlebyId(){

    this.articleService.findArticleById(this.id).subscribe((resultat =>{
      this.article = resultat as Article;
      this.articleForm = new FormGroup({
        id: new FormControl({value:this.article.id,disabled: true}),
        nom: new FormControl(this.article.nom),
        prixVenteUnitaire: new FormControl(this.article.prixVenteUnitaire),
        prixVenteHT: new FormControl({value:this.article.prixVenteHT,disabled: true}),
        prixVenteTTC: new FormControl({value:this.article.prixVenteTTC,disabled: true}),
        articleType: new FormControl(this.article.articleType),
        isVenteEmporter: new FormControl(this.article.isVenteEmporter),
        quantiteStock: new FormControl(this.article.quantiteStock),
        tauxTVA: new FormControl({value:this.article.tauxTVA,disabled: true}),
        stockId: new FormControl(this.article.stockId)
    
      });
    }))
  }
  onSubmit(){
    // console.log(this.articleForm.value)
     let article  : Article ={
       id:this.articleForm.get('id')?.value,
       nom : this.articleForm.get('nom')?.value,
       prixVenteUnitaire: this.articleForm.get('prixVenteUnitaire')?.value,
       prixVenteHT : this.articleForm.get('prixVenteHT')?.value,
       prixVenteTTC : this.articleForm.get('prixVenteTTC')?.value,
       articleType : this.articleForm.get('articleType')?.value,
       isVenteEmporter : this.articleForm.get('isVenteEmporter')?.value,
       quantiteStock : this.articleForm.get('quantiteStock')?.value,
       tauxTVA : this.articleForm.get('tauxTVA')?.value,
       stockId : this.articleForm.get('stockId')?.value,
     };
     this.articleService.putArticle(article).subscribe((resultat) =>{
       this.article = resultat as Article ;
      /*this.articleForm.controls['id'].setValue({
       id: this.article
     });*/
     });
   }
   getStocksListe() {
    this.stockService.getStocks().subscribe((resultats)=>{
      this.stocks = resultats ;
    });
  }
  onCheckChange() {
    this.onValueChange();
  }

  onValueChange() {
   let  isVenteEmporter= this.articleForm.get('isVenteEmporter')?.value ;
   let  prixVenteHT = this.articleForm.get('prixVenteUnitaire')?.value * this.articleForm.get('quantiteStock')?.value ;
   console.log('calcul prixVenteHT',prixVenteHT)
   this.articleForm.controls['prixVenteHT'].setValue(prixVenteHT);
    let tva = isVenteEmporter ? this.TVA_VENTE_EMPORTER  : this.TVA ;
    this.articleForm.controls['prixVenteTTC'].setValue(prixVenteHT + tva*prixVenteHT);
    if(isVenteEmporter) {
      this.articleForm.controls['tauxTVA'].setValue(this.TVA_VENTE_EMPORTER);
    }else{
      this.articleForm.controls['tauxTVA'].setValue(this.TVA);
    }
  }
}
