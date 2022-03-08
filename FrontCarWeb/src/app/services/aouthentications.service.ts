import { Injectable } from '@angular/core';
import { UserProps } from '../Models/UserInfo';

@Injectable({
  providedIn: 'root'
})
export class AouthenticationsService {

  // service that give the promotion to the managet this function get the info and check the role by that we can deside how to connect
  isAouthenticated = false;
  signed=true;
  logOut=false;


  constructor() { }

// function that return true/false to show the user
  Authenticate(roleData: UserProps): boolean {
    if (this.CheackCredentials(roleData)) {
      this.isAouthenticated = true;
      this.signed=false;
      return true;
    }
    else{ Injectable}
    this.isAouthenticated = false;
    this.signed=true;
    return false;
  }
// cheack the role
  private CheackCredentials(roleData: UserProps): boolean {
    if (roleData == "host") {
      return true;

    }
    else
      return false;
  }




}
