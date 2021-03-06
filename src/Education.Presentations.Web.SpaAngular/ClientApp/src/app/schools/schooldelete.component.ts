import { Component, Inject } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-school-delete',
  templateUrl: './schooldelete.component.html'
})
export class SchoolDeleteComponent {
  public response: Response<School>;
  public model: School;
  public id: string;
  public schoolForm;
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
    this.endPoint = _baseUrl + 'api/schools';
    this.router = _router;
    this.httpClient = _http;
    this.schoolForm = this._formBuilder.group({
      schoolID: 0,
      name: '',
    });
    this.id = this._route.snapshot.paramMap.get('id');
    this.httpClient.get<Response<School>>(this.endPoint + `/${this.id}`).subscribe(result => {
      this.response = result;
      this.schoolForm.setValue(this.response.data);
    }, error => console.error(error));
    this.validations = {};
  }

  onSubmit(schoolModel) {
    this.httpClient.delete<Response<School>>(this.endPoint + `/${schoolModel.schoolID}`).subscribe(result => {
      console.log(result.message);
      this.messageClass = 'success';
      this.messageTitle = 'Sucesso!';
      this.message = result.message;
      setTimeout(() => {
        this.router.navigate(['schools']);
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
