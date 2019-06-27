import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {
  data:any;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get('https://localhost:44368/api/values').subscribe(
      res=>{this.data=res;},
      err=>{console.log(err);}
    );
  }

}
