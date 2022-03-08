import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HomePageComponent } from '../home/home-page/home-page.component';
import { CarsProp } from '../Models/AllCars';
import { AllCarsService } from './all-cars.service';


@Injectable({
  providedIn: 'root'
})
export class CalculatePriceService {
  fDateSaver: any;
  sDateSaver: any;
  diff: any;
  continue: any;
  finalPrice: any;
  SaveDelayPrice:any;


  constructor(private CalcHttp: HttpClient,) { }

  CaRentPrice(CarNum: CarsProp): Observable<CarsProp> {
    return this.CalcHttp.get<CarsProp>("https://localhost:44384/UserCarPage/GetCarsByNumber/" + CarNum);
  }

  calculateDiff(firstDate: any, lastDate: any) {
    this.fDateSaver = new Date(firstDate).getTime();
    this.sDateSaver = new Date(lastDate).getTime();
    this.diff = (this.sDateSaver - this.fDateSaver) / 86400000;
  }

  FinalPrice(price: any, DelayPrice: any) { //func for the finall price
    this.finalPrice = this.diff * price[0].dayPrice;
    this.SaveDelayPrice=DelayPrice[0].delayPrice;
    this.CheckForSignIn(this.finalPrice, this.SaveDelayPrice);
  }

  FinalPriceOrder(price: any, DelayPrice: any) { //func for the finall price
    this.finalPrice = this.diff * price[0].dayPrice;
    this.SaveDelayPrice=DelayPrice[0].delayPrice;
    this.ShowPrice(this.finalPrice, this.SaveDelayPrice);
  }

  ShowPrice(finalPrice: any, delayPrice:any) { //func that alert the price of non lig in user after cheack car
   alert("Thank You, Your Final Price Is = " + finalPrice + " NIS " + ", Delay Price = " + delayPrice + " NIS");
  }

  CheckForSignIn(finalPrice: any, delayPrice:any) { //func that alert the price of non lig in user after cheack car
    let conf = confirm("Final Price = " + finalPrice + " NIS " + " Delay Price = " + delayPrice + ", Would You Like To Log-In For Order?");
    if (conf == true) {
      location.replace("SignIn");
    }
  }
}
