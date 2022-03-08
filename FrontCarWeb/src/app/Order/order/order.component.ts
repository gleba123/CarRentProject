import { Component, OnInit } from '@angular/core';
import { CarsProp } from 'src/app/Models/AllCars';
import { OrdersInfo } from 'src/app/Models/OrdersInfo';
import { AllCarsService } from 'src/app/services/all-cars.service';
import { AllUsersService } from 'src/app/services/all-users.service';
import { CalculatePriceService } from 'src/app/services/calculate-price.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

  public orderObject = new OrdersInfo();
  public UserIdPropSaver: any = [];
  public CarsProp: CarsProp[];
  public allMyOrders: OrdersInfo[];
  public ordersDisplay = false;
  public UserTz: any
  PriceReturn=new CarsProp;
  CarPriceReturn: any;



  constructor(public allUsersService: AllUsersService, private allCarsService: AllCarsService,public calculatePriceService:CalculatePriceService) { }

  CalcRent(CarNum:any,fDate:any,sDate:any){
    this.calculatePriceService.CaRentPrice(CarNum).subscribe((price)=>{
      this.PriceReturn=price;
      this.CarPriceReturn=this.PriceReturn
      this.calculatePriceService.calculateDiff(fDate,sDate)
      this.calculatePriceService.FinalPriceOrder(this.CarPriceReturn,this.CarPriceReturn);
    })
  }

  AddNewOrder(CarNum:any,fDate:any,sDate:any) { //post new Order Manager Connected with Order Service
    this.allUsersService.AddNewOrder(this.orderObject,).subscribe(order => {
      this.CalcRent(CarNum,fDate,sDate);
    }, err => {
      alert("Error: " + err.message);
    })
  }

  ShowOrders() {
    this.ordersDisplay = !this.ordersDisplay
    this.allUsersService.ShowUserOrder(this.orderObject).subscribe(myOrders => {
      this.allMyOrders = myOrders;
    }, err => {
      alert("Error No Orders Was Found : " + err.message);
    })
    
  }

  ngOnInit(): void {

  }
}
