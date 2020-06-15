import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './components/header/header.component';
import { ButtonBackComponent } from './components/button-back/button-back.component';

@NgModule({
  declarations: [
    HeaderComponent,
    ButtonBackComponent],
  imports: [
    CommonModule
  ],
  exports: [
    HeaderComponent,
    ButtonBackComponent
  ]
})
export class SharedModule { }
