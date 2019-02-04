import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { Task } from 'src/app/Models/task.model';
import { Router } from '@angular/router';
import { identifierModuleUrl } from '@angular/compiler';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { Project } from 'src/app/Models/project.model';
@Component({
  selector: 'app-tasklist',
  templateUrl: './tasklist.component.html',
  styleUrls: ['./tasklist.component.css']
})
export class TasklistComponent implements OnInit {
  selectedProjectName: any;
  modalReference: NgbModalRef;
  selectedProjectID: any = null;
  private _searchText: string;

  get serachText(): string {
    return this._searchText;
  }
  set serachText(value: string) {
    this._searchText = value;
    this.sharedService.filteredTasks = this.filterTaskts(value);
  }
  constructor(private sharedService: SharedService, private router: Router, private modalService: NgbModal) { }

  ngOnInit() {
    this.sharedService.taskList = null;
    this.sharedService.filteredTasks = null;
    this.selectedProjectID = null;
    this.sharedService.getProject();
    }

    open(content) {
      this.modalReference = this.modalService.open(content);
      this.modalReference.result.then((result) => {
      }, (reason) => {
      });
    }

    selectProject(project: Project): void {
      this.selectedProjectID = project.ProjectID;
      this.selectedProjectName = project.ProjectName;
      this.modalReference.close();
      this.sharedService.getProjectTasks(this.selectedProjectID);
    }

    filterTaskts(searchText: string) {
      return this.sharedService.taskList.filter(x => x.TaskDesc.toLowerCase().indexOf(searchText.toLowerCase()) !== -1);
    }

 EndTask(task: Task): void {
     task.Status = 'Completed';
    this.sharedService.updateTask(task)
      .subscribe(data => {
         this.sharedService.getProjectTasks(this.selectedProjectID);
      },
      error => {
        console.log('Error on service EndTask call:');
        console.log(error);
        }
    );
  }
  editTask(task: Task): void {
   // this.sharedService.selectedTask = Object.assign({}, task);
   // localStorage.removeItem('editTaskID');
  //  localStorage.setItem('editTaskID', task.TaskID.toString());
   // this.router.navigate(['add-project']);
   // console.log('selectedtask=' + task);
    this.router.navigate(['/task']);
    this.sharedService.selectedTask = Object.assign({}, task);
  }
}
