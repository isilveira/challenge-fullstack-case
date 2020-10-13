import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-classes',
  templateUrl: './classes.component.html'
})
export class ClassesComponent {
  public response: Response<Class>;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Response<Class>>(baseUrl + 'api/classes').subscribe(result => {
      this.response = result;
    }, error => console.error(error));
  }
}

interface Class {
  schoolID: number;
  name: string;
}

interface Response<T> {
  statusCode: number;
  internalCode: number;
  resultCount: number;
  message: string;
  data: T[];
}
