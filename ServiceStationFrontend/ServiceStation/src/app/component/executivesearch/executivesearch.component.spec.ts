import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExecutivesearchComponent } from './executivesearch.component';

describe('ExecutivesearchComponent', () => {
  let component: ExecutivesearchComponent;
  let fixture: ComponentFixture<ExecutivesearchComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ExecutivesearchComponent]
    });
    fixture = TestBed.createComponent(ExecutivesearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
