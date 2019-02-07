import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProjectsComponent } from './projects/projects.component';
import { UsersComponent } from './users/users.component';
import { ProjectComponent } from './projects/project/project.component';
import { ProjectlistComponent } from './projects/projectlist/projectlist.component';
import { FormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { UserComponent } from './users/user/user.component';
import { UserlistComponent } from './users/userlist/userlist.component';
import { TaskComponent } from './task/task.component';
import { TasklistComponent } from './tasklist/tasklist.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { DateValueAccessorModule } from 'angular-date-value-accessor';
import { Pipe } from '@angular/core/src/metadata/directives';

@NgModule({
  declarations: [
    AppComponent,
    ProjectsComponent,
    UsersComponent,
    ProjectComponent,
    ProjectlistComponent,
    UserComponent,
    UserlistComponent,
    TaskComponent,
    TasklistComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
   NgbModule.forRoot(),
   DateValueAccessorModule,
     ],
  providers: [
    NgbActiveModal,
    ],
  bootstrap: [AppComponent],
  entryComponents: [
  ]

})
export class AppModule { }
