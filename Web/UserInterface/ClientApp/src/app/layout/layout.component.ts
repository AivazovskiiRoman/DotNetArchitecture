import { Component } from "@angular/core";
import { NavigationEnd, Router } from "@angular/router";
import { filter } from "rxjs/operators";
import { AuthenticationService } from "../services/authentication.service";

@Component({ selector: "app-layout", templateUrl: "./layout.component.html" })
export class LayoutComponent {
    isAuthenticated: boolean = false;

    constructor(
        private readonly authenticationService: AuthenticationService,
        private readonly router: Router) {
        this.SetIsAuthenticated();
    }

    private SetIsAuthenticated() {
        this.router.events
            .pipe(filter((event: any) => event instanceof NavigationEnd))
            .subscribe(() => { this.isAuthenticated = this.authenticationService.isAuthenticated(); });
    }
}
