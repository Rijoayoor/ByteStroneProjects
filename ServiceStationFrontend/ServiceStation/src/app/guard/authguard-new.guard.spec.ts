import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { authguardNewGuard } from './authguard-new.guard';

describe('authguardNewGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => authguardNewGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
