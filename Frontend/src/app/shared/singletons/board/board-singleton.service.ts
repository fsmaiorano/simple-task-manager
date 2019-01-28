import { Injectable } from "@angular/core";

// Models
import { Board } from "../../models/board.model";

@Injectable({
    providedIn: "root"
})
export class BoardSingletonService {
    private selectedBoard: Board = undefined;

    constructor() {}

    selectBoard(board: Board): void {
        this.selectedBoard = board;
    }

    getSelectedBoard(): Board {
        return this.selectedBoard;
    }
}
