import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { User } from 'src/app/Models/user.model';

@Component({
  selector: 'app-userlist',
  templateUrl: './userlist.component.html',
  styleUrls: ['./userlist.component.css']
})
export class UserlistComponent implements OnInit {

  reverseSort: boolean = false;
  sortColumn: string = 'FirstName';
   private _searchText: string;

   get serachText(): string {
    return this._searchText;
  }
  set serachText(value: string) {
    this._searchText = value;
    this.sharedService.filteredUsers = this.filterUsers(value);
  }
  constructor(public sharedService: SharedService) { }

  filterUsers(searchText: string) {
    return this.sharedService.userList.filter(x => x.FirstName.toLowerCase().indexOf(searchText.toLowerCase()) !== -1);
  }

  ngOnInit() {
      this.sharedService.getUsers();
      this.sharedService.selectedTask = null;
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


  sortData(sortColumnName: string) {

    this.reverseSort =  (this.sortColumn = sortColumnName) ? !this.reverseSort : false;
    this.sortColumn = sortColumnName;
    if (sortColumnName = 'FirstName') {
      if (this.reverseSort) {
        this.sharedService.filteredUsers.sort((a, b) => b.FirstName.localeCompare(a.FirstName));
      } else {
        this.sharedService.filteredUsers.sort((a, b) => a.FirstName.localeCompare(b.FirstName));
      }
    } else if (sortColumnName = 'LastName') {
      if (this.reverseSort) {
        this.sharedService.filteredUsers.sort((a, b) => b.LastName.localeCompare(a.LastName));
      } else {
        this.sharedService.filteredUsers.sort((a, b) => a.LastName.localeCompare(b.LastName));
      }

    } else if (sortColumnName = 'EmployeeID') {
      if (this.reverseSort) {
        this.sharedService.filteredUsers.sort((a, b) => b.EmployeeID.localeCompare(a.EmployeeID));
      } else {
        this.sharedService.filteredUsers.sort((a, b) => a.EmployeeID.localeCompare(b.EmployeeID));
      }
    }

  }
}
