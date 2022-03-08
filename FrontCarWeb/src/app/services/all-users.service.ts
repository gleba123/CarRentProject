import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { observable, Observable } from 'rxjs';
import { UserLogIn } from '../Models/logIn';
import { OrdersInfo } from '../Models/OrdersInfo';
import { UserProps } from '../Models/UserInfo';

@Injectable({
  providedIn: 'root'
})
export class AllUsersService {
  userIdSaver:any;
  userNameSaver:any;

  constructor(private UsersHttp: HttpClient) { }

  public GetAllUsersAsync(): Observable<UserProps[]> {//get string that give to the User/Manager all the Users.
    return this.UsersHttp.get<UserProps[]>("https://localhost:44384/ManagerPage/GetAllUsers");
  }

  public GetUserById(userId: any): Observable<UserProps[]> {//get by id string that give spacific User.
    return this.UsersHttp.get<UserProps[]>("https://localhost:44384/ManagerPage/GetUserByTz" + "/" + userId);
  }

  // signIn Connection with the WebApi give the promotion to all signin
  public SignIn(user:UserProps): Observable<UserProps[]> {
    return this.UsersHttp.get<UserProps[]>("https://localhost:44384/UserCarPage/Login" + '/' + user.nickName + '/' + user.password)
  }
  public UserNameSaver(nickName:UserLogIn,userTz:UserLogIn) {
    this.userNameSaver=nickName.nickName;
    this.userIdSaver=userTz.userTz;
  }

  // the register func for new costumer / user
  public Register(register: UserProps): Observable<UserProps[]> {
    register.role="user";
    return this.UsersHttp.post<UserProps[]>("https://localhost:44384/UserCarPage/Register", register);
  }

  // add new user by the manager
  public PostNewUser(userProps: UserProps): Observable<UserProps[]> {//post function manager for new user
    return this.UsersHttp.post<UserProps[]>("https://localhost:44384/ManagerPage/PostNewUser", userProps);
  }
  // add new order by the user
  public AddNewOrder(newOrder: OrdersInfo): Observable<OrdersInfo[]> {
    newOrder.userTz=this.userIdSaver;
    return this.UsersHttp.post<OrdersInfo[]>("https://localhost:44384/UserCarPage/NewUserOrder", newOrder);
  }

  // show us the user spacific orders 
  public ShowUserOrder(userTz:OrdersInfo):Observable<OrdersInfo[]>{
    userTz.userTz=this.userIdSaver;
    return this.UsersHttp.get<OrdersInfo[]>("https://localhost:44384/UserCarPage/ShowUserOrder" + "/" + userTz.userTz);
  }

  // update user

  public UpdateUser(userProps: UserProps): Observable<UserProps[]> {//put function manager for existing user
    return this.UsersHttp.put<UserProps[]>("https://localhost:44384/ManagerPage/UpdateUserInfo" + "/" + userProps.userTz, userProps);
  }
// delete user
  public DeleteUser(userProps: UserProps): Observable<UserProps[]> {//delete function manager for existing user
    return this.UsersHttp.delete<UserProps[]>("https://localhost:44384/ManagerPage/DeleteUser" + "/" + userProps.userTz);
  }

  // upload file function that works but didnt connected right know becouse i didnt to convet to base 64 and stream - but it upload the pic to the db
  public UploadFile(file: any, userProps: UserProps): Observable<UserProps[]> {
    const formData = new FormData();
    const fileToUpload = <File>file[0];
    formData.append('file', fileToUpload, fileToUpload.name);
    return this.UsersHttp.post<UserProps[]>("https://localhost:44384/UserCarPage/Upload" + "/" + userProps.nickName, formData);
  }



}
