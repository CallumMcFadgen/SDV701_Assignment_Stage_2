import { Component, OnInit } from '@angular/core';
import { LoadingController } from '@ionic/angular';
import { Observable } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-main',
  templateUrl: './main.page.html',
  styleUrls: ['./main.page.scss'],
})
export class MainPage implements OnInit {

  loading: any;
  authors: object ;
  error: string;

  constructor(
    private http: HttpClient,
    public loadingController: LoadingController) {
    this.authors = [];
    this.error = '';
  }

  ngOnInit() {
      this.loadAuthors();
    }

    async loadAuthors() {
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
            this.authors = data;
            console.log(data);
          },
          err => {
            // Set error information to display in the template
            this.error = `Retriving authors failed: Status: ${err.status}, Message: ${err.statusText}`;
          }
        );
    }

    // loading spinner
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
