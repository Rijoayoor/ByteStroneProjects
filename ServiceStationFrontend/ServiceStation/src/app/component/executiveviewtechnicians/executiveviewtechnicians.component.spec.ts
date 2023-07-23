import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExecutiveviewtechniciansComponent } from './executiveviewtechnicians.component';

describe('ExecutiveviewtechniciansComponent', () => {
  let component: ExecutiveviewtechniciansComponent;
  let fixture: ComponentFixture<ExecutiveviewtechniciansComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ExecutiveviewtechniciansComponent]
    });
    fixture = TestBed.createComponent(ExecutiveviewtechniciansComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
