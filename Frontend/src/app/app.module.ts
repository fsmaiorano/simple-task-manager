import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppRoutingModule } from "./app-routing.module";

// Components

import { AppComponent } from "./app.component";
import { AuthComponent } from "./auth/auth.component";

// Modules
import { SharedModule } from "./shared/shared.module";

@NgModule({
    declarations: [AppComponent, AuthComponent],
    imports: [BrowserModule, AppRoutingModule, SharedModule],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule {}
