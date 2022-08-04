import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Street } from './models/street.model';
import { PopupComponent } from './popup/popup.component';
import { StreetComponent } from './street/street.component';

const routes: Routes = [
  {path: 'streets/:city',component:StreetComponent},
  {path:'popup',component:PopupComponent,data:Street},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
