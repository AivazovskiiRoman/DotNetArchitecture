import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { SharedModule } from "../shared/shared.module";
import { FooterComponent } from "./footer/footer.component";
import { HeaderComponent } from "./header/header.component";
import { LayoutComponent } from "./layout.component";
import { MainComponent } from "./main/main.component";
import { NavComponent } from "./nav/nav.component";

@NgModule({
    declarations: [
        FooterComponent,
        HeaderComponent,
        LayoutComponent,
        MainComponent,
        NavComponent
    ],
    exports: [LayoutComponent],
    imports: [RouterModule, SharedModule]
})
export class LayoutModule { }
