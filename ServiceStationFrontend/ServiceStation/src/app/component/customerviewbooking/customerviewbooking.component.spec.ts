import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerviewbookingComponent } from './customerviewbooking.component';

describe('CustomerviewbookingComponent', () => {
  let component: CustomerviewbookingComponent;
  let fixture: ComponentFixture<CustomerviewbookingComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CustomerviewbookingComponent]
    });
    fixture = TestBed.createComponent(CustomerviewbookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
