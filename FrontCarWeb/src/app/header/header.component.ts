import { Component, OnInit } from '@angular/core';
import { UserLogIn } from '../Models/logIn';
import { AllUsersService } from '../services/all-users.service';
import { AouthenticationsService } from '../services/aouthentications.service';
import { EmpAuthenticationService } from '../services/emp-authentication.service';
import { UserAuthenticationService } from '../services/user-authentication.service';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(public authenticationsService:AouthenticationsService,public empAuthenticationService:EmpAuthenticationService , public userAuthenticationService:UserAuthenticationService,public allUsersService:AllUsersService) { }
//logOut Function
  LogOut(){
    let conf = confirm("Are You Sure You Want To Log Out?")
    if(conf==true){
      location.replace("Home");
    }
  }
  
  ngOnInit(): void {
  }

}
