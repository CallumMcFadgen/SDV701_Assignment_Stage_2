import { Component, OnInit } from '@angular/core';
import { LoadingController } from '@ionic/angular';
import { Observable } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-author',
  templateUrl: './author.page.html',
  styleUrls: ['./author.page.scss'],
})
export class AuthorPage implements OnInit {

  loading: any;
  author: object ;
  error: string;

  constructor(
    private http: HttpClient,
    public loadingController: LoadingController,
    private router: Router,
    private location: Location) {
    this.author = [];
    this.error = '';
  }

  ngOnInit() {
    this.loadAuthor();
  }

  async loadAuthor() {
    // start loading spinner
    await this.presentLoadingAuthors();
    // GET request
    this.getAuthors()
      .pipe(
        finalize(async () => {
          // stop loading spinner on finish
          await this.loading.dismiss();
        })
      )
      .subscribe(
        data => {
          // Set the data to an array
          this.author = data;
          console.log(data);
        },
        err => {
          // Set error information to display in the template
          this.error = `Retriving author failed: Status: ${err.status}, Message: ${err.statusText}`;
        }
      );
  }

  // loading spinner
  async presentLoadingAuthors() {
    this.loading = await this.loadingController.create({
      message: 'Loading author...'
    });
    await this.loading.present();
  }

  // API URL
  private getAuthors(): Observable<object> {
    const dataUrl = 'http://localhost:60064/api/store/GetAuthorNames/';
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
