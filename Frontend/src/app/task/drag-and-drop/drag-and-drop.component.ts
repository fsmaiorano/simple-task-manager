import { Component, OnInit, Input, EventEmitter, Output } from "@angular/core";
import { CdkDragDrop, moveItemInArray, transferArrayItem } from "@angular/cdk/drag-drop";

// Models
import { Board } from "src/app/shared/models/board.model";
import { Task } from "src/app/shared/models/task.model";
import { TaskService } from "src/app/shared/services/task/task.service";
import { Status } from "src/app/shared/models/enums/status.enum";
import { SnackbarService } from "src/app/shared/components/snackbar/snackbar";
import { DragAndDrop } from "./drag-and-drop.model";

@Component({
    selector: "app-drag-and-drop",
    templateUrl: "./drag-and-drop.component.html",
    styleUrls: ["./drag-and-drop.component.scss"]
})
export class DragAndDropComponent implements OnInit {
    @Input() tasks: DragAndDrop;
    public selectedTask: Task;
    @Output() doDisableTask: EventEmitter<Task> = new EventEmitter();
    constructor(private taskService: TaskService, private snackbarService: SnackbarService) {}

    ngOnInit() {}

    selectTask(task: Task): void {
        this.selectedTask = task;
    }

    emitDisableTask(task: Task): void {
        this.doDisableTask.emit(task);
    }

    drop(event: CdkDragDrop<string[]>, newStatus: number) {
        if (event.previousContainer === event.container) {
            moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
        } else {
            transferArrayItem(event.previousContainer.data, event.container.data, event.previousIndex, event.currentIndex);
        }

        this.selectedTask.status = newStatus;
        this.taskService.updateStatus(this.selectedTask).subscribe(
            (task: Task) => {},
            (err: Error) => {
                if (err) {
                    this.snackbarService.open(err.message);
                }
            }
        );
    }
}
