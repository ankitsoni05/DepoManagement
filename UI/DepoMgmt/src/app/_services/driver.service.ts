import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DriverService {

  baseUrl = "http://192.168.0.104:88/api/";
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
}
