import { Component, OnInit } from '@angular/core';
import { CarsProp } from 'src/app/Models/AllCars';
import { OrdersInfo } from 'src/app/Models/OrdersInfo';
import { AllCarsService } from 'src/app/services/all-cars.service';
import { CalculatePriceService } from 'src/app/services/calculate-price.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  constructor(private EmpService:AllCarsService,private calculatePriceService:CalculatePriceService ) { }
  empReturn=new OrdersInfo();
  RentDateSaver:any;
  OrderProps:any;
  userTz:OrdersInfo
  CarPriceReturn: any;
  PriceReturn=new CarsProp;


// return function
  ReturnCarFunc(){
    this.EmpService.EmpReturnCarFunc(this.empReturn).subscribe(emp=>{
      alert("info was updated");
    },err=>{
      alert("Car Is Already Returned " + err.message);
    })
  }

// function that gice us outo the order number
  GetOrderByUserId(userTz: any) {
    this.EmpService.EmpGetOrderByUserId(this.userTz).subscribe(order => {
      this.OrderProps = order;
    }, err => {
      alert(err.message);
    })
  }


  ngOnInit(): void {
  }

}
