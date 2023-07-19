import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TechnicianviewjobComponent } from './technicianviewjob.component';

describe('TechnicianviewjobComponent', () => {
  let component: TechnicianviewjobComponent;
  let fixture: ComponentFixture<TechnicianviewjobComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TechnicianviewjobComponent]
    });
    fixture = TestBed.createComponent(TechnicianviewjobComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
