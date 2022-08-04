import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Street } from '../models/street.model';

@Injectable({
  providedIn: 'root'
})
export class StreetService {

  constructor(private _http: HttpClient) { }
  getAllStreetsByCityId(cityID:number):Observable<Street[]> {
    return this._http.get<Street[]>('api/street/getAllStreetsByCityId/'+cityID);
  }
  deleteStreet(streetId:number):Observable<void> {
    return this._http.delete<void>('api/street/deleteStreet'+streetId);
  }
  updateStreet(street:Street):Observable<Street> {
    return this._http.put<Street>('api/street/updateStreet',street);
  }
  addStreet(street:Street):Observable<Street> {
    return this._http.post<Street>('api/street/addStreet',street);
  }
  private emitChangeSource = new Subject<Street>();
  changeEmitted$ = this.emitChangeSource.asObservable();
  emitChange(change: Street) {
    this.emitChangeSource.next(change);
}
}
