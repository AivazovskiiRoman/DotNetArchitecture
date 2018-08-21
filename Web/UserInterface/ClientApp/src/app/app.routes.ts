import { Routes } from "@angular/router";
import { AuthenticationGuard } from "./shared/guards/authentication.guard";
import { LoginComponent } from "./views/login/login.component";

export const routes: Routes = [
    { path: "form", loadChildren: "./views/form/form.module#FormModule", canActivate: [AuthenticationGuard] },
    { path: "home", loadChildren: "./views/home/home.module#HomeModule", canActivate: [AuthenticationGuard] },
    { path: "service", loadChildren: "./views/service/service.module#ServiceModule", canActivate: [AuthenticationGuard] },
    { path: "upload", loadChildren: "./views/upload/upload.module#UploadModule", canActivate: [AuthenticationGuard] },
    { path: "validation", loadChildren: "./views/validation/validation.module#ValidationModule", canActivate: [AuthenticationGuard] },

    { path: "login", component: LoginComponent },
    { path: "", redirectTo: "login", pathMatch: "full" },
    { path: "**", redirectTo: "login" }
];
