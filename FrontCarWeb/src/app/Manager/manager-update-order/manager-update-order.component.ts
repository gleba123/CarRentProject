import { Component, OnInit } from '@angular/core';
import { OrdersInfo } from 'src/app/Models/OrdersInfo';
import { AllOrdersService } from 'src/app/services/all-orders.service';

@Component({
  selector: 'app-manager-update-order',
  templateUrl: './manager-update-order.component.html',
  styleUrls: ['./manager-update-order.component.css']
})
export class ManagerUpdateOrderComponent implements OnInit {

  public orderObject = new OrdersInfo();
  public orderInfo: any;
  chooseAction: any;
  public showAllLabels:boolean = true;


  constructor(private OrderService: AllOrdersService) { }
  fun1(Action: any) { this.chooseAction = Action; }


  AddNewOrder() { //post new Order Manager Connected with Order Service
    this.OrderService.AddNewOrder(this.orderObject).subscribe(order => {
      alert("New Order Was Made =] ");
    }, err => {
      alert("Error: " + err.message);
    })
  }

  UpdateOrder() {
    this.OrderService.UpdateOrder(this.orderObject).subscribe(order => {
      this.orderInfo = order;
      alert("Your Order Is Updated Successfully");
    }, err => {
      alert("Error: " + err.message);
    })
  }

  DeleteOrder() {
    this.OrderService.DeleteOrder(this.orderObject).subscribe(order => {
        this.orderInfo = order;
      alert("Order deleted successfully");
    },err=>{
      alert("Error: " + err.message);
    })
  }

  ngOnInit(): void {
  }

}
