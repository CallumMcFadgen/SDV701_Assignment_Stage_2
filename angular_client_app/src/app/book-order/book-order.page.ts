import { Component, OnInit } from '@angular/core';
import { LoadingController, AlertController } from '@ionic/angular';
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
  order = {
    Name: null,
    Email: null,
    OrderDate: null,
    Price: null,
    Quantity: null,
    Isbn: null
  };
  error = null;
  moment = moment;
  order_total = null;
  current_date = null;

  constructor(
    private http: HttpClient,
    public loadingController: LoadingController,
    public alertController: AlertController,
    private router: Router,
    private location: Location,
    private storage: Storage
  ) {
    this.setBookID();
  }

  ngOnInit() {
    this.loadBook();
    this.setInitialOrderParams();
  }

  // VALIDATE INPUT AND POST ORDER
  postBookOrder() {
    if (this.isNameValid() === true && this.isEmailValid() === true)
    {
      this.addPerson();
    }
  }

  // MULTIPLY PRICE BY QUANTIY
  setOrderTotal() {
    this.order_total = (this.book?.Price * this.order.Quantity);
  }

  // CHECK NAME IS VALID
  isNameValid() {
    if (!(!this.order.Name || this.order.Name.trim().length === 0))
    {
      return true;
    }
    this.presentAlert('Error', 'Empty name field', 'Please enter a name into the name field');
    return false;
  }

  // CHECK EMAIL IS VALID
  isEmailValid() {
    if (!(!this.order.Email || this.order.Email.trim().length === 0))
    {
      return true;
    }
    this.presentAlert('Error', 'Empty email field', 'Please enter an email address into the email field');
    return false;
  }

  // GET ORDER TOTAL
  setBookID() {
    this.storage.get('book_id').then((prBookNumber) => {
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
          this.setInitialOrderParams();
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

  // API GET BOOK URL
  private getBook(): Observable<object> {
    const id = this.book_id;
    const dataUrl = 'http://localhost:60064/api/store/GetBook?Isbn=';
    console.log(dataUrl);
    return this.http.get(dataUrl + id);
  }

  // POST ORDER OBJECT ON API ROUTE
  async addPerson() {
    await this.presentPostingOrder();
    this.postOrder()
      .pipe(
        finalize(async () => {
          await this.loading.dismiss();
        })
      )
      .subscribe(
        data => {
          console.log(data);
        },
        err => {
          this.error = `Posting an order failed: Status: ${err.status}, Message: ${err.statusText}`;
        }
      );
  }

  // POSTING SPINNER
  async presentPostingOrder() {
    this.loading = await this.loadingController.create({
      message: 'Creating order...'
    });
    await this.loading.present();
  }

  // API POST ORDER URL
   private postOrder(): Observable<object> {
    const headers = { 'content-type': 'application/json'};
    const body = this.order;
    const dataUrl = 'http://localhost:60064/api/store/PostOrder';
    console.log('post body data' + body);
    return this.http.post(dataUrl , body);
  }

  // SET PARAMS FOR PASSING TO THE API ROUTE FOR ORDER UPDATE
  async setInitialOrderParams() {
    this.current_date = new Date().toDateString();
    this.order.Quantity = 1;
    this.order_total = this.book?.Price;
    this.order.OrderDate = new Date();
    this.order.Price = this.book?.Price;
    this.order.Isbn = this.book?.Isbn;
    console.log(this.order);
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

  // PRESENT AN ALERT POP UP
  async presentAlert(prHeader, prSubHeader, prMessage) {
    const alert = await this.alertController.create({
      header: prHeader,
      subHeader: prSubHeader,
      message: prMessage,
      buttons: ['OK']
    });
    await alert.present();
  }

}
