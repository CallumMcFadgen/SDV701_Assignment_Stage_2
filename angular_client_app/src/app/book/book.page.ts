import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-book',
  templateUrl: './book.page.html',
  styleUrls: ['./book.page.scss'],
})
export class BookPage implements OnInit {

  constructor(
    private router: Router,
    private location: Location
  ) { }

  ngOnInit() {
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
