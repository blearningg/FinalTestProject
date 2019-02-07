import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { NgForm } from '@angular/forms';
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
// import { SearchProjectComponent } from 'src/app/projects/search-project/search-project.component';
import { ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { Project } from 'src/app/Models/project.model';
import { User } from 'src/app/Models/user.model';
import { isObject } from 'util';


@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {
 // selectedProjectName: any;
  selectedUserName: any;
  modalReference: NgbModalRef;
  isParentTask: boolean = false;
  btnSubmitText: string = 'Add Task';
  constructor(public sharedService: SharedService, private modalService: NgbModal) { }

  ngOnInit() {
    if (isObject(this.sharedService.selectedTask)) {
      this.btnSubmitText = 'Update Task';
    } else {
      this.resetForm();
    }
    this.sharedService.getProject();
    this.sharedService.getParentTasks();
    this.sharedService.getUsers();
  }

open(content) {
  this.modalReference = this.modalService.open(content);
  this.modalReference.result.then((result) => {
   // this.closeResult = `Closed with: ${result}`;
  }, (reason) => {
    // this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
  });
}

selectProject(project: Project): void {
  this.sharedService.selectedTask.ProjectID = project.ProjectID;
  this.sharedService.selectedTask.ProjectName = project.ProjectName;
  this.modalReference.close();
}

selectUser(user: User): void {
  this.sharedService.selectedTask.UserID = user.UserID;
  // this.sharedService.selectedTask.
  this.sharedService.selectedTask.UserName = user.FirstName + ' ' + user.LastName;
  this.modalReference.close();
}

  resetForm(form?: NgForm) {
    if (form != null) {
      form.reset();
      this.btnSubmitText = 'Add Task';
    }

      this.sharedService.selectedTask = {
        TaskID: null,
        ParentID: null,
        ProjectID: null,
        TaskDesc: '',
        StartDate: '',
        EndDate: '',
        Priority: null,
        Status: '',
        ParentTaskDesc: '',
        ProjectName: '',
        UserID: null,
        UserName: '',
    };
  }

  priorityValueChanged(e) {
    this.sharedService.selectedTask.Priority = e;
}

   parentchecked(e) {
        if (e.target.checked) {
          this.isParentTask = true;
        } else {
          this.isParentTask = false;
        }
}

  onSubmit(form: NgForm) {
    console.log('submit call');
    if (form.value.TaskID == null) {
              if (this.isParentTask) {
                    this.sharedService.AddParentTask(form.value)
                    .subscribe(data => {
                      this.resetForm(form);
                      this.sharedService.getParentTasks();

                      alert('parent task record saved');
                    },
                    error => {
                      console.log('Error on service AddParentTask:');
                      console.log(error);
                      }
                  );
              } else {
                        this.sharedService.selectedTask.ParentID = form.value.ParentID;
                        this.sharedService.selectedTask.ProjectID = form.value.ProjectID;
                        this.sharedService.selectedTask.TaskDesc = form.value.TaskDesc;
                        this.sharedService.selectedTask.StartDate = form.value.StartDate;
                        this.sharedService.selectedTask.EndDate = form.value.EndDate;
                        this.sharedService.selectedTask.UserID = form.value.UserID;

                          this.sharedService.AddTask(this.sharedService.selectedTask)
                        .subscribe(data => {
                          this.resetForm(form);
                          alert('Record saved Successfully');
                        },
                        error => {
                          console.log('Error on service AddTask:');
                          console.log(error);
                          }
                      );
                    }
             } else {
                this.sharedService.selectedTask.TaskID = form.value.TaskID;
                this.sharedService.selectedTask.ParentID = form.value.ParentID;
                this.sharedService.selectedTask.ProjectID = form.value.ProjectID;
                this.sharedService.selectedTask.TaskDesc = form.value.TaskDesc;
                this.sharedService.selectedTask.StartDate = form.value.StartDate;
                this.sharedService.selectedTask.EndDate = form.value.EndDate;
                this.sharedService.selectedTask.UserID = form.value.UserID;
                this.sharedService.updateTask(this.sharedService.selectedTask)
                .subscribe(data => {
                  this.resetForm(form);
                  localStorage.removeItem('editTaskID');
                },
                error => {
                  console.log('Error on service updateTask:');
                  console.log(error);
                  }
              );
              }
            }

}

