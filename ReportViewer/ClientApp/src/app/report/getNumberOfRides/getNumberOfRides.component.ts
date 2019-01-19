import { Component, Inject, OnInit } from '@angular/core';
import { ReportService } from '../reportApi.service';
import { Line } from './LineModel';
import { ExportToCsv } from 'export-to-csv';


@Component({
  selector: 'get-number-of-rides',
  templateUrl: './getNumberOfRides.html'
})

export class GetNumberOfRidesComponent {
  public numberOfRides: number;
  public numberOfRidesInPeriod: number;
  public startDate: Date;
  public endDate: Date;
  public lines = [] as Line[];
  public lineId: number;
  public csvExporter: ExportToCsv;
  public lineNumber: string;

  public csvOptions: {
    filename: string, fieldSeparator: string, quoteStrings: string, decimalseparator: string, showLabels: boolean,
    showTitle: boolean, title: string, useBom: boolean, headers: string[]
  };

  public csvData: { numberOfRides: number, numberOfRidesInPeriod: number, lineNumber: string }[];

  constructor(
    private reportService: ReportService) {

  }

  ngOnInit() {
        this.reportService.getBusLines()
          .subscribe((data: any[]) => this.lines = data)
  }

  selectOption(args) {
    this.lineNumber = args.target.options[args.target.selectedIndex].text; 
  }


  public generateCsv(): void {
    this.csvData = [
      {
        numberOfRides: this.numberOfRides,
        numberOfRidesInPeriod: this.numberOfRidesInPeriod,
        lineNumber: this.lineNumber
      }];
    this.csvOptions = {
      filename: 'Liczba przejazdów',
      fieldSeparator: ',',
      quoteStrings: '"',
      decimalseparator: '.',
      showLabels: true,
      showTitle: true,
      title: 'Liczba przejazdów',
      useBom: true,
      headers: ['Liczba przejazdów od początku', this.startDate + '-' + this.endDate, 'Numer linii']
    };
    this.csvExporter = new ExportToCsv(this.csvOptions);
    this.csvExporter.generateCsv(this.csvData);
  }

  onSubmit() {
    this.reportService.getNumberOfRidesInPeriod(this.lineId, this.startDate, this.endDate)
      .subscribe((data: number) => this.numberOfRidesInPeriod = data);

    this.reportService.getNumberOfRides(this.lineId)
      .subscribe((data: number) => this.numberOfRides = data);


  }


}
