import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs';
import { City } from '../models/city.model';
import { Street } from '../models/street.model';
import { CitiesService } from '../services/cities.service';
import { StreetService } from '../services/street.service';

@Component({
  selector: 'app-popup',
  templateUrl: './popup.component.html',
  styleUrls: ['./popup.component.css']
})
export class PopupComponent implements OnInit {
  streetUpdate:any;
  cities: City[] = [];

  
  constructor(private _service:CitiesService ,private _router: ActivatedRoute,private _serviceStreet: StreetService) {
   }

  ngOnInit() {
    this._service.allCities().subscribe(data => 
      {
      console.log(data);
        this.cities = data
      });
    console.log(this._router);
    this._router.params.subscribe(param => 
      {
        this.streetUpdate=new Street(  param['id'],  param['name'],  param['cityId'])
      })
     
  }
  save() {
var street=new Street(this.streetUpdate.id,this.streetUpdate.name,this.streetUpdate.cityId);
    this._serviceStreet.emitChange(street);
    this.ngOnDestroy();
  }
  ngOnDestroy(){
debugger;
  }

}
