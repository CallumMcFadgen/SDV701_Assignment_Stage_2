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
  selector: 'app-book',
  templateUrl: './book.page.html',
  styleUrls: ['./book.page.scss'],
})
export class BookPage implements OnInit {

  loading = null;
  book_id = null ;
  book = null;
  error = null;
  moment = moment;

  constructor(
    private http: HttpClient,
    public loadingController: LoadingController,
    private router: Router,
    private location: Location,
    private storage: Storage,
  ) {
    this.setBookID();
  }

  ngOnInit() {
    this.loadBook();
  }

  ionViewWillEnter() {
    this.checkIfRefreshNeeded();
  }

  // SET THE BOOK ID FOR API ROUTE
  async setBookID() {
    await this.storage.get('book_id').then((prBookNumber) => {
      this.book_id = prBookNumber;
      console.log(this.book_id);
    });
  }

  // SET ID TO STORAGE AND NAVIGATE TO ORDER PAGE
  goToOrderPage(prBookNumber: any) {
    this.storage.set('book_id', prBookNumber);
    this.router.navigate(['/book-order']);
  }

  // CHECK IF A REFRESH IS REQUIRED
  async checkIfRefreshNeeded() {
    await this.storage.get('refresh_page').then((refresh_flag) => {
      if (refresh_flag === true) {
        this.loadBook();
        this.storage.set('refresh_page', false);
      }
      console.log(refresh_flag);
    });
  }

  // LOAD AUTHOR OBJECT FROM API ROUTE
  async loadBook() {
    await this.presentLoadingBook();
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
  async presentLoadingBook() {
    this.loading = await this.loadingController.create({
      message: 'Loading book...'
    });
    await this.loading.present();
  }

  // API URL
  private getBook(): Observable<object> {
    const id = this.book_id;
    const dataUrl = 'http://localhost:60064/api/store/GetBook?Isbn=';
    console.log(dataUrl);
    return this.http.get(dataUrl + id);
  }

  // RETURN TO PREVIOUS PAGE
  goBack(default_href) {
    if (window.history.length > 1) {
      this.location.back();
    }
    else {
      this.router.navigateByUrl(default_href);
    }
  }

}
