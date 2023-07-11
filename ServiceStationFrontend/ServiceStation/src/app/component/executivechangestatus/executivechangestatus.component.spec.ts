import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExecutivechangestatusComponent } from './executivechangestatus.component';

describe('ExecutivechangestatusComponent', () => {
  let component: ExecutivechangestatusComponent;
  let fixture: ComponentFixture<ExecutivechangestatusComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ExecutivechangestatusComponent]
    });
    fixture = TestBed.createComponent(ExecutivechangestatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
