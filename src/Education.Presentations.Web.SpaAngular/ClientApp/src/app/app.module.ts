import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { SchoolsComponent } from './schools/schools.component';
import { NewSchoolComponent } from './schools/new.component';
import { EditSchoolComponent } from './schools/edit.component';
import { DeleteSchoolComponent } from './schools/delete.component';
import { ClassesComponent } from './classes/classes.component';
import { NewClassComponent } from './classes/new.component';
import { EditClassComponent } from './classes/edit.component';
import { DeleteClassComponent } from './classes/delete.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SchoolsComponent,
    NewSchoolComponent,
    EditSchoolComponent,
    DeleteSchoolComponent,
    ClassesComponent,
    NewClassComponent,
    EditClassComponent,
    DeleteClassComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'schools', component: SchoolsComponent },
      { path: 'schools/new', component: NewSchoolComponent },
      { path: 'schools/edit/:id', component: EditSchoolComponent },
      { path: 'schools/delete/:id', component: DeleteSchoolComponent },
      { path: 'classes', component: ClassesComponent },
      { path: 'classes/new', component: NewClassComponent },
      { path: 'classes/edit/:id', component: EditClassComponent },
      { path: 'classes/delete/:id', component: DeleteClassComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
