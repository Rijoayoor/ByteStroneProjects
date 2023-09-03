import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { ApiService } from '../api.service';

export const authguardNewGuard: CanActivateFn = () => {
  const router=inject(Router)
  const service=inject(ApiService);
  if (service.IsLoggedIn()) {

    return true;

  }

  else {

    router.navigate(['']);

    return false;

  }
};
