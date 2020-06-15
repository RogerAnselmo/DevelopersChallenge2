import { Component, OnInit } from '@angular/core';

import { UploaadService } from 'src/app/core/upload/uploaad.service';
import { TableConfig } from 'src/app/shared/config/table-config';
import { ImportService } from 'src/app/core/import/import.service';

@Component({
  selector: 'app-import',
  templateUrl: './import.component.html'
})
export class ImportComponent implements OnInit {

  feedbackMessage: string;
  formData: FormData;
  settings = TableConfig.transactionConfig;
  transactions: any[];
  newTransactions: any[];
  mergedTransactions: any[];

  constructor(private uploadService: UploaadService, private importService: ImportService) { }

  ngOnInit(): void {
  }

  upload(files) {

    this.formData = new FormData();

    for (const file of files) {
      this.formData.append(file.name, file);
    }

    this.uploadService.upload(this.formData)
      .subscribe(res => {
        this.transactions = res as any[];

        if (this.transactions && this.transactions.length > 0) {
          this.importService.verifyNewTransactions(this.transactions)
            .subscribe(res => {
              this.newTransactions = res as any[];

              if (!(this.newTransactions || this.newTransactions.length === 0)) {
                this.feedbackMessage = 'Parece que não temos nenhuma transação nova por aqui';
              }
              else {
                this.feedbackMessage = 'Suas transações estão prontas para importar :)';
              }
            },
              err => console.log(err));
        }
      });
  }


  save() {
    this.importService.import(this.newTransactions)
      .subscribe(res => {
        console.log(res);
        this.feedbackMessage = 'Importamos suas transações com sucesso :D';
      }, err => {
        console.log(err);
        this.feedbackMessage = 'Oops. Algo deu errado =O';
      });
  }
}
