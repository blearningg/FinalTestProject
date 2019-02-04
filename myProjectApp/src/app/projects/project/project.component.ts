import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SharedService } from 'src/app/shared.service';
import { NgForm } from '@angular/forms';
import { Project } from 'src/app/Models/project.model';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})
export class ProjectComponent implements OnInit {
  // dtStartDate: any;
  constructor(private sharedService: SharedService) {

  }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null) {
      form.reset();
    }

     // this.currentPriority = null;

      this.sharedService.selectedProject = {
      ProjectID: null,
      ProjectName: '',
      StartDate: null,
      EndDate: null,
      Priority: '',
      TotalTasks: null,
      CompletedTasks: null,
      Suspended: false,
    };
  }

  priorityValueChanged(e) {
    this.sharedService.selectedProject.Priority = e;
    console.log('priority value=', e);
}

  onSubmit(form: NgForm) {

    this.sharedService.selectedProject.ProjectName = form.value.ProjectName;
    this.sharedService.selectedProject.StartDate = form.value.StartDate;
    this.sharedService.selectedProject.EndDate = form.value.EndDate;

    if (form.value.ProjectID == null) {
          this.sharedService.AddProject(this.sharedService.selectedProject)
        .subscribe(data => {
          this.resetForm(form);
          this.sharedService.getProject();
          alert('record saved successfully');
          // this.toastr.success('New Record Added Succcessfully', 'Employee Register');
        },
        error => {
          console.log('Error on service AddProject:');
          console.log(error);
          }
      );
    } else {
      this.sharedService.selectedProject.ProjectID = form.value.ProjectID;

      this.sharedService.updateProject(this.sharedService.selectedProject)
      .subscribe(data => {
        this.resetForm(form);
        this.sharedService.getProject();
       // this.toastr.info('Record Updated Successfully!', 'Employee Register');
      },
      error => {
        console.log('Error on service updateProject:');
        console.log(error);
        }
    );
    }
  }
}


/*
  parseDate(date: string) {
        if (date) {
              return new Date(date);
        } else {
          return null;
        }

  }
set parseDate(e) {
  e = e.split('-');
  const d = new Date(Date.UTC(e[0], e[1] - 1, e[2]));
  console.log('d' + d);
  this.fmStartDate.setFullYear(d.getUTCFullYear(), d.getUTCMonth(), d.getUTCDate());
}

get parseDate () {
  console.log('this.fmStartDate' + this.fmStartDate);
  return this.fmStartDate.toISOString().substring(0, 10);
}*/
/*
get parseStartDate(): any {

 this.dtStartDate = new Date(this.sharedService.selectedProject.StartDate);
  this.fmStartDate = {year: this.dtStartDate.getFullYear,
    month: this.dtStartDate.getMonth,
    day: this.dtStartDate.getDay
   };
   console.log('sthis.fmStartDate=', this.fmStartDate);
  return this.fmStartDate;
}
set parseStartDate(value: any) {
  console.log('set date value=', value);
  this.sharedService.selectedProject.StartDate = value;
}
*/

/*
  projectformlabel: string = 'Add Project';
  empformbtn: string = 'Save';
  constructor(private formBuilder: FormBuilder, private router: Router, private sharedService: SharedService) {
  }

  addForm: FormGroup;
  btnvisibility = true;
  ngOnInit() {
    this.addForm = this.formBuilder.group({
      ProjectID: [],
      ProejctName: ['', Validators.required],
      StartDate: ['', Validators.required]
      });

    const projid = localStorage.getItem('editProjId');
    if (+projid > 0) {
      this.sharedService.getProjectById(+projid).subscribe(data => {
        this.addForm.patchValue(data);
      });
      this.btnvisibility = false;
      this.projectformlabel = 'Edit Project';
      this.empformbtn = 'Update';
    }
  }
  onSubmit() {
    console.log('Create request');
    this.sharedService.AddProject(this.addForm.value)
      .subscribe(data => {
        console.log('Create response' + data);
       // this.router.navigate(['list-emp']);
      },
      error => {
        alert(error);
      });
  }
  onUpdate() {
    console.log('Update request');
    this.sharedService.updateProject(this.addForm.value).subscribe(data => {
      console.log('update response' + data);
      // this.router.navigate(['list-emp']);
    },
      error => {
        alert(error);
      });
  }
}*/

