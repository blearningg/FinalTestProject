import { Injectable } from '@angular/core';
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

   // SERVICE_URL = 'http://localhost:50243/api/';
  SERVICE_URL = 'http://localhost:8787/api/';

 // fmStartDateModal: any;
 selectedProject: Project;
 projectList: Project[] = [];
 filteredProjects: Project[] ;
 selectedUser: User;
 userList: User[] = [];

 selectedTask: Task;
 filteredTasks: Task[];
 taskList: Task[];

  parentTaskList: Parenttask[] = [];

  constructor(private httpClient: HttpClient) { }

  getProject() {
    return this.httpClient.get(this.SERVICE_URL + '/Projects').subscribe((data: any[]) => {
     // console.log(data);
      this.projectList =  data;
      this.filteredProjects = data;
    },
    error => {
      console.log('Error on service getProject call:');
      console.log(error);
      }
    );
  }

  suspendProject(project: Project) {
    console.log('update service call');
    project.Suspended = true;
    return this.httpClient.put(this.SERVICE_URL + '/Projects/' + project.ProjectID, project);
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
getProjectTasks(projectId: number) {
  return this.httpClient.get(this.SERVICE_URL + '/Tasks?projectID=' + projectId).subscribe((data: any[]) => {
    this.taskList = data;
    this.filteredTasks = data;
  },
  error => {
    console.log('Error on service getProjectTasks call:');
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

}
