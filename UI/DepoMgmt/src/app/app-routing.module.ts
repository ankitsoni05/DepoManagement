import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddNewDriverComponent } from './add-new-driver/add-new-driver.component';
import { AllDriversComponent } from './all-drivers/all-drivers.component';
import { DriverDetailsComponent } from './driver-details/driver-details.component';

const routes: Routes = [ 
  {path:'drivers',component:AllDriversComponent},
  {path:'driverdetail/:id',component:DriverDetailsComponent},
  {path:'addNew',component:AddNewDriverComponent},
  {path:'details',component:DriverDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
