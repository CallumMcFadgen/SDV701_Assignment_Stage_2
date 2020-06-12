import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { BookOrderPage } from './book-order.page';

describe('BookOrderPage', () => {
  let component: BookOrderPage;
  let fixture: ComponentFixture<BookOrderPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BookOrderPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(BookOrderPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
