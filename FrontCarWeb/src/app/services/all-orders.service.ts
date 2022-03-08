import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OrdersInfo } from '../Models/OrdersInfo';

@Injectable({
  providedIn: 'root'
})
export class AllOrdersService {

  constructor(private GetOrderHttp:HttpClient) { }

    // service that connected with the webApi - show all the orders tp the manager

  public GetAllOrdersAsync():Observable<OrdersInfo[]> {//get string that give to the User/Manager all the orders
    return this.GetOrderHttp.get<OrdersInfo[]>("https://localhost:44384/ManagerPage/GetAllOrders");
}
    // service that connected with the webApi - give us the option to add new order

public AddNewOrder(newOrder:OrdersInfo):Observable<OrdersInfo[]>{
  return this.GetOrderHttp.post<OrdersInfo[]>("https://localhost:44384/ManagerPage/PostUserOrder",newOrder);
}

    // service that connected with the webApi - give us the option to update new order


public UpdateOrder(order:OrdersInfo):Observable<OrdersInfo[]> {
  return this.GetOrderHttp.put<OrdersInfo[]>("https://localhost:44384/ManagerPage/UpdateOrder"+"/" + order.orderNum,order);
}

    // service that connected with the webApi - give us the option to delete new order

public DeleteOrder(order:OrdersInfo):Observable<OrdersInfo[]> {
 return this.GetOrderHttp.delete<OrdersInfo[]>("https://localhost:44384/ManagerPage/DeleteOrder" + "/" + order.orderNum);
}


}
