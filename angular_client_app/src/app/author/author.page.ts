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
  selector: 'app-author',
  templateUrl: './author.page.html',
  styleUrls: ['./author.page.scss'],
})
export class AuthorPage implements OnInit {

  loading = null;
  author_id = null ;
  author = null;
  error = null;
  moment = moment;

  constructor(
    private http: HttpClient,
    public loadingController: LoadingController,
    private router: Router,
    private location: Location,
    private storage: Storage
    ) {
      this.setAuthorID();
    }

  ngOnInit() {
    this.loadAuthor();
  }

  // SET THE AUTHOR ID FOR API ROUTE
  async setAuthorID() {
    await this.storage.get('author_id').then((prAuthorName) => {
      this.author_id = prAuthorName;
    });
  }

    // SET ID TO STORAGE AND NAVIGATE TO BOOK PAGE
  goToBookPage(prBookNumber: any) {
    this.storage.set('book_id', prBookNumber);
    this.router.navigate(['/book']);
  }

  // LOAD AUTHOR OBJECT FROM API ROUTE
  async loadAuthor() {
    await this.presentLoadingAuthor();
    this.getAuthor()
      .pipe(
        finalize(async () => {
          await this.loading.dismiss();
        })
      )
      .subscribe(
        data => {
          this.author = data;
          console.log(data);
        },
        err => {
          this.error = `Retriving an author failed: Status: ${err.status}, Message: ${err.statusText}`;
        }
      );
  }

  // LOADING SPINNER
  async presentLoadingAuthor() {
    this.loading = await this.loadingController.create({
      message: 'Loading author...'
    });
    await this.loading.present();
  }

  // API URL
  private getAuthor(): Observable<object> {
    const id = this.author_id;
    const dataUrl = 'http://localhost:60064/api/store/GetAuthor?Name=' + id;
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
