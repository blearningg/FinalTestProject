import { Injectable } from '@angular/core';
// import { Response, Headers, RequestOptions, RequestMethod } from '@angular/common/http';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Project } from 'src/app/Models/project.model';
import { User } from 'src/app/Models/user.model';
import { Task } from 'src/app/Models/task.model';
import { Parenttask } from 'src/app/Models/parenttask.model';




@Injectable({
  providedIn: 'root'
})
export class SharedService {

  SERVICE_URL = 'http://localhost:50243/api/';

 // projects: Observable<Project[]>;
 // newProject: Observable<Project>;
 selectedProject: Project;
 projectList: any[] = [];

 selectedUser: User;
 userList: User[] = [];

 selectedTask: Task;
 taskList: Task[] = [];


  parentTaskList: Parenttask[] = [];

  constructor(private httpClient: HttpClient) { }

  getProject() {
    // return this.http.get<Project[]>(this.SERVICE_URL + '/Projects');
    return this.httpClient.get(this.SERVICE_URL + '/Projects').subscribe((data: any[]) => {
      console.log(data);
      this.projectList = data;
    },
    error => {
      console.log('Error on service getProject call:');
      console.log(error);
      }
    );
  }

  deleteProject(id: number) {
   return this.httpClient.delete<Project[]>(this.SERVICE_URL + '/Projects/' + id);
  }
  AddProject(project: Project) {
  return this.httpClient.post(this.SERVICE_URL + '/Projects', project);
  }

  updateProject(project: Project) {
    return this.httpClient.put(this.SERVICE_URL + '/Projects/' + project.ProjectID, project);
  }

/*User service function */
  getUsers() {
    return this.httpClient.get(this.SERVICE_URL + '/Users').subscribe((data: any[]) => {
      console.log(data);
      this.userList = data;
    },
    error => {
      console.log('Error on service getUsers call:');
      console.log(error);
      }
    );
  }

  deleteUser(id: number) {
   return this.httpClient.delete<User[]>(this.SERVICE_URL + '/Users/' + id);
  }

  AddUser(user: User) {
  return this.httpClient.post(this.SERVICE_URL + '/Users', user);
  }

  updateUser(user: User) {
    return this.httpClient.put(this.SERVICE_URL + '/Users/' + user.UserID, user);
  }


/*Task service function */
getTasks() {
  return this.httpClient.get(this.SERVICE_URL + '/Tasks').subscribe((data: any[]) => {
     console.log('data received');
    this.taskList = data;
  },
  error => {
    console.log('Error on service getTasks call:');
    console.log(error);
    }
  );
}

AddTask(task: Task) {
  console.log('calling service addtask.');
return this.httpClient.post(this.SERVICE_URL + '/Tasks', task);
}

updateTask(task: Task) {
  return this.httpClient.put(this.SERVICE_URL + '/Tasks/' + task.TaskID, task);
}

/*Parent Task service function */
getParentTasks() {
  return this.httpClient.get(this.SERVICE_URL + '/ParentTasks').subscribe((data: any[]) => {
   // console.log(data);
  this.parentTaskList = data;
  },
  error => {
    console.log('Error on service getParentTasks call:');
    console.log(error);
    }
  );
}

getTaskById(id: number) {
  return this.httpClient.get<Task>(this.SERVICE_URL + '/Tasks/' + id).subscribe((data: any) => {
  this.selectedTask = data;
  },
  error => {
    console.log('Error on service getTaskById call:');
    console.log(error);
    }
  );
}

AddParentTask(task: Parenttask) {
return this.httpClient.post(this.SERVICE_URL + '/ParentTasks', task);
}

  /*
AddProject(proj: Project) {

const headers = new HttpHeaders().set('content-type', 'application/json');
const body = {
                  PID: proj.ProjectID, PName: proj.ProjectName, StartDate: proj.StartDate, EndDate: proj.EndDate, Priority: proj.Priority
           };

return this.http.post<Project>(this.SERVICE_URL + '/Projects', proj, {headers});

}

EditProject(proj: Project) {
  const params = new HttpParams().set('ID', proj.ProjectID);
  const headers = new HttpHeaders().set('content-type', 'application/json');
  // body = {
  //  PID: proj.ProjectID, PName: proj.ProjectName, StartDate: proj.StartDate, EndDate: proj.EndDate, Priority: proj.Priority
  //         };
      return this.http.put<Project>(this.SERVICE_URL + '/Projects/' + proj.ProjectID, proj, {headers, params});

}




DeleteProject(proj:Project) {
  const params = new HttpParams().set('ID', proj.ID);
const headers = new HttpHeaders().set('content-type', 'application/json');
let body = {
                  Fname:proj.Fname, Lname:proj.Lname,Email:proj.Email,ID:proj.ID
           };
      return this.http.delete<Project>(SERVICE_URL + '/Projects/' + proj.ID);

}
*/
}
