import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class ReportService {
  private headers: HttpHeaders;
  private accessPointUrl: string = 'https://localhost:44364/api/Report';

  constructor(private http: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  public getBalanceChangeInPeriod(startDate: Date, endDate: Date) {
    return this.http.get(this.accessPointUrl + '/getBalanceChangeInPeriod/' + startDate + '/' + endDate, { headers: this.headers });
  }

  public getBalanceChange() {
    return this.http.get(this.accessPointUrl + '/getBalanceChange', { headers: this.headers });
  }

  public getUserTypes(roleTypeId: number ) {
    return this.http.get(this.accessPointUrl + '/getUserTypes/' + roleTypeId, { headers: this.headers });
  }

  public getNumberOfRidesInPeriod(lineId: number, startDate: Date, endDate: Date) {
    return this.http.get(this.accessPointUrl + '/getNumberOfRidesInPeriod/' + lineId + '/' + startDate + '/' + endDate, { headers: this.headers });
  }

  public getNumberOfRides(lineId: number) {
    return this.http.get(this.accessPointUrl + '/getNumberOfRides/' + lineId, { headers: this.headers });
  }

  public getBusLines() {
    return this.http.get(this.accessPointUrl + '/getBusLines', { headers: this.headers });
  }

  public getNumberOfPassengersInPeriod(startDate: Date, endDate: Date) {
    return this.http.get(this.accessPointUrl + '/getNumberOfPassengersInPeriod/' + startDate + '/' + endDate, { headers: this.headers });
  }

  public getNumberOfPassengers() {
    return this.http.get(this.accessPointUrl + '/getNumberOfPassengers', { headers: this.headers });
  }

}
