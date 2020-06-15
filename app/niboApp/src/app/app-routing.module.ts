import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TransactionModule } from './transaction/transaction.module';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => TransactionModule
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
