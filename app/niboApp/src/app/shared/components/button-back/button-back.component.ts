import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-button-back',
  templateUrl: './button-back.component.html'
})
export class ButtonBackComponent implements OnInit {

  value = 'Voltar';
  constructor() { }

  ngOnInit(): void {  }

  back(){
    window.history.back();
  }

}
