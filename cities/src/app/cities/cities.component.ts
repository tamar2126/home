import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { City } from '../models/city.model';
import { CitiesService } from '../services/cities.service';

@Component({
  selector: 'app-cities',
  templateUrl: './cities.component.html',
  styleUrls: ['./cities.component.css']
})
export class CitiesComponent implements OnInit {
  cities: City[] = [];

  constructor(private _service: CitiesService,private _router: Router) { }

  ngOnInit(){
    this._service.allCities().subscribe(data => this.cities = data);
  
  }
  selectCity(cityId:number):void {
    this._router.navigate(['streets',cityId]);
  }

}
