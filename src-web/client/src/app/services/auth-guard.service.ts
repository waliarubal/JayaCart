import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { UserAccountService } from './user-account.service';

@Injectable()
export class AuthGuardService implements CanActivate {

    constructor(
        private readonly _router: Router,
        private readonly _accountService: UserAccountService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        let isLoggedIn = this._accountService.IsLoggedIn;
        if (isLoggedIn)
            return true;

        this._router.navigate(['Login']);
        return false;
    }

}