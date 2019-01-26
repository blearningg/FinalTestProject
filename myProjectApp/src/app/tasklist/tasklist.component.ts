import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { Task } from 'src/app/Models/task.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tasklist',
  templateUrl: './tasklist.component.html',
  styleUrls: ['./tasklist.component.css']
})
export class TasklistComponent implements OnInit {

  constructor(private sharedService: SharedService, private router: Router) { }

  ngOnInit() {
      this.sharedService.getTasks();
    }

 EndTask(task: Task): void {
     task.Status = 'Completed';
    this.sharedService.updateTask(task)
      .subscribe(data => {
         this.sharedService.getTasks();
         // this.toastr.warning("Deleted Successfully","Employee Register");
      },
      error => {
        console.log('Error on service EndTask call:');
        console.log(error);
        }
    );
  }
  editTask(task: Task): void {
   // this.sharedService.selectedTask = Object.assign({}, task);
    localStorage.removeItem('editTaskID');
    localStorage.setItem('editTaskID', task.TaskID.toString());
   // this.router.navigate(['add-project']);
   console.log('selectedtask=' + task);
    this.router.navigate(['/task']);
  }
}
