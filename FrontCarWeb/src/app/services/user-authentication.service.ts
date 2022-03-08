import { Injectable } from '@angular/core';
import { UserProps } from '../Models/UserInfo';

@Injectable({
  providedIn: 'root'
})
export class UserAuthenticationService {

    // service that give the promotion to the Emp, this service get the info and check the role by that we can deside how to connect

  isAouthenticated = true;
  signed=false;
  logOut=false;
  
  constructor() { }

// function that return true/false to show the user

  Authenticate(roleData: UserProps): boolean {
    if (this.CheackCredentials(roleData)) {
      this.isAouthenticated = false;
      this.signed=true;
      this.logOut=false;
      return true;
    }
    else{ 

      this.isAouthenticated = true;
      this.signed=false;
      this.logOut=true;
    }
    return false;
  }

  // cheack the role
  private CheackCredentials(roleData: UserProps): boolean {
    if (roleData == "user") {
      return true;

    }
    else
      return false;
  }
}
