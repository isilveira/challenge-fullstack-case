import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { SchoolsListComponent } from './schools/schoolslist.component';
import { SchoolNewComponent } from './schools/schoolnew.component';
import { SchoolEditComponent } from './schools/schooledit.component';
import { SchoolDeleteComponent } from './schools/schooldelete.component';
import { ClassesListComponent } from './classes/classeslist.component';
import { ClassNewComponent } from './classes/classnew.component';
import { ClassEditComponent } from './classes/classedit.component';
import { ClassDeleteComponent } from './classes/classdelete.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SchoolsListComponent,
    SchoolNewComponent,
    SchoolEditComponent,
    SchoolDeleteComponent,
    ClassesListComponent,
    ClassNewComponent,
    ClassEditComponent,
    ClassDeleteComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'schools', component: SchoolsListComponent },
      { path: 'schools/new', component: SchoolNewComponent },
      { path: 'schools/edit/:id', component: SchoolEditComponent },
      { path: 'schools/delete/:id', component: SchoolDeleteComponent },
      { path: 'classes', component: ClassesListComponent },
      { path: 'classes/new', component: ClassNewComponent },
      { path: 'classes/edit/:id', component: ClassEditComponent },
      { path: 'classes/delete/:id', component: ClassDeleteComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
