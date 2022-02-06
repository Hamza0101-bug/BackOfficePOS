import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-testerror',
  templateUrl: './testerror.component.html',
  styleUrls: ['./testerror.component.scss']
})
export class TesterrorComponent implements OnInit {
  baseurl = environment.apiUrl;
  validationerror: any={};
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  get404Error() {
    this.http.get(this.baseurl + "Product/42").subscribe((res) => {
      console.log(res);
    });
  }

  get500Error() {
    this.http.get(this.baseurl + "buggy/servererror").subscribe((res) => {
      console.log(res);
    });
  }

  get400Error() {
    this.http.get(this.baseurl + "buggy/badrequest").subscribe((res) => {
      console.log(res);
    });
  }

  get400ValifationError() {
    this.http.get(this.baseurl + "Product/4www2").subscribe({
      next: (res) => {console.log(res)},
      error: (e) =>  {this.validationerror=e.errors as []},
      complete: () => console.info('complete') 
      });
  }
}
