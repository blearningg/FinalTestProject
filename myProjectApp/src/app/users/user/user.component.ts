import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor(public sharedService: SharedService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null) {
      form.reset();
    }

      this.sharedService.selectedUser = {
      UserID: null,
      FirstName: '',
      LastName: '',
      EmployeeID: null,
      ProjectID: null,
      TaskID: null
    };
  }


  onSubmit(form: NgForm) {

    if (form.value.UserID == null) {
          this.sharedService.AddUser(form.value)
        .subscribe(data => {
          this.resetForm(form);
          this.sharedService.getUsers();
        },
        error => {
          console.log('Error on service AddUser:');
          console.log(error);
          }
      );
    } else {
      this.sharedService.updateUser(form.value)
      .subscribe(data => {
        this.resetForm(form);
        this.sharedService.getUsers();
      },
      error => {
        console.log('Error on service updateUser:');
        console.log(error);
        }
    );
    }
  }
}


