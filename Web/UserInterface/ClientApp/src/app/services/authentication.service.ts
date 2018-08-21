import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { AuthenticationModel } from "../models/authentication.model";
import { TokenService } from "../shared/services/token.service";

@Injectable({ providedIn: "root" })
export class AuthenticationService {
    private service = "Authentication";

    constructor(
        private readonly http: HttpClient,
        private readonly router: Router,
        private readonly tokenService: TokenService) { }

    authenticate(authentication: AuthenticationModel): void {
        this.http
            .post(`${this.service}/Authenticate`, authentication, { responseType: "text" })
            .subscribe((token: string) => {
                this.tokenService.set(token);
                this.router.navigate(["/home"]);
            });
    }

    isAuthenticated(): boolean {
        return this.tokenService.exists();
    }

    logout() {
        if (this.isAuthenticated()) {
            this.http.post(`${this.service}/Logout`, {}).subscribe();
        }

        this.tokenService.clear();
        this.router.navigate(["/login"]);
    }
}
