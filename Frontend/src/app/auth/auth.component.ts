import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";

@Component({
    selector: "app-auth",
    templateUrl: "./auth.component.html",
    styleUrls: ["./auth.component.scss"]
})
export class AuthComponent implements OnInit {
    public frmAuth: FormGroup;
    // public emailPattern = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;

    constructor(private fb: FormBuilder) {}

    ngOnInit() {
        this.initForm();
    }

    initForm() {
        this.frmAuth = this.fb.group({
            email: this.fb.control("", [Validators.required, Validators.pattern(this.emailPattern)]),
            password: this.fb.control("", [Validators.required])
        });
    }
}
