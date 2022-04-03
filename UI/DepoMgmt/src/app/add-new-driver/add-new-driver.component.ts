import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DriverService } from '../_services/driver.service';
import * as _ from 'lodash';

@Component({
  selector: 'app-add-new-driver',
  templateUrl: './add-new-driver.component.html',
  styleUrls: ['./add-new-driver.component.css']
})
export class AddNewDriverComponent implements OnInit {

  profileForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    dateOfBirth : new FormControl(''),
    dateOfJoining : new FormControl(''),
    contactNumber : new FormControl(''),
    emailId : new FormControl('',[Validators.required, Validators.email]),
    aadharNumber : new FormControl(''),
    panNumber : new FormControl(''),
    drivingLicenceNumber : new FormControl(''),
    DepoId : new FormControl(''),
    DivisionId : new FormControl(''),
    driverSalary : new FormControl('')
  });
  depos:any
  divisions:any
  depoDropdowns : any;
  divisionDropdowns : any;
  constructor(private _accountService : DriverService) { }

  ngOnInit(): void {
    this.getDropwonsData();
  }

  createDriver() {
    // TODO: Use EventEmitter with form value
    // console.warn(this.profileForm.value);
    this._accountService.createDriver(this.profileForm.value).subscribe(res=>{
      console.log(res);
    })
  }

  getDropwonsData(){
    this._accountService.getDepoAndDivisionData().
    subscribe((res:any)=>{
      this.depos = res?.depos;
      this.divisions = res?.divisions;
      this.depoDropdowns = this.depos;
      this.divisionDropdowns = this.divisionDropdowns;
    })
  }
  someMethod(x:any){
    this.depos = _.filter(this.depoDropdowns, function(o) { return o.divisionId == x; });
  }

}
