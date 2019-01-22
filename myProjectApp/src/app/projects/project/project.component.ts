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

  // currentPriority: any;

  constructor(private sharedService: SharedService) { }

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
      StartDate: '',
      EndDate: '',
      Priority: ''
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
    console.log('savepriority value=' + this.sharedService.selectedProject.Priority);

    if (form.value.ProjectID == null) {
          this.sharedService.AddProject(this.sharedService.selectedProject)
        .subscribe(data => {
          this.resetForm(form);
          this.sharedService.getProject();
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

