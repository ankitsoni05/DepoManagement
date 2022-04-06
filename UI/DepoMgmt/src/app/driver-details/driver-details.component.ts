import { Component, Input, OnInit,AfterViewInit,ViewChild } from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import { ToastrService } from 'ngx-toastr';
import { DriverService } from '../_services/driver.service';
import { ActivatedRoute } from '@angular/router';
import {MatTableDataSource} from '@angular/material/table';
import * as _ from 'lodash';

@Component({
  selector: 'app-driver-details',
  templateUrl: './driver-details.component.html',
  styleUrls: ['./driver-details.component.css']
})
export class DriverDetailsComponent implements OnInit,AfterViewInit {
  @Input("driverId") driverId :number = 0;
  driverDetails : any;
  constructor(private _accountService : DriverService,private _toastr : ToastrService,private _Activatedroute:ActivatedRoute) { }
  ngAfterViewInit(): void {
    throw new Error('Method not implemented.');
  }

  ngOnInit(): void {
    this._Activatedroute.paramMap.subscribe(params => { 
      this.driverId = (Number)(params.get('id')); 
    });

    this._accountService.getDriverInformation(this.driverId)
      .subscribe((res:any)=>{
      this.driverDetails = res;
      _.forEach(this.driverDetails?.driverPays,(value)=>{
        this.ELEMENT_DATA.push({
          otId : value.payId,
          AddedDate : value.payDate,
          AddedForMonth : value.payDate,
          overTimeAmount: value.overTimeAmount
           });
       });
    },err=>{

    },()=>{
      this.dataSource.paginator = this.paginator;
    });
  }

  displayedColumns: string[] = ['otId', 'AddedDate', 'AddedForMonth', 'overTimeAmount'];
  ELEMENT_DATA: driverPay[] = []
  dataSource = new MatTableDataSource<driverPay>(this.ELEMENT_DATA);

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;

}

export interface driverPay {
  otId:any;
  AddedDate: any;
  AddedForMonth: any;
  overTimeAmount: any;
}
