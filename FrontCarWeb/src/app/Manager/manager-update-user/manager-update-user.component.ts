import { Component, OnInit } from '@angular/core';
import { UserProps } from 'src/app/Models/UserInfo';
import { HttpClient } from '@angular/common/http';
import { AllUsersService } from 'src/app/services/all-users.service';

@Component({
  selector: 'app-manager-update-user',
  templateUrl: './manager-update-user.component.html',
  styleUrls: ['./manager-update-user.component.css']
})
export class ManagerUpdateUserComponent implements OnInit {


  public User = new UserProps();
  public UserProps: any;
  chooseAction: any;
  id: any;
  public showAllLabels:boolean = true;


  constructor(private http: HttpClient, private userService: AllUsersService) { }

  fun1(Action: any) { this.chooseAction = Action; }

  GetUserbyId(userId: any) {
    this.userService.GetUserById(this.id).subscribe(user => {
      this.UserProps = user;
    }, err => {
      alert(err.message);
    })
  }

  AddNewUser() {
    this.userService.PostNewUser(this.User).subscribe(user => {
      alert("User Added!");
    }, err => {
      alert(err.message);
    })
  }

  UpdateUser() {
    this.userService.UpdateUser(this.User).subscribe(user => {
      this.UserProps = user;
      alert("Your info was Updated...");
    }, err => {
      alert("Error" + err.message);
    })
  }


  RemoveUser(){
    this.userService.DeleteUser(this.User).subscribe(user => {
      this.UserProps = user;
      alert("User Removed");
    }, err => {
      alert("Error" + err.message);
    })
  }

  public ngOnInit(): void {
  }

}


