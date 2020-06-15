import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ViewComponent } from './view/view.component';
import { ImportComponent } from './import/import.component';


const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },
  {
    path: 'view',
    component: ViewComponent
  },
  {
    path: 'import',
    component: ImportComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TransactionRoutingModule { }
