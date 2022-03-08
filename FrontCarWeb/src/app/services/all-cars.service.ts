import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CarsProp } from '../Models/AllCars';
import { OrdersInfo } from '../Models/OrdersInfo';
import { AllUsersService } from './all-users.service';

@Injectable({
  providedIn: 'root'
})
export class AllCarsService {
  public carNumSaver: any;
  public carTypeSaver: any;
  public RentDateSaver:any;

  constructor(private CarsHttp: HttpClient) { }

  // service that connected with the webApi - show all the cars for the user

  public GetAllUserCarsAsync(): Observable<CarsProp[]> {
    return this.CarsHttp.get<CarsProp[]>("https://localhost:44384/UserCarPage/GetAllCars");//get string that give to the user all the cars with the coockie credentionals that give hom the option to work with his las choices
  }
  // service that connected with the webApi - show all the cars for the manager

  public GetAllCarsManagerAsync(): Observable<CarsProp[]> {
    return this.CarsHttp.get<CarsProp[]>("https://localhost:44384/ManagerPage/GetAllCars");//get string that give to the user all the cars with the coockie credentionals that give hom the option to work with his las choices
  }

  //#region - Post Func For 2 Tables CarType & Car Info

  public PostCarInfoAsync(CarsProp: CarsProp): Observable<CarsProp[]> {
    CarsProp.CarType = CarsProp.manufactor;
    return this.CarsHttp.post<CarsProp[]>("https://localhost:44384/ManagerPage/PostCarInfoTable", CarsProp);//get string that give to the user all the cars with the coockie credentionals that give hom the option to work with his las choices
  }
  public PostCarTypeAsync(CarsProp: CarsProp): Observable<CarsProp[]> {
    return this.CarsHttp.post<CarsProp[]>("https://localhost:44384/ManagerPage/PostCarTypeTable", CarsProp);//get string that give to the user all the cars with the coockie credentionals that give hom the option to work with his las choices   
  }
  //#endregion

  //#region - Put Func For 2 Tables CarType & Car Info
  public UpdateCarInfoAsync(CarsProp: CarsProp): Observable<CarsProp[]> {
    CarsProp.CarType = CarsProp.manufactor;
    this.carNumSaver = CarsProp.CarNum;
    return this.CarsHttp.put<CarsProp[]>("https://localhost:44384/ManagerPage/UpdateCarsInfo" + "/" + CarsProp.CarNum, CarsProp);
  }
  public UpdateCarTypeAsync(CarsProp: CarsProp): Observable<CarsProp[]> {
    CarsProp.CarNum = this.carNumSaver;
    return this.CarsHttp.put<CarsProp[]>("https://localhost:44384/ManagerPage/UpdateCarsType" + "/" + CarsProp.CarNum, CarsProp);
  }
  //#endregion

  //#region - Delete Func For 2 Tables CarType & Car Info
  public DeleteCarInfo(CarsProp: CarsProp): Observable<CarsProp[]> {
    return this.CarsHttp.delete<CarsProp[]>("https://localhost:44384/ManagerPage/DeleteCarInfo" + "/" + CarsProp.CarNum);
  }

  public DeleteCarType(CarsProp: CarsProp): Observable<CarsProp[]> {
    return this.CarsHttp.delete<CarsProp[]>("https://localhost:44384/ManagerPage/DeleteCarType" + "/" + CarsProp.CarNum);
  }
  //#endregion

  //#region - Return Func For The Employee Page:
  public EmpReturnCarFunc(order: OrdersInfo): Observable<OrdersInfo[]> {
    return this.CarsHttp.put<OrdersInfo[]>("https://localhost:44384/EmployeePage/EmployeeReturnCar" + "/" + order.carNum, order);
  }
  //#endregion

  // service that give us the order number to do changes outo
  public EmpGetOrderByUserId(order:OrdersInfo): Observable<OrdersInfo>{
    this.RentDateSaver=order.startRentDate;
    return this.CarsHttp.get<OrdersInfo>("https://localhost:44384/EmployeePage/ShowUserOrder" + "/" + order);
  }

  //#region -localStorage For Cars:
  AddCarToLocalStorage(car: CarsProp) {
    var cars:any = [];
    if (localStorage.getItem("Cars")) {
      cars = JSON.parse(localStorage.getItem("Cars") || '{}');
      cars = [car, ...cars];
 
    }
    else {
      cars = [car];
      
    }

    localStorage.setItem('Cars', JSON.stringify(cars));
    
  }
  //#endregion
}
