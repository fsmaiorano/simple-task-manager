import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { DragAndDropComponent } from "./drag-and-drop/drag-and-drop.component";
import { SharedModule } from "../shared/shared.module";
import { TaskComponent } from "./task.component";
import { DragDropModule } from "@angular/cdk/drag-drop";

@NgModule({
    declarations: [TaskComponent, DragAndDropComponent],
    exports: [TaskComponent, DragAndDropComponent, DragDropModule],
    imports: [CommonModule, SharedModule, DragDropModule]
})
export class TaskModule {}
