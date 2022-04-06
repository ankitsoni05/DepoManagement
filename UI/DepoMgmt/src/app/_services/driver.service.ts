import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DriverService {

  baseUrl = "https://localhost:44391/api/";
  constructor(private http:HttpClient) { }

  getDepoAndDivisionData(){ 
    return this.http.get(this.baseUrl+"Drivers/getDropdownsData")
  }

  createDriver(model:any){
    return this.http.post(this.baseUrl+"Drivers/createDriver",model)
  }

  getAllDrivers(){
    return this.http.get(this.baseUrl+"Drivers/getAllDrivers")
  }

  getDriverInformation(id:number){
    return this.http.get(this.baseUrl+"Drivers/getDriver/"+id)
  }
}
