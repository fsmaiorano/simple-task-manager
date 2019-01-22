import { Component, OnInit, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from "@angular/material";
import { FormGroup, Validators, FormBuilder } from "@angular/forms";

@Component({
    selector: "app-board-add-modal",
    templateUrl: "./board-add-modal.component.html",
    styleUrls: ["./board-add-modal.component.scss"]
})
export class BoardAddModalComponent implements OnInit {
    public frmAddBoard: FormGroup;
    public modalData: any;

    constructor(
        public dialogRef: MatDialogRef<BoardAddModalComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any,
        private fb: FormBuilder
    ) {
        this.modalData = data;
    }

    ngOnInit() {
        console.log(this.modalData);
        this.initNewBoardForm();
    }

    initNewBoardForm() {
        this.frmAddBoard = this.fb.group({
            name: this.fb.control("", [Validators.required]),
            description: this.fb.control("", [Validators.required])
        });
    }

    onCancelClick(): void {
        this.dialogRef.close(undefined);
    }

    onAddClick(): void {
        this.dialogRef.close(this.frmAddBoard.value);
    }
}
