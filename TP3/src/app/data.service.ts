import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Voyage} from "./Voyage";
import {lastValueFrom} from "rxjs";
import {Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class DataService {

  loggedIn: boolean = false;
  currentUser: String = "";
  userVoyages: Voyage[] = [];
  publicVoyages: Voyage[] = [];
  constructor(public http: HttpClient, private router: Router) { }



  public async register(username: String, email: String, password: String, passwordConf: String){
    let user = {
      "userName": username,
      "email": email,
      "password": password,
      "passwordConfirm": passwordConf
    }
    this.http.post<any>('http://localhost:5165/api/Account/Register', user).subscribe(res => console.log(res));
    await this.router.navigate(['/login']);
  }
  public async login(username: String, password: String){
    let user = {
      "userName": username,
      "password": password
    }
    this.http.post<any>('http://localhost:5165/api/Account/Login', user).subscribe(res =>{
      console.log(res);
      localStorage.setItem('token', res.token);
    });
    this.loggedIn = true;
    this.currentUser = username;
    await this.getVoyages();
    await this.router.navigate(['/voyages']);
  }
  public async logout(){
    localStorage.removeItem('token')
    this.loggedIn = false;
    this.currentUser = '';
    await this.getVoyages();
    await this.router.navigate(['/voyages']);
  }
  public async addVoyage(name: String, publicVoyage: Boolean){

    let voyage = {
      id: 0,
      name: name,
      public: publicVoyage
    }

    this.http.post<any>('http://localhost:5165/api/Voyages/PostVoyage', voyage).subscribe(res => console.log(res));
    await this.getVoyages();
  }

  public async share(voyageId: number, shareName: String){

    let voyage = {
      voyageId: voyageId,
      userName: shareName
    }

    this.http.put<any>('http://localhost:5165/api/Voyages/PutVoyage', voyage).subscribe(res => console.log(res));
    await this.getVoyages();
  }

  public async deleteVoyage(voyageId: number){
    let id = {
      id: voyageId
    }

    this.http.post<any>('http://localhost:5165/api/Voyages/DeleteVoyage', id).subscribe(res => console.log(res));
  }
  public async getVoyages(){
    this.publicVoyages = [];
    this.userVoyages = [];
    this.http.get<any>('http://localhost:5165/api/Voyages/GetVoyages').subscribe(res => console.log(res));
    let res = await lastValueFrom(this.http.get<any>('http://localhost:5165/api/Voyages/GetVoyages'));
    console.log(res);
    for (let i = 0; i < res.length; i++) {

      if(this.currentUser == ''){
        if(res[i].public == true){
          this.publicVoyages.push(new Voyage(res[i].id, res[i].name, res[i].public));
        }
      }
      else{
        for (let e = 0; e < res[i].userNames.length; e++)
        if(res[i].userNames[e] == this.currentUser){
          this.userVoyages.push(new Voyage(res[i].id, res[i].name, res[i].public));
        }
      }
    }
  }}
