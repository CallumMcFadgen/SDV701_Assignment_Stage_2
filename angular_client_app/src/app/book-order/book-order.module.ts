import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { BookOrderPageRoutingModule } from './book-order-routing.module';

import { BookOrderPage } from './book-order.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    BookOrderPageRoutingModule
  ],
  declarations: [BookOrderPage]
})
export class BookOrderPageModule {}
