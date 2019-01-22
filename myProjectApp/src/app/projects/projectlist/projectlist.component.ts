import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
// import { Project } from 'src/app/Models/project';
import { Router } from '@angular/router';
import { filter } from 'rxjs/operators';
import { Project } from 'src/app/Models/project.model';
@Component({
  selector: 'app-projectlist',
  templateUrl: './projectlist.component.html',
  styleUrls: ['./projectlist.component.css']
})
export class ProjectlistComponent implements OnInit {

  // projects: Project[];
  // projects: any[] = [];
  // constructor(private sharedService: SharedService, private router: Router, ) { }
  constructor(private sharedService: SharedService) { }

  ngOnInit() {
      this.sharedService.getProject();
    }
 deleteProject(id: number): void {
    this.sharedService.deleteProject(id)
      .subscribe(data => {
         this.sharedService.getProject();
         // this.toastr.warning("Deleted Successfully","Employee Register");
      },
      error => {
        console.log('Error on service deleteProject call:');
        console.log(error);
        }
    );
  }
  editProject(project: Project): void {
    this.sharedService.selectedProject = Object.assign({}, project);
   // localStorage.removeItem('editProjId');
   // localStorage.setItem('editProjId', project.ProjectID.toString());
    // this.router.navigate(['add-project']);
  }
}
