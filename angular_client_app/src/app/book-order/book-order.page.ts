import { Component, OnInit } from '@angular/core';
import { LoadingController } from '@ionic/angular';
import { Observable } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { Storage } from '@ionic/storage';
import * as moment from 'moment';

@Component({
  selector: 'app-book-order',
  templateUrl: './book-order.page.html',
  styleUrls: ['./book-order.page.scss'],
})
export class BookOrderPage implements OnInit {

  loading = null;
  book_id = null ;
  book = null;
  order = null;
  error = null;
  moment = moment;
  current_date = null;
  order_total = null;

  constructor(
    private http: HttpClient,
    public loadingController: LoadingController,
    private router: Router,
    private location: Location,
    private storage: Storage
  ) {
    this.setBookID();
  }

  ngOnInit() {
    this.loadBook();
    this.setCurrentDate();
  }

  // SET CURRENT DATE
  async setCurrentDate() {
    this.current_date = new Date();
    console.log(this.current_date);
    //this.order.Date = new Date();
  }

  // SET THE BOOK ID FOR API ROUTE
  async setBookID() {
    await this.storage.get('book_id').then((prBookNumber) => {
      this.book_id = prBookNumber;
      console.log(this.book_id);
    });
  }

    // LOAD AUTHOR OBJECT FROM API ROUTE
    async loadBook() {
      await this.presentLoadingOrder();
      this.getBook()
        .pipe(
          finalize(async () => {
            await this.loading.dismiss();
          })
        )
        .subscribe(
          data => {
            this.book = data;
            console.log(data);
          },
          err => {
            this.error = `Retriving a book failed: Status: ${err.status}, Message: ${err.statusText}`;
          }
        );
    }

    // LOADING SPINNER
    async presentLoadingOrder() {
      this.loading = await this.loadingController.create({
        message: 'Loading order...'
      });
      await this.loading.present();
    }

    // API URL
    private getBook(): Observable<object> {
      const id = this.book_id;
      const dataUrl = 'http://localhost:60064/api/store/GetBook?Isbn=' + id;
      console.log(dataUrl);
      return this.http.get(dataUrl);
    }

    goBack(default_href) {
      if (window.history.length > 1) {
        this.location.back();
      }
      else {
        this.router.navigateByUrl(default_href);
      }
    }

}
