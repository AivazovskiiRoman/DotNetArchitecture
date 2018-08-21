import { Component } from "@angular/core";
import { AuthenticationModel } from "../../models/authentication.model";
import { AuthenticationService } from "../../services/authentication.service";

@Component({ selector: "app-login", templateUrl: "./login.component.html" })
export class LoginComponent {
    authentication = new AuthenticationModel();

    constructor(private readonly authenticationService: AuthenticationService) {
        this.authentication.login = "admin";
        this.authentication.password = "admin";
    }

    ngSubmit() {
        this.authenticationService.authenticate(this.authentication);
    }
}
