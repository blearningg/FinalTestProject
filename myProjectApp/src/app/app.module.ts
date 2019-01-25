import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProjectsComponent } from './projects/projects.component';
import { UsersComponent } from './users/users.component';
import { ProjectComponent } from './projects/project/project.component';
import { ProjectlistComponent } from './projects/projectlist/projectlist.component';
import { MenuComponent } from './menu/menu.component';
import { FormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { UserComponent } from './users/user/user.component';
import { UserlistComponent } from './users/userlist/userlist.component';
import { TaskComponent } from './task/task.component';
import { TasklistComponent } from './tasklist/tasklist.component';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from './modal/modal.component';
import { SearchProjectComponent } from './projects/search-project/search-project.component';
import { SearchUserComponent } from './users/search-user/search-user.component';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent,
    ProjectsComponent,
    UsersComponent,
    ProjectComponent,
    ProjectlistComponent,
    MenuComponent,
    UserComponent,
    UserlistComponent,
    TaskComponent,
    TasklistComponent,
    ModalComponent,
    SearchProjectComponent,
    SearchUserComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgbModule.forRoot(),
  ],
  providers: [
    NgbActiveModal,
    ],
  bootstrap: [AppComponent],
  entryComponents: [
    SearchProjectComponent,
    SearchUserComponent
  ]

})
export class AppModule { }
