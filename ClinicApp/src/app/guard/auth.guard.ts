import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { map, take, tap } from 'rxjs/operators';
import AccountService from '../services/account.service';
import { of as observableOf, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private accountService: AccountService,
    private toastr: ToastrService,
    private router: Router){}

  canActivate(): Observable<boolean> {
    return this.accountService.currentUser$
    .pipe(
      map(user => {
        if(user) return true;
        this.toastr.error('Not today');
        return false;
      })
    )
  }
}

