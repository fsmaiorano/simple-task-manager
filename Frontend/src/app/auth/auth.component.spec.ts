import { async, ComponentFixture, TestBed } from "@angular/core/testing";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { AuthComponent } from "./auth.component";
import { SharedModule } from "../shared/shared.module";

describe("AuthComponent", () => {
    let component: AuthComponent;
    let fixture: ComponentFixture<AuthComponent>;
    const fb: FormBuilder = new FormBuilder();
    const validators: Validators = new Validators();

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            imports: [SharedModule],
            declarations: [AuthComponent],
            providers: [{ provide: FormBuilder, useValue: fb }, { provide: Validators, useValue: validators }]
        }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(AuthComponent);
        component = fixture.componentInstance;
        component.mode = "signin";
        component.initSigninForm();
        fixture.detectChanges();
    });

    it("should create", () => {
        expect(component).toBeTruthy();
    });
});
