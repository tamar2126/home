import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { City } from '../models/city.model';

@Injectable({
  providedIn: 'root'
})
export class CitiesService {

  constructor(private _http: HttpClient) { }
  allCities():Observable<City[]>{
    return this._http.get<City[]>('api/city/getAllCity');
  }
}
