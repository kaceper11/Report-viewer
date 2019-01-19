import { Component, Inject, OnInit } from '@angular/core';
import { ReportService } from '../reportApi.service';
import { ExportToCsv } from 'export-to-csv';

@Component({
  selector: 'get-user-types',
  templateUrl: './getUserTypes.html'
})

export class GetUserTypesComponent implements OnInit {
  public numberOfUsers = [];
  public csvExporter: ExportToCsv;
  public lineNumber: string;

  public csvOptions: {
    filename: string, fieldSeparator: string, quoteStrings: string, decimalseparator: string, showLabels: boolean,
    showTitle: boolean, title: string, useBom: boolean, headers: string[]
  };

  public csvData: { numberOfValidators: number, numberOfTicketMachines: number, numberOfAdministrators: number, numberOfEmployees: number, numberOfCashiers: number }[];

  constructor(
    private reportService: ReportService) {

  }

  ngOnInit() {
      for (let i = 1; i <= 5; i++) {
        this.reportService.getUserTypes(i)
          .subscribe((data: any) => this.numberOfUsers.push(data));   
    }
  }

  public generateCsv(): void {
    this.csvData = [
      {
        numberOfValidators: this.numberOfUsers[0],
        numberOfTicketMachines: this.numberOfUsers[1],
        numberOfAdministrators: this.numberOfUsers[2],
        numberOfEmployees: this.numberOfUsers[3],
        numberOfCashiers: this.numberOfUsers[4]
      }];
    this.csvOptions = {
      filename: 'Liczba użytkowników',
      fieldSeparator: ",",
      quoteStrings: '"',
      decimalseparator: '.',
      showLabels: true,
      showTitle: true,
      title: 'Liczba użytkowników',
      useBom: true,
      headers: ['Kasowniki', 'Biletomaty', 'Administratorzy', 'Pracownicy', 'Sprzedawcy']
    };
    this.csvExporter = new ExportToCsv(this.csvOptions);
    this.csvExporter.generateCsv(this.csvData);
  }

}
