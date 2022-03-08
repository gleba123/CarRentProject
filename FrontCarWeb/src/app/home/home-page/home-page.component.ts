import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CarsProp } from 'src/app/Models/AllCars';
import { AllCarsService } from 'src/app/services/all-cars.service';
import { CalculatePriceService } from 'src/app/services/calculate-price.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {
  public FilteringManufactor: any;
  public FilteringModel: any;
  public FilteringYear: any;
  PriceReturn=new CarsProp;
  public CarsProp: CarsProp[];
  CarPriceReturn: any;
  DelayPrice:any;


  constructor(private allCarsService: AllCarsService,public calculatePriceService:CalculatePriceService) { }

  //Function that after the click Give Us all the info from the td that we clicke on
  ChooseFunc(selectedRowInfo: any) { //choose car & add to local storage
    alert("Car Added to Favoriets");
    this.allCarsService.AddCarToLocalStorage(selectedRowInfo);
  }


//function that communicate with the cacl service and calculate the cost of the rent 
  CalcRent(CarNum:any,fDate:any,sDate:any){
    this.calculatePriceService.CaRentPrice(CarNum).subscribe((price)=>{
      this.PriceReturn=price;
      this.CarPriceReturn=this.PriceReturn
      this.calculatePriceService.calculateDiff(fDate,sDate)
      this.calculatePriceService.FinalPrice(this.CarPriceReturn,this.CarPriceReturn);
    })
  }




  public ngOnInit(): void { //All the Properies in th ngOnInit Func Becouse This Func Show All Those Props Aouto.
    this.allCarsService.GetAllUserCarsAsync().subscribe(carsProp => {
      this.CarsProp = carsProp;
    }, err => {
      alert("Error:" + err.message);
    });
  }

}
