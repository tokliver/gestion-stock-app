import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ArticleService } from '../services/article.service';
import { StockService } from '../services/stock.service';
import { Article } from '../models/article';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-article-add',
  templateUrl: './article-add.component.html',
  styleUrls: ['./article-add.component.scss']
})
  
export class ArticleAddComponent implements OnInit {
  TVA:number = 0.2 ;
  TVA_VENTE_EMPORTER:number = 0.005 ;
  articleForm! : FormGroup ;
  stocks : any ;
  article!: Article ;
  
  constructor(private articleService: ArticleService, private stockService: StockService,private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getStocksListe();  
    this.articleForm = new FormGroup({
      id: new FormControl({value:'',disabled: true}),
      nom: new FormControl('',[Validators.required, Validators.minLength(2)]),
      prixVenteUnitaire: new FormControl('',[Validators.required, Validators.min(0)]),
      prixVenteHT: new FormControl({value:'',disabled: true}),
      prixVenteTTC: new FormControl({value:'',disabled: true}),
      articleType: new FormControl(''),
      isVenteEmporter: new FormControl(''),
      quantiteStock: new FormControl(''),
      tauxTVA: new FormControl({value:'0.2',disabled: true}),
      stockId: new FormControl('')
  
    });
  }

  onSubmit(){
   // console.log(this.articleForm.value)
    let article  : Article ={
      id:null,
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
    this.articleService.postArticle(article).subscribe((resultat) =>{
      this.article = resultat as Article ;
     this.articleForm.controls['id'].setValue(this.article.id);
    });

    this.toastr.success('Message', 'Article save with success!');

  }
 
  getStocksListe() {
    this.stockService.getStocks().subscribe((resultats)=>{
      this.stocks = resultats ;
      console.log('data stock ',resultats);
    });
  }

  get nom() {
    return this.articleForm.get('nom') ;
  }
  get prixVenteUnitaire() {
    return this.articleForm.get('prixVenteUnitaire') ;
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
  showSuccess() {
    this.toastr.success('Hello world!', 'Toastr fun!');
  }
}
