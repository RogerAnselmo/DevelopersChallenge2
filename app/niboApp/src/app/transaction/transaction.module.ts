import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Ng2SmartTableModule } from 'ng2-smart-table';

import { TransactionRoutingModule } from './transaction-routing.module';
import { HomeComponent } from './home/home.component';
import { ImportComponent } from './import/import.component';
import { ViewComponent } from './view/view.component';
import { SharedModule } from '../shared/shared.module';
import { TransactionListComponent } from './transaction-list/transaction-list.component';


@NgModule({
  declarations: [HomeComponent, ImportComponent, ViewComponent, TransactionListComponent],
  imports: [
    CommonModule,
    Ng2SmartTableModule,
    TransactionRoutingModule,
    SharedModule
  ]
})
export class TransactionModule { }
