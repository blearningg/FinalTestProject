import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { NgForm } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { SearchProjectComponent } from 'src/app/projects/search-project/search-project.component';


@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {

  isParentTask: boolean = false;
  constructor(private sharedService: SharedService, private modalService: NgbModal) { }

  ngOnInit() {
    this.sharedService.getProject();
    this.sharedService.getParentTasks();
    this.sharedService.getUsers();
    // console.log('onload task id' + this.sharedService.selectedTask.TaskID);
    // if (this.sharedService.selectedTask.TaskID != null) {
      this.resetForm();
    // }
  }
  open() {
     const modalRef = this.modalService.open(SearchProjectComponent);
     modalRef.componentInstance.title = 'Search Project';
    // this.modalService.open(ModalProjectComponent).result.then((result) => {
    //  this.sharedService.selectedTask.ProjectName = `Project: ${result}`;
    // });
  }
 /*open() {
    this.modalService.open(ModalProjectComponent).result.then((result) => {
      this.sharedService.selectedTask.ProjectName = `Project: ${result}`;
    });

  }
   open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.sharedService.selectedTask.ProjectName = `Project: ${result}`;
    }, (reason) => {
      // this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }
*/

  resetForm(form?: NgForm) {
    if (form != null) {
      form.reset();
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
      console.log('adding task.');
              this.sharedService.selectedTask.ParentID = form.value.ParentID;
              this.sharedService.selectedTask.ProjectID = form.value.ProjectID;
              this.sharedService.selectedTask.TaskDesc = form.value.TaskDesc;
              this.sharedService.selectedTask.StartDate = form.value.StartDate;
              this.sharedService.selectedTask.EndDate = form.value.EndDate;
              this.sharedService.selectedTask.Priority = form.value.Priority;
              this.sharedService.selectedTask.UserID = form.value.UserID;

              if (form.value.TaskID == null) {
                console.log('calling addtask.');
                    this.sharedService.AddTask(this.sharedService.selectedTask)
                  .subscribe(data => {
                    this.resetForm(form);
                    alert('record saved');
                    // this.sharedService.getProject();
                    // this.toastr.success('New Record Added Succcessfully', 'Employee Register');
                  },
                  error => {
                    console.log('Error on service AddTask:');
                    console.log(error);
                    }
                );
              } else {
                this.sharedService.selectedTask.TaskID = form.value.TaskID;

                this.sharedService.updateTask(this.sharedService.selectedTask)
                .subscribe(data => {
                  this.resetForm(form);
                // this.toastr.info('Record Updated Successfully!', 'Employee Register');
                },
                error => {
                  console.log('Error on service updateTask:');
                  console.log(error);
                  }
              );
              }
            }
  }
}
