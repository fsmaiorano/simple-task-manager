import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { environment } from "src/environments/environment";

@Component({
    selector: "app-auth",
    templateUrl: "./auth.component.html",
    styleUrls: ["./auth.component.scss"]
})
export class AuthComponent implements OnInit {
    public frmAuth: FormGroup;
    public mode: string;

    constructor(private fb: FormBuilder) {}

    ngOnInit() {
        this.mode = "signin";
        this.initForm();
    }

    initForm() {
        this.frmAuth = this.fb.group({
            name: this.fb.control("", [Validators.required]),
            email: this.fb.control("", [Validators.required, Validators.email]),
            password: this.fb.control("", [Validators.required]),
            confirmPassword: this.fb.control("", [Validators.required])
        });
    }

    toggleMode(): void {
        this.mode === "signup" ? (this.mode = "signin") : (this.mode = "signup");
    }
}
