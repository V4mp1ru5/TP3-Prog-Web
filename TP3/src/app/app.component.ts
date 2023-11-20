import { Component } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Voyage} from "./Voyage";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'untitled';
  voyages: Voyage[] = [];

  constructor(public http: HttpClient) { }

  public async register(){
    let user = {
      "userName": "bobybob",
      "email": "user@example.com",
      "password": "Passw0rd!",
      "passwordConfirm": "Passw0rd!"
    }
    this.http.post<any>('http://localhost:5165/api/Account/Register', user).subscribe(res => console.log(res));
  }
  public async login(){
    let user = {
      "userName": "bobybob",
      "password": "Passw0rd!"
    }
    this.http.post<any>('http://localhost:5165/api/Account/Login', user).subscribe(res =>{
      console.log(res);
        localStorage.setItem('token', res.token);
    });


  }
  public async logout(){
    localStorage.removeItem('token')
  }
  public async addVoyage(){
    let token = localStorage.getItem('token');
    let httpOptions = {
      headers: new HttpHeaders({
        'Authorization': 'Bearer ' + token
      })
    };
    let voyage = {
      id: 0,
      name: 'Cancune',
      public: false
    }

    this.http.post<any>('http://localhost:5165/api/Voyages/PostVoyage', voyage, httpOptions).subscribe(res => console.log(res));
  }
  public async getVoyages(){
    let token = localStorage.getItem('token');
    let httpOptions = {
      headers: new HttpHeaders({
        'Authorization': 'Bearer ' + token
      })
    };

    this.http.get<any>('http://localhost:5165/api/Voyages/GetVoyages', httpOptions).subscribe(res => console.log(res));

  }
}
