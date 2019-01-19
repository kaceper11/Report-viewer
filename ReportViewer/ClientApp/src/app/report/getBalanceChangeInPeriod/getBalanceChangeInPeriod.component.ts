import { Component, Inject, OnInit } from '@angular/core';
import { ReportService } from '../reportApi.service';
import { ExportToCsv } from 'export-to-csv';


@Component({
  selector: 'get-balance-change-in-period',
  templateUrl: './getBalanceChangeInPeriod.html'
})

export class GetBalanceChangeInPeriodComponent  {
  public balanceChangeInPeriod: number;
  public balanceChange: number;
  public startDate: Date;
  public endDate: Date;
  public csvExporter: ExportToCsv;

  public csvOptions: {
    filename: string, fieldSeparator: string, quoteStrings: string, decimalseparator: string, showLabels: boolean,
    showTitle: boolean, title: string, useBom: boolean, headers: string[]
  };

  public csvData: { balanceChange: number, balanceChangeInPeriod: number }[];

  constructor(
    private reportService: ReportService) {

  }

  public generateCsv(): void {
    this.csvData = [
      {
        balanceChange: this.balanceChange,
        balanceChangeInPeriod: this.balanceChangeInPeriod
      }];
    this.csvOptions = {
      filename: 'Zmiana salda',
      fieldSeparator: ',',
      quoteStrings: '"',
      decimalseparator: '.',
      showLabels: true,
      showTitle: true,
      title: 'Zmiana salda',
      useBom: true,
      headers: ['Zmiana salda od początku', this.startDate + '-' + this.endDate]
    };
    this.csvExporter = new ExportToCsv(this.csvOptions);
    this.csvExporter.generateCsv(this.csvData);
  }

  onSubmit() {
   this.reportService.getBalanceChangeInPeriod(this.startDate, this.endDate)
      .subscribe((data: number) => this.balanceChangeInPeriod = data);

    this.reportService.getBalanceChange()
      .subscribe((data: number) => this.balanceChange = data);

  }


}
