import { Component, OnInit, Input } from '@angular/core';

import { TableConfig } from 'src/app/shared/config/table-config';

@Component({
  selector: 'app-transaction-list',
  templateUrl: './transaction-list.component.html'
})
export class TransactionListComponent implements OnInit {

  @Input() transactions: any[];
  settings = TableConfig.transactionConfig;

  constructor() { }

  ngOnInit(): void {
  }

}
