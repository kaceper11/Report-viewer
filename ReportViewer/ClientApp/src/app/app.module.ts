import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { GetBalanceChangeInPeriodComponent } from './report/getBalanceChangeInPeriod/getBalanceChangeInPeriod.component';
import { GetUserTypesComponent } from './report/getUserTypes/getUserTypes.component';
import { GetNumberOfRidesComponent } from './report/getNumberOfRides/getNumberOfRides.component';
import { GetNumberOfPassengersComponent } from './report/getNumberOfPassengers/getNumberOfPassengers.component';
import { ReportService } from './report/reportApi.service';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './guards/auth-guard.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    GetBalanceChangeInPeriodComponent,
    GetUserTypesComponent,
    GetNumberOfRidesComponent,
    GetNumberOfPassengersComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, canActivate: [AuthGuard] },
      { path: 'login', component: LoginComponent }
    ])
  ],
  providers: [JwtHelperService, ReportService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
