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
    this.http.post<any>('https://localhost:7263/api/Account/Register', user).subscribe(res => console.log(res));
  }
  public async login(){
    let user = {
      "userName": "bobybob",
      "password": "Passw0rd!"
    }
    this.http.post<any>('https://localhost:7263/api/Account/Login', user).subscribe(res =>{
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
        'Content-Type': 'application/json',
        'Authorisation': 'Bearer ' + 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..-9nJjoSqdu7IQ'
      })
    };
    let voyage = {
      id: 0,
      name: 'Cancune'
    }

    this.http.post<any>('https://localhost:7263/api/Voyages/PostVoyage', voyage, httpOptions).subscribe(res => console.log(res));
  }
  public async getVoyages(){
    let token = localStorage.getItem('token');
    let httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorisation': 'Bearer ' + token
      })
    };

    this.http.get<any>('https://localhost:7263/api/Voyages/GetVoyages', httpOptions).subscribe(res => console.log(res));

  }
}
