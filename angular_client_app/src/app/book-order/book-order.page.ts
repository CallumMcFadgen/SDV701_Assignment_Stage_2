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
  error = null;
  moment = moment;
  order_total = null;
  current_date = null;
  max_char = null;

  book_update = {
    Quantity: null,
    Isbn: null,
    EditDate: null
  }

  order = {
    Name: null,
    Email: null,
    OrderDate: null,
    Price: null,
    Quantity: null,
    Isbn: null
  };

  constructor(
    private http: HttpClient,
    public loadingController: LoadingController,
    public alertController: AlertController,
    private router: Router,
    private location: Location,
    private storage: Storage,
  ) {
    this.setBookID();
  }

  ngOnInit() {
    this.loadBook();
    this.setInitialOrderParams();
  }

  // GET BOOK ID
  setBookID() {
    this.storage.get('book_id').then((prBookNumber) => {
      this.book_id = prBookNumber;
      console.log(this.book_id);
    });
  }

  // MULTIPLY PRICE BY QUANTIY
  setOrderTotal() {
    this.order_total = (this.book?.Price * this.order.Quantity);
  }

  // VALIDATE USER INPUT AND SHOW CONFIRMATION POP UP
  postBookOrder() {
    if (this.isNameValid() === true && this.isEmailValid() === true)
    {
      this.presentConfirmation(
        'Please confirm',
        'Order details',
        '<b>Title : </b>' + this.book.Title + '<br />' +
        '<b>Price : $</b>' + this.order.Price + '<br />' +
        '<b>Quantity : </b>' + this.order.Quantity + '<br /> <br />' +
        '<b>Order Total : $</b>' + this.order_total);
    }
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

  // POST BOOK_UPDATE OBJECT ON API ROUTE
  async updateBook() {
    await this.presentPutBook();
    this.putBook()
      .pipe(
        finalize(async () => {
          await this.loading.dismiss();
        })
      )
      .subscribe(
        data => {
          console.log(data);
          if (data.toString() === 'Success' )
          {
            this.addOrder();
          }
          else{
            this.presentError('Error', 'Order failed', 'There seems to be a problem with your order <br /> <br /> Please check the quantity available and contact our team if the problem persists ');
          }
        },
        err => {
          this.error = `Posting an order failed: Status: ${err.status}, Message: ${err.statusText}`;
        }
      );
  }

  // PUTING SPINNER
  async presentPutBook() {
    this.loading = await this.loadingController.create({
      message: 'Dispatching order...'
    });
    await this.loading.present();
  }

  // API PUT BOOK URL
  private putBook(): Observable<object> {
    const body = this.book_update;
    const dataUrl = 'http://localhost:60064/api/store/PutBookQuantity';
    console.log('put body data'.toString() + body);
    return this.http.put(dataUrl , body);
  }

  // POST ORDER OBJECT ON API ROUTE
  async addOrder() {
    await this.presentPostingOrder();
    this.postOrder()
      .pipe(
        finalize(async () => {
          await this.loading.dismiss();
          await this.presentSuccess('Success', 'Order dispatched', 'Thank you for you order <br /> <br /> Our team will be in contact soon to arrange payment and delivery <br /> <br /> Thank you for supporting our authors');
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
      message: 'Processing...'
    });
    await this.loading.present();
  }

  // API POST ORDER URL
   private postOrder(): Observable<object> {
    const body = this.order;
    const dataUrl = 'http://localhost:60064/api/store/PostOrder';
    console.log('post body data'.toString() + body);
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
    this.max_char = this.book?.Quantity;
    console.log(this.order);
  }

  async setBookUpdateParams() {
    this.book_update.Quantity = this.order.Quantity;
    this.book_update.EditDate = new Date();
    this.book_update.Isbn = this.book.Isbn;
    console.log(this.book_update);
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

  // PRESENT GENERIC ALERT POP UP
  async presentAlert(prHeader, prSubHeader, prMessage) {
    const alert = await this.alertController.create({
      header: prHeader,
      subHeader: prSubHeader,
      message: prMessage,
      buttons: ['OK']
    });
    await alert.present();
  }

  // PRESENT A ORDER CONFIRMATION POP UP
  async presentConfirmation(prHeader, prSubHeader, prMessage) {
    const alert = await this.alertController.create({
      header: prHeader,
      subHeader: prSubHeader,
      message: prMessage,
      buttons: [
        {
          text: 'Cancel',
          role: 'cancel'
        },
        {
          text: 'OK',
          handler: () => {
            this.setBookUpdateParams();
            this.updateBook();
          }
        }
      ],
    });
    await alert.present();
  }

  // PRESENT AN ORDER SUCCESS POP UP
  async presentSuccess(prHeader, prSubHeader, prMessage) {
    const alert = await this.alertController.create({
      header: prHeader,
      subHeader: prSubHeader,
      message: prMessage,
      buttons: [
        {
          text: 'OK',
          handler: () => {
            this.storage.set('refresh_page', true);
            this.goBack('/book');
          }
        }
      ],
    });
    await alert.present();
  }

  // PRESENT AN ORDER ERROR POP UP
  async presentError(prHeader, prSubHeader, prMessage) {
    const alert = await this.alertController.create({
      header: prHeader,
      subHeader: prSubHeader,
      message: prMessage,
      buttons: [
        {
          text: 'OK',
          handler: () => {
            this.goBack('/book');
          }
        }
      ],
    });
    await alert.present();
  }

}
