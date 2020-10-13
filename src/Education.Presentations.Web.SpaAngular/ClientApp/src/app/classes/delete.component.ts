import { Component, Inject } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-class-delete',
  templateUrl: './delete.component.html'
})
export class DeleteClassComponent {
  public response: Response<Class>;
  public schoolsResponse: Response<School>;
  public id: string;
  public form;
  private httpClient: HttpClient;
  private router: Router;
  private endPoint: string;

  constructor(
    private _formBuilder: FormBuilder,
    private _route: ActivatedRoute,
    private _router: Router,
    _http: HttpClient,
    @Inject('BASE_URL') _baseUrl: string
  ) {
    this.endPoint = _baseUrl + 'api/classes';
    this.router = _router;
    this.httpClient = _http;

    this.httpClient.get<Response<School>>(_baseUrl + 'api/schools').subscribe(result => {
      this.schoolsResponse = result;
    }, error => console.error(error));

    this.form = this._formBuilder.group({
      classID: 0,
      name: '',
      classCode: '',
      schoolID: 0,
    });
    this.id = this._route.snapshot.paramMap.get('id');
    this.httpClient.get<Response<Class>>(this.endPoint + `/${this.id}`).subscribe(result => {
      this.response = result;
      this.form.setValue(this.response.data);
    }, error => console.error(error));
  }

  onSubmit(model) {
    this.httpClient.delete<Response<Class>>(this.endPoint + `/${model.classID}`).subscribe(result => {
      if (result.statusCode === 200) {
        console.log(result.message);
      }
    });

    this.form.reset();
    this.router.navigate(['classes']);
  }
}

interface Class {
  classID: number;
  name: string;
  classCode: string;
  schoolID: number;
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
  data: T;
}
