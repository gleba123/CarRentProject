import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { HeaderComponent } from '../header/header.component';
import { UserLogIn } from '../Models/logIn';
import { UserProps } from '../Models/UserInfo';
import { AllUsersService } from '../services/all-users.service';
import { AouthenticationsService } from '../services/aouthentications.service';
import { EmpAuthenticationService } from '../services/emp-authentication.service';
import { UserAuthenticationService } from '../services/user-authentication.service';
@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  UserAarr: any
  answer: any;
  public userLogIn = new UserLogIn();
  public userInfo: any;
  public UserProps: any;
  userSaver: any;


  constructor(private userService: AllUsersService, private ManagerCheckInjectionAouthentication: AouthenticationsService, private EmpCheckInjectionAouthentication: EmpAuthenticationService, private userCheckInjectionAouthentication: UserAuthenticationService, public HeaderInjection: HeaderComponent) { }

  // sign in func that connected to the services
  SignIn() {
    this.userService.SignIn(this.userLogIn).subscribe(signIn => {
      this.userInfo = signIn;
      if (this.userInfo != null) {
        this.userService.UserNameSaver(this.userInfo, this.userInfo);
      }
      else {
        alert("login failed");
      }

      // the connection with the services to user/emp/host promotions

      this.userService.UserNameSaver(this.userInfo, this.userInfo);
      this.ManagerCheckInjectionAouthentication.Authenticate(this.userInfo.role);
      this.EmpCheckInjectionAouthentication.Authenticate(this.userInfo.role);
      this.userCheckInjectionAouthentication.Authenticate(this.userInfo.role);


      // give time out to show alert after the page is loading
      setTimeout(function () {
        alert("Welcome Back... ");

      }, 50);

    }, (err: { message: string; }) => {
      let conf = confirm("NickName Or Password Is Invalid Would You Like To Try Again? " + err.message);
      if(conf==true){
        location.replace("SignIn");
      }
      else{
        location.replace("Home");
      }
    });
  }



ngOnInit(): void {
}

}
