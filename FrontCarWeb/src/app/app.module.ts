import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { HomePageComponent } from './home/home-page/home-page.component';
import { SignInComponent } from './sign-in/sign-in.component';
import { RegisterComponent } from './sign-in/register/register.component';
import { FormsModule } from '@angular/forms';
import { Page404Component } from './page404/page404.component';
import { SearchPipePipe } from './Pipes/search-car.pipe';
import { ManagerPageComponent } from './Manager/manager-page/manager-page.component';
import { ManagerUpdateUserComponent } from './Manager/manager-update-user/manager-update-user.component';
import { ManagerUpdateCarsComponent } from './Manager/manager-update-cars/manager-update-cars.component';
import { ManagerUpdateOrderComponent } from './Manager/manager-update-order/manager-update-order.component';
import { EmployeeComponent } from './Employee/employee/employee.component';
import { SearchByYearPipe } from './Pipes/search-by-year.pipe';
import { SearchByModelPipe } from './Pipes/search-by-model.pipe';
import { OrderComponent } from './Order/order/order.component';
import { AboutComponent } from './home/about/about.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomePageComponent,
    SignInComponent,
    RegisterComponent,
    Page404Component,
    SearchPipePipe,
    ManagerPageComponent,
    ManagerUpdateUserComponent,
    ManagerUpdateCarsComponent,
    ManagerUpdateOrderComponent,
    EmployeeComponent,
    SearchByYearPipe,
    SearchByModelPipe,
    OrderComponent,
    AboutComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [OrderComponent,SignInComponent,HeaderComponent,HomePageComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
