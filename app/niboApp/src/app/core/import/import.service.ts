import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ImportService {

  controller = environment.API_URL + 'transaction/';

  constructor(private http: HttpClient) { }

  import(transactions: any[]){
    return this.http.post(this.controller, transactions);
  }

  get(){
    return this.http.get(this.controller);
  }

  verifyNewTransactions(transactions: any){
    return this.http.post(this.controller + 'verifyNewTransactions', transactions);
  }
}
