import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CarsProp } from 'src/app/Models/AllCars';
import { AllCarsService } from 'src/app/services/all-cars.service';

@Component({
  selector: 'app-manager-update-cars',
  templateUrl: './manager-update-cars.component.html',
  styleUrls: ['./manager-update-cars.component.css']
})
export class ManagerUpdateCarsComponent implements OnInit {
  public FilteringManufactor: any; //prop for the pipe to made the free search by manufactor
  public carPost = new CarsProp(); //new object for the post/add func
  public carsProps: any;
  chooseAction: any; //prop for fun1
  public showAllLabels: boolean = true;


  constructor(private allCarsService: AllCarsService) { }

  fun1(Action: any) { this.chooseAction = Action; } //choose function

  AddCarInfo() { //Add New Car  Func
    this.allCarsService.PostCarInfoAsync(this.carPost).subscribe(car => {
      this.allCarsService.PostCarTypeAsync(this.carPost).subscribe(car => {
        this.carsProps = car;
        alert("New Car added!");
      }, err => {
        alert("Error:" + err.message);
      });
    });
  }

  UpdateCarInfo() { //Update Car  Func
    this.allCarsService.UpdateCarInfoAsync(this.carPost).subscribe(car => {
      this.allCarsService.UpdateCarTypeAsync(this.carPost).subscribe(car => {
        this.carsProps = car;
        alert("Car Updated!");
      }, err => {
        alert("Error:" + err.message);
      });
    });
  }

  DeleteCarInfo() { //Delete Car  Func
    this.allCarsService.DeleteCarType(this.carPost).subscribe(car => {
      this.allCarsService.DeleteCarInfo(this.carPost).subscribe(car => {
        this.carsProps = car;
        alert("Car Updated!");
      }, err => {
        alert("Error:" + err.message);
      });
    });
  }


  public ngOnInit(): void { }

}
