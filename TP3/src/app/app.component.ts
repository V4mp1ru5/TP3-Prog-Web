import { Component } from '@angular/core';
import {HttpClient} from "@angular/common/http";
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

  public async getVoyages(){
    let voyages = this.http.get<Voyage[]>('https://localhost:7263/api/Voyages/GetVoyages');
    /*this.voyages = voyages*/
    console.log(voyages)
  }
}
