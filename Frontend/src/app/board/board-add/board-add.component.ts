import { Component, OnInit } from "@angular/core";
import { BoardAddModalService } from "./board-add-modal/board-add-modal.service";

import { take } from "rxjs/operators";
import { Board } from "src/app/shared/models/board.model";
import { BoardService } from "src/app/shared/services/board/board.service";
import { SnackbarService } from "src/app/shared/components/snackbar/snackbar";
import { AuthSingletonService } from "src/app/shared/singletons/auth/auth-singleton.service";

@Component({
    selector: "app-board-add",
    templateUrl: "./board-add.component.html",
    styleUrls: ["./board-add.component.scss"]
})
export class BoardAddComponent implements OnInit {
    public feedback: string;
    public isLoading: boolean;
    constructor(
        private boardAddModalService: BoardAddModalService,
        private boardService: BoardService,
        private snackbarService: SnackbarService,
        private authSingletonService: AuthSingletonService
    ) {}

    ngOnInit() {
        this.feedback = "";
        this.isLoading = false;
    }

    openModal(): void {
        this.boardAddModalService.openDialog();
        this.boardAddModalService.result
            .pipe(take(1))
            .subscribe((newBoard: any) => {
                this.snackbarService.open("Board created with success!");
            })
            .unsubscribe();
    }

    // addBoard(newBoard: Board): void {
    //     const user = this.authSingletonService.getUser();
    //     newBoard.userId = user.id;
    //     this.boardService
    //         .Add(newBoard)
    //         .subscribe(
    //             (res: Board) => {
    //                 this.feedback = undefined;
    //                 this.isLoading = false;
    //             },
    //             (err: Error) => {
    //                 this.snackbarService.open("err.message");
    //                 this.feedback = err.message;
    //                 this.isLoading = false;
    //             }
    //         )
    //         .unsubscribe();
    // }
}
