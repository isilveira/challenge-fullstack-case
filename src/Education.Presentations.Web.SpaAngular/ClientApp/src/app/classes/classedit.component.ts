import { Component, Inject } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-class-edit',
  templateUrl: './classedit.component.html'
})
export class ClassEditComponent {
  public response: Response<Class>;
  public schoolsResponse: Response<School>;
  public id: string;
  public form;
  public message: string;
  public messageClass: string;
  public messageTitle: string;
  private httpClient: HttpClient;
  private router: Router;
  private endPoint: string;
  private validations;

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
    this.validations = {};
  }

  onSubmit(model) {
    this.httpClient.put<Response<Class>>(this.endPoint + `/${model.classID}`, model).subscribe(result => {
      console.log(result.message);
      this.messageClass = 'success';
      this.messageTitle = 'Sucesso!';
      this.message = result.message;
      setTimeout(() => {
        this.router.navigate(['classes']);
      }, 2500);
    }, error => {
      this.messageClass = 'danger';
      this.messageTitle = 'Erro!';
      this.message = error.error.message;
      if (error.error.data) {
        this.validations = error.error.data;
      }
    });
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
