import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StockService {

  apiPort:string  = environment.apiHost ;

  constructor(private http : HttpClient) { 

  }
  getStocks() {

    return this.http.get(`${this.apiPort}api/stock`);
  }
}
