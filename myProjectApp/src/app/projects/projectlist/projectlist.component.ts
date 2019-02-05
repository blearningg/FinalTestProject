import { Component, OnInit, Host } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
// import { Project } from 'src/app/Models/project';
import { Router } from '@angular/router';
import { filter } from 'rxjs/operators';
// import { map } from 'rxjs/add/operator/map';
import { Project } from 'src/app/Models/project.model';
import { Pipe, PipeTransform } from '@angular/core';
// import { OrderByPipe } from 'src/app/orderBy.pipe';
@Component({
  selector: 'app-projectlist',
  templateUrl: './projectlist.component.html',
  styleUrls: ['./projectlist.component.css']
})
export class ProjectlistComponent implements OnInit {

  reverseSort: boolean = false;
  sortColumn: string = 'StartDate';
  dtStartDate: any;
   private _searchText: string;

   get serachText(): string {
    return this._searchText;
  }
  set serachText(value: string) {
    this._searchText = value;
    this.sharedService.filteredProjects = this.filterProjects(value);
  }


  // projects: any[] = [];
  // constructor(private sharedService: SharedService, private router: Router, ) { }
  constructor(private sharedService: SharedService) { }

  filterProjects(searchText: string) {
    return this.sharedService.projectList.filter(x => x.ProjectName.toLowerCase().indexOf(searchText.toLowerCase()) !== -1);
  }

  ngOnInit() {
      this.sharedService.getProject();
    }
    suspendProject(project: Project): void {
      project.Suspended = true;
      this.sharedService.updateProject(project)
      .subscribe(data => {
        console.log('success');
         this.sharedService.getProject();
      },
      error => {
        console.log('Error on suspendProject ');
        console.log(error);
        }
    );
  }
  editProject(project: Project): void {
        this.sharedService.selectedProject = Object.assign({}, project);
/*
        this.dtStartDate = new Date(this.sharedService.selectedProject.StartDate);
        this.sharedService.fmStartDateModal = {year: this.dtStartDate.getFullYear,
          month: this.dtStartDate.getMonth,
          day: this.dtStartDate.getDay
        };
        */
      //  this.sharedService.selectedProject.StartDate = new Date(this.sharedService.selectedProject.StartDate.getFullYear +
      //    '/' + this.sharedService.selectedProject.StartDate.getMonth + '/' + this.sharedService.selectedProject.StartDate.getDay);
  }

  sortData(sortColumnName: string) {

    this.reverseSort =  (this.sortColumn = sortColumnName) ? !this.reverseSort : false;
    this.sortColumn = sortColumnName;
    if (sortColumnName = 'StartDate') {
      if (this.reverseSort) {
        this.sharedService.filteredProjects.sort((a, b) => b.StartDate.localeCompare(a.StartDate));
      } else {
        this.sharedService.filteredProjects.sort((a, b) => a.StartDate.localeCompare(b.StartDate));
      }
    } else if (sortColumnName = 'EndDate') {
      if (this.reverseSort) {
        this.sharedService.filteredProjects.sort((a, b) => b.EndDate.localeCompare(a.EndDate));
      } else {
        this.sharedService.filteredProjects.sort((a, b) => a.EndDate.localeCompare(b.EndDate));
      }

    } else if (sortColumnName = 'Priority') {
      if (this.reverseSort) {
        this.sharedService.filteredProjects.sort((a, b) => b.Priority.localeCompare(a.Priority));
      } else {
        this.sharedService.filteredProjects.sort((a, b) => a.Priority.localeCompare(b.Priority));
      }
    }

  }
}


