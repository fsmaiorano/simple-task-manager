import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";

// Material
import { MatToolbarModule, MatIconModule, MatButtonModule, MatFormFieldModule, MatInputModule, MatIcon } from "@angular/material";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        MatToolbarModule,
        MatIconModule,
        MatButtonModule,
        HttpClientModule,
        MatFormFieldModule,
        FormsModule,
        ReactiveFormsModule,
        MatInputModule,
        BrowserAnimationsModule,
        MatIcon
    ],
    exports: [
        MatToolbarModule,
        MatIconModule,
        MatButtonModule,
        HttpClientModule,
        MatFormFieldModule,
        FormsModule,
        ReactiveFormsModule,
        MatInputModule,
        BrowserAnimationsModule,
        MatIcon
    ]
})
export class SharedModule {}
