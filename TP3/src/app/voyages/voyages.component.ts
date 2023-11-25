import {Component, OnInit} from '@angular/core';
import {DataService} from "../data.service";

@Component({
  selector: 'app-voyages',
  templateUrl: './voyages.component.html',
  styleUrls: ['./voyages.component.css']
})
export class VoyagesComponent implements OnInit{

  constructor(
    public data: DataService
  ) { }

  async ngOnInit () {
    await this.data.getVoyages();
  }
}
