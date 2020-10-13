import { Component, Inject } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-school-new',
  templateUrl: './new.component.html'
})
export class NewSchoolComponent {
  public response: Response<School>;
  public model: School;
  public id: string;
  public schoolForm;
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
    this.endPoint = _baseUrl + 'api/schools';
    this.router = _router;
    this.httpClient = _http;
    this.schoolForm = this._formBuilder.group({
      schoolID: 0,
      name: '',
    });
  }

  onSubmit(schoolModel) {
    console.log(schoolModel);

    this.httpClient.post<Response<School>>(this.endPoint, schoolModel).subscribe(result => {
      if (result.statusCode === 200) {
        console.log(result.message);
      }
    });

    this.schoolForm.reset();
    this.router.navigate(['schools']);
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
