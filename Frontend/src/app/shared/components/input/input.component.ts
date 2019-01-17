import { Component, OnInit, Input, ContentChild, AfterContentInit } from "@angular/core";
import { NgModel, FormControlName, AbstractControl } from "@angular/forms";

@Component({
    selector: "app-input-validation-container",
    templateUrl: "./input.component.html",
    styleUrls: ["./input.component.scss"]
})
export class InputComponent implements OnInit, AfterContentInit {
    constructor() {}
    public input: any;

    @Input() errorMessage: string;
    @Input() tipMessage: string;
    @Input() customValidator = false;
    @Input() showTip = false;

    @ContentChild(NgModel) model: NgModel;
    @ContentChild(FormControlName) control: FormControlName;

    emailValidator(group: AbstractControl): { [key: string]: boolean } {
        // tslint:disable-next-line:max-line-length
        const emailPattern = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
        const email = group.get("email").value;
        const patt = new RegExp(emailPattern);
        const isValid = patt.test(email);

        if (!isValid) {
            return { emailsNotMatch: true };
        } else {
            return { emailsNotMatch: false };
        }
    }

    ngAfterContentInit() {
        this.input = this.model || this.control;

        if (this.input === undefined) {
            throw new Error("This component need to be used like directive and need ngModel or FormControlName");
        }
    }

    ngOnInit() {}

    hasError(): boolean {
        if (this.customValidator) {
            const isValid = this.emailValidator(this.input.value);

            if (!isValid) {
                this.errorMessage = "Email inválido";
            }

            return this.input.invalid && (this.input.dirty || this.input.touched);
        } else {
            return this.input.invalid && (this.input.dirty || this.input.touched);
        }
    }
}
