import { Component, OnInit } from '@angular/core';
import { AllCarsService } from '../services/all-cars.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {
  public favorites: any = [];
  public Showfavorits = false;  

  constructor() {}
 
//Funtion that Get the Cars inside the Local / favoriets
  onClickFav() {

    this.Showfavorits = !this.Showfavorits
    if (!this.Showfavorits) {
      this.favorites = []
      return
    }
      this.favorites = JSON.parse(localStorage.getItem("Cars")||'{}');
  }


  ngOnInit(): void {
  }

}
