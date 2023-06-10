import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExecutiveviewbookingComponent } from './executiveviewbooking.component';

describe('ExecutiveviewbookingComponent', () => {
  let component: ExecutiveviewbookingComponent;
  let fixture: ComponentFixture<ExecutiveviewbookingComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ExecutiveviewbookingComponent]
    });
    fixture = TestBed.createComponent(ExecutiveviewbookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
