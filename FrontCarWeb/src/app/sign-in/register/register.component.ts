import { Component, OnInit } from '@angular/core';
import { UserProps } from 'src/app/Models/UserInfo';
import { AllUsersService } from 'src/app/services/all-users.service';
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  public User = new UserProps();
  public register: any;
  public testBox: any;
  constructor(private userService: AllUsersService) { }




//  register functiom that connect with the service
  Register() {
    this.userService.Register(this.User).subscribe(user => {
        this.register = user;
        alert("Welcome");
    },err => {
        alert("NickName Is Already Exist , Try Again " + err.message);
    });
  }

  ngOnInit(): void {
    this.testBox = null;
  }
}


  //   function CalcAge(birthdate:string):number{ //function that Calculate now age (if age is under 18 the user cannot be registerd)
  //   var timeDiff = Math.abs(Date.now() - new Date(birthdate).getTime());
  //   var age = Math.floor(timeDiff / (1000 * 3600 * 24) / 365.25);
  //   if(age<18)
  //   console.log(age)
  //   return age
  // }




