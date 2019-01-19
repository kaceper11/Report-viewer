import { Component, Inject, OnInit } from '@angular/core';
import { ReportService } from '../reportApi.service';
import { ExportToCsv } from 'export-to-csv';


@Component({
  selector: 'get-number-of-passengers',
  templateUrl: './getNumberOfPassengers.html'
})
export class GetNumberOfPassengersComponent {
  public numberOfPassengers: number;
  public numberOfPassengersInPeriod: number;
  public startDate: Date;
  public endDate: Date;
  public csvExporter: ExportToCsv;

  public csvOptions: {
    filename: string, fieldSeparator: string, quoteStrings: string, decimalseparator: string, showLabels: boolean,
    showTitle: boolean, title: string, useBom: boolean, headers: string[]
  };
  public csvData: { numberOfPassengers: number, numberOfPassengersInPeriod: number }[];

  constructor(
    private reportService: ReportService) {

  }
  
  public generateCsv(): void {
    this.csvData = [
      {
        numberOfPassengers: this.numberOfPassengers,
        numberOfPassengersInPeriod: this.numberOfPassengersInPeriod
      }];
    this.csvOptions = {
      filename: 'Liczba pasażerów',
      fieldSeparator: ',',
      quoteStrings: '"',
      decimalseparator: '.',
      showLabels: true,
      showTitle: true,
      title: 'Liczba pasażerów',
      useBom: true,
      headers: ['Liczba pasażerów od początku', this.startDate + '-' + this.endDate]
    };
    this.csvExporter = new ExportToCsv(this.csvOptions);
    this.csvExporter.generateCsv(this.csvData);
  }

  onSubmit() {
    this.reportService.getNumberOfPassengersInPeriod(this.startDate, this.endDate)
      .subscribe((data: number) => this.numberOfPassengersInPeriod = data);

    this.reportService.getNumberOfPassengers()
      .subscribe((data: number) => this.numberOfPassengers = data);

  }

 

  

  


}

