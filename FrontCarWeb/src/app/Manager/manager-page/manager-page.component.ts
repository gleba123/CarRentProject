import { Component, OnInit } from '@angular/core';
import { CarsProp } from 'src/app/Models/AllCars';
import { OrdersInfo } from 'src/app/Models/OrdersInfo';
import { UserProps } from 'src/app/Models/UserInfo';
import { AllCarsService } from 'src/app/services/all-cars.service';
import { AllOrdersService } from 'src/app/services/all-orders.service';
import { AllUsersService } from 'src/app/services/all-users.service';

@Component({
  selector: 'app-manager-page',
  templateUrl: './manager-page.component.html',
  styleUrls: ['./manager-page.component.css']
})
export class ManagerPageComponent implements OnInit {

  public FilteringManufactor: any;
  public getCars: CarsProp[];
  public getUsers: UserProps[];
  public OrderProp:OrdersInfo[];


  chooseAction: any;

  constructor(private allCarsService: AllCarsService, private userService: AllUsersService,private OrderService:AllOrdersService) { }

  fun1(Action: any) { this.chooseAction = Action; }

  //func that show all the orders
  GetAllOrdersFunc(){
    this.OrderService.GetAllOrdersAsync().subscribe(orderProp=>{

      this.OrderProp=orderProp;
  
  },err=>{
    alert("Error:" + err.message);
  });
    

  }


    //func that show all the users
  GetAllUserFunc() {
    this.userService.GetAllUsersAsync().subscribe(userProp => {
      this.getUsers = userProp;
    }, err => {
      alert("Error:" + err.message);
    })
  }

  //func that show all the cars
  GetAllCarsFunc() {
    this.allCarsService.GetAllCarsManagerAsync().subscribe(carsProp => {
      this.getCars = carsProp;
    }, err => {
      alert("Error:" + err.message);
    });
  }
  

  ngOnInit(): void {
  }

}
