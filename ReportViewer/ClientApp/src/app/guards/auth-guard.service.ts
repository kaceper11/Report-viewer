import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable()
export class AuthGuard implements CanActivate {

  constructor( private router: Router) {

  }

  canActivate() {
    const helper = new JwtHelperService();
    var token = localStorage.getItem("jwt");

    if (token && !helper.isTokenExpired(token)) {
      return true;
    }
    this.router.navigate(["login"]);
    return false;
  }
}
