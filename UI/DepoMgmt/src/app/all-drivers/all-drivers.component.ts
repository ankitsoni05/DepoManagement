import {AfterViewInit, Component, ViewChild} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import { DriverService } from '../_services/driver.service';
import * as _ from 'lodash';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-all-drivers',
  templateUrl: './all-drivers.component.html',
  styleUrls: ['./all-drivers.component.css']
})
export class AllDriversComponent implements AfterViewInit  {
  constructor(private _accountService : DriverService,private _toastr : ToastrService) { }

  ngOnInit(): void {
    this.setDriversInfo();
  }
  
  displayedColumns: string[] = ['DriverId', 'Name', 'DOB', 'DOJ','Contact','Email','Division','Depo'];
  ELEMENT_DATA: PeriodicElement[] = []
  dataSource = new MatTableDataSource<PeriodicElement>(this.ELEMENT_DATA);

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;

  ngAfterViewInit() {
    //this.dataSource.paginator = this.paginator;
  }

  setDriversInfo(){
    this._accountService.getAllDrivers().subscribe((res:any)=>{
      // ELEMENT_DATA = [];
      console.log(res);
      _.forEach(res,(value)=>{
       this.ELEMENT_DATA.push({
            driverId : value.driverId,
            Name: value.firstName +' '+value.lastName,
            DOB: value.dateOfBirth,
            DOJ: value.dateOfJoining,
            Contact:value.contactNumber,
            Email:value.emailId,
            Division:value.depo.division.divisionName,
            Depo:value.depo.depoName
          });
      });
    },error=>{

    },()=>{
      this._toastr.success("Successfully loaded "+this.ELEMENT_DATA.length+" Drivers")
      this.dataSource.paginator = this.paginator;
    });
    
  }
  onChangeEvent(event: any){
    debugger;
    console.log(event.target.value);
    this.dataSource.filter = String(event.target.value).trim().toLocaleLowerCase();
    if(this.dataSource.filteredData.length == 0){
      this._toastr.error("No Data found")
    }
  }

}
export interface PeriodicElement {
  driverId:any;
  Name: any;
  DOB: any;
  DOJ: any;
  Contact:any;
  Email:any;
  Division:any;
  Depo:any
}