import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { SchoolsComponent } from './schools/schools.component';
import { NewSchoolComponent } from './schools/new.component';
import { EditSchoolComponent } from './schools/edit.component';
import { DeleteSchoolComponent } from './schools/delete.component';
import { ClassesComponent } from './classes/classes.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    SchoolsComponent,
    NewSchoolComponent,
    EditSchoolComponent,
    DeleteSchoolComponent,
    ClassesComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'schools', component: SchoolsComponent },
      { path: 'schools/new', component: NewSchoolComponent },
      { path: 'schools/edit/:id', component: EditSchoolComponent },
      { path: 'schools/delete/:id', component: DeleteSchoolComponent },
      { path: 'classes', component: ClassesComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
