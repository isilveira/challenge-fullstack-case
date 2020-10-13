import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-schools',
  templateUrl: './schools.component.html'
})
export class SchoolsComponent {
  public response: Response<School>;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Response<School>>(baseUrl + 'api/schools').subscribe(result => {
      this.response = result;
    }, error => console.error(error));
  }
}

interface School {
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
