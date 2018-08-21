import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from "@angular/router";
import { TokenService } from "../services/token.service";

@Injectable()
export class AuthenticationGuard implements CanActivate {
    constructor(
        private readonly router: Router,
        private readonly tokenService: TokenService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (this.tokenService.exists()) { return true; }
        this.router.navigate(["/login"]);
        return false;
    }
}
