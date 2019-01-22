import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { User } from 'src/app/Models/user.model';

@Component({
  selector: 'app-userlist',
  templateUrl: './userlist.component.html',
  styleUrls: ['./userlist.component.css']
})
export class UserlistComponent implements OnInit {

  constructor(private sharedService: SharedService) { }

  ngOnInit() {
      this.sharedService.getUsers();
    }

 deleteUser(id: number): void {
    this.sharedService.deleteUser(id)
      .subscribe(data => {
         this.sharedService.getUsers();
      },
      error => {
        console.log('Error on service deleteUser call:');
        console.log(error);
        }
    );
  }

  editUser(user: User): void {
    this.sharedService.selectedUser = Object.assign({}, user);

  }
}
