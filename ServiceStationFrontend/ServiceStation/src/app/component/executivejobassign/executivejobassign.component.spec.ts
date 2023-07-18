import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExecutivejobassignComponent } from './executivejobassign.component';

describe('ExecutivejobassignComponent', () => {
  let component: ExecutivejobassignComponent;
  let fixture: ComponentFixture<ExecutivejobassignComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ExecutivejobassignComponent]
    });
    fixture = TestBed.createComponent(ExecutivejobassignComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
