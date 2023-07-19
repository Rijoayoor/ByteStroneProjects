import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TechnicianstatusupdateComponent } from './technicianstatusupdate.component';

describe('TechnicianstatusupdateComponent', () => {
  let component: TechnicianstatusupdateComponent;
  let fixture: ComponentFixture<TechnicianstatusupdateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TechnicianstatusupdateComponent]
    });
    fixture = TestBed.createComponent(TechnicianstatusupdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
