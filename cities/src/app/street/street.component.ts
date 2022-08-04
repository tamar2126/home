import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { City } from '../models/city.model';
import { Street } from '../models/street.model';
import { CitiesService } from '../services/cities.service';
import { StreetService } from '../services/street.service';

@Component({
  selector: 'app-street',
  templateUrl: './street.component.html',
  styleUrls: ['./street.component.css']
})
export class StreetComponent implements OnInit {

  constructor(private _routerA: ActivatedRoute,private _router:Router,private _service: StreetService,_serviseC:CitiesService) {
    
    _service.changeEmitted$.subscribe(data => {
this.saveStreet(data);
   });
   _serviseC.allCities().subscribe(data => {this.cities=data});
  }
  street:Street[]=[];
  cityID:number=0;
  copyStreet:Street[]=[];
  cities:City[]=[];
  ngOnInit(){
    this._routerA.params.subscribe(param =>
      this._service.getAllStreetsByCityId(param['city']).subscribe(data=>{
        this.street=data;
        this.copyStreet=data;
      }
  
        ));
  
  }
  search(val:any){
    this.copyStreet=this.street.filter(s=>s.name.startsWith(val));
  }
  edit(street:Street){
    this._router.navigate(['popup',street]);

  }
  saveStreet(street:Street):void{
    debugger;
this._service.updateStreet(street).subscribe(data=>
  {
 let indax= this.street.indexOf(street);
 this.street[indax]=data;
  }
  )
  }
  delete(street:Street)
  {
    this._service.deleteStreet(street.id).subscribe(data => 
      {
     this.street.slice(this.street.indexOf(street),1);
      }
     
      );
  }
  onSubmit(name:any, id:any)
  {
  let street =new Street(0,name,id) 
    this._service.addStreet(street).subscribe(data =>{
this.street.push(data);
    })
  }

}
