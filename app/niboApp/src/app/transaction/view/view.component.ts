import { Component, OnInit } from '@angular/core';

import { ImportService } from 'src/app/core/import/import.service';
import { pipe } from 'rxjs';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html'
})
export class ViewComponent implements OnInit {

  transactions: any[];
  feedbackMessage: string;
  constructor(private importService: ImportService) { }

  ngOnInit(): void {
    this.feedbackMessage = 'Estamos carregando suas transações...';
    this.importService.get()
      .pipe(finalize(() => this.feedbackMessage = 'Essas são suas transações importadas até agora :)'))
      .subscribe(res => this.transactions = res as any[],
        err => {
          console.log(err);
          this.feedbackMessage = 'ops, tivemos um problema ao carregar seus dados :´(';
        });
  }

}
