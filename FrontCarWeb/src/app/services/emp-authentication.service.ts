import { Injectable } from '@angular/core';
import { UserProps } from '../Models/UserInfo';

@Injectable({
  providedIn: 'root'
})
export class EmpAuthenticationService {

  // service that give the promotion to the Emp, this service get the info and check the role by that we can deside how to connect

  isAouthenticated = false;
  signed=true;
  logOut=false;

  
  constructor() { }

// function that return true/false to show the user

  Authenticate(roleData: UserProps): boolean {
    if (this.CheackCredentials(roleData)) {
      this.isAouthenticated = true;
      this.signed=false;
      this.logOut=false;
      return true;
      
    }
    else{

      this.isAouthenticated = false;
      this.signed=false;
      this.logOut=true;
    }
    return false;
  }

// cheack the role

  private CheackCredentials(roleData: UserProps): boolean {
    if (roleData == "employee") {
      return true;

    }
    else
      return false;
  }
}
