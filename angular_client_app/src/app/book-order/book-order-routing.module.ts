import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { BookOrderPage } from './book-order.page';

const routes: Routes = [
  {
    path: '',
    component: BookOrderPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class BookOrderPageRoutingModule {}
