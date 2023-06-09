import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerbookingComponent } from './customerbooking.component';

describe('CustomerbookingComponent', () => {
  let component: CustomerbookingComponent;
  let fixture: ComponentFixture<CustomerbookingComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CustomerbookingComponent]
    });
    fixture = TestBed.createComponent(CustomerbookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
