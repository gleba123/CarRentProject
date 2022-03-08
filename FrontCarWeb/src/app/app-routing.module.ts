import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeComponent } from './Employee/employee/employee.component';
import { AboutComponent } from './home/about/about.component';
import { HomePageComponent } from './home/home-page/home-page.component';
import { ManagerPageComponent } from './Manager/manager-page/manager-page.component';
import { ManagerUpdateCarsComponent } from './Manager/manager-update-cars/manager-update-cars.component';
import { ManagerUpdateOrderComponent } from './Manager/manager-update-order/manager-update-order.component';
import { ManagerUpdateUserComponent } from './Manager/manager-update-user/manager-update-user.component';
import { OrderComponent } from './Order/order/order.component';
import { Page404Component } from './page404/page404.component';
import { RegisterComponent } from './sign-in/register/register.component';
import { SignInComponent } from './sign-in/sign-in.component';


const routes: Routes = [
  { path: "Home", component: HomePageComponent },
  {
    path: "Manager", component: ManagerPageComponent,
    children: [
      {
        path: "UpdateUser", component:ManagerUpdateUserComponent
      },
      {
        path: "UpdateCar", component:ManagerUpdateCarsComponent
      },
      {
        path: "UpdateOrder", component:ManagerUpdateOrderComponent
      },
    ]
  },
  {path:"Employee",component:EmployeeComponent},
  {path:"Orders",component:OrderComponent},
  { path: "SignIn", component: SignInComponent },
  { path: "register", component: RegisterComponent },
  {path:"about", component:AboutComponent},
  { path: "", redirectTo: "/Home", pathMatch: "full", },
  { path: "**", component: Page404Component, },


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
