import { TestBed } from "@angular/core/testing";
import { HttpClientModule } from "@angular/common/http";
import { AuthService } from "./auth.service";

describe("AuthService", () => {
    beforeEach(() =>
        TestBed.configureTestingModule({
            imports: [HttpClientModule]
        })
    );

    it("should be created", () => {
        const service: AuthService = TestBed.get(AuthService);
        expect(service).toBeTruthy();
    });

    it("should be logged in", () => {
        const service: AuthService = TestBed.get(AuthService);
        // expect(service.signin("dotnet", "SP")).toBeTruthy();
    });
});
