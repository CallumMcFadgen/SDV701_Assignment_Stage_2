import { Component, OnInit } from '@angular/core';
import { LoadingController } from '@ionic/angular';
import { Observable } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Storage } from '@ionic/storage';

@Component({
  selector: 'app-main',
  templateUrl: './main.page.html',
  styleUrls: ['./main.page.scss'],
})
export class MainPage implements OnInit {

  loading = null;
  authors = null ;
  error = null;

  constructor(
    private http: HttpClient,
    public loadingController: LoadingController,
    private router: Router,
    private storage: Storage
    ) {}

  ngOnInit() {
      this.loadAuthors();
    }

    // SET ID TO STORAGE AND NAVIGATE TO AUTHOR PAGE
  goToAuthorPage(prAuthorName: any) {
    this.storage.set('author_id', prAuthorName);
    this.router.navigate(['/author']);
  }

  // LOAD AUTHOR NAMES FROM API ROUTE
    async loadAuthors() {
      await this.presentLoadingAuthors();
      this.getAuthors()
        .pipe(
          finalize(async () => {
            await this.loading.dismiss();
          })
        )
        .subscribe(
          data => {
            this.authors = data;
            console.log(data);
          },
          err => {
            this.error = `Retriving authors failed: Status: ${err.status}, Message: ${err.statusText}`;
          }
        );
    }

    // LOADING SPINNER
    async presentLoadingAuthors() {
      this.loading = await this.loadingController.create({
        message: 'Loading authors...'
      });
      await this.loading.present();
    }

    // API URL
    private getAuthors(): Observable<object> {
      const dataUrl = 'http://localhost:60064/api/store/GetAuthorNames/';
      console.log(dataUrl);
      return this.http.get(dataUrl);
    }

}
