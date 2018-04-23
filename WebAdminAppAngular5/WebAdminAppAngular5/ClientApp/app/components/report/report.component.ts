import { Component } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { NgModule, ElementRef, Renderer2 } from '@angular/core';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';
import 'rxjs/add/operator/toPromise';

@Component({
    selector: 'report',
    templateUrl: './report.component.html',
    styleUrls: ['./report.component.css']


})
export class ReportComponent {
    reports: any;

    constructor(private http: Http, private router: Router, private route: ActivatedRoute) {
        if (typeof window !== 'undefined') {
            this.WriteReports('MONTHLY');
        }
    }

    async getReportsMonthly() {
        await this.http.get('http://localhost:63058/api/backupstatus/daemon/' + sessionStorage.getItem('token') + '/MONTHLY').toPromise()
            .then((response: Response) => {
                let Reports = response.json();
                if (Reports && "OK" == Reports.Status) {
                    sessionStorage.setItem('Reports', JSON.stringify(Reports.Data));
                } else {
                    sessionStorage.clear();
                    this.router.navigate(['/login'], {})
                }
            })
            .catch((msg: any) => { sessionStorage.clear(); this.router.navigate(['/login'], {}); });
    
    }
    async getReportsWeekly() {
        await this.http.get('http://localhost:63058/api/backupstatus/daemon/' + sessionStorage.getItem('token') + '/WEEKLY').toPromise()
            .then((response: Response) => {
                let Reports = response.json();
                if (Reports && "OK" == Reports.Status) {
                    sessionStorage.setItem('Reports', JSON.stringify(Reports.Data));

                } else {
                    sessionStorage.clear();
                    this.router.navigate(['/login'], {})
                }
            })
            .catch((msg: any) => { sessionStorage.clear(); this.router.navigate(['/login'], {}); });
    }
    async getReportsDaily() {
        await this.http.get('http://localhost:63058/api/backupstatus/daemon/' + sessionStorage.getItem('token') + '/DAILY').toPromise()
            .then((response: Response) => {
                let Reports = response.json();
                if (Reports && "OK" == Reports.Status) {
                    sessionStorage.setItem('Reports', JSON.stringify(Reports.Data));

                } else {
                    sessionStorage.clear();
                    this.router.navigate(['/login'], {})
                }
            })
            .catch((msg: any) => { sessionStorage.clear(); this.router.navigate(['/login'], {}); });
    }
    public async WriteReports(type: string) {
        if (type === 'MONTHLY')
            await this.getReportsMonthly();
        else if (type === 'WEEKLY')
            await this.getReportsWeekly();
        else if (type === 'DAILY')
            await this.getReportsDaily();

        var Reports = sessionStorage.getItem('Reports');
        if (Reports != null) {
            var data = JSON.parse(Reports);
            var info = data.Info;
        }

        var Status = '';
        var Datef = '';
        var Type = '';
        var Message = '';
        var Name = '';

        var Filtr = '';
        Filtr = (<HTMLInputElement>document.getElementById('filtrtext')).value;
        //var today = this.date;
        //var dd = today.getDate();
        //var mm = today.getMonth() + 1; //January is 0!
        //var yyyy = today.getFullYear();


        var count = data.ListBackupStatusNameData.length;
        this.reports = [];
        for (var n = 0; n < count; n++) {
            if (Filtr == '') {
                Status = data.ListBackupStatusNameData[n].backupStatus.Status
                Datef = data.ListBackupStatusNameData[n].backupStatus.TimeOfBackup
                Type = data.ListBackupStatusNameData[n].backupStatus.BackupType
                Message = data.ListBackupStatusNameData[n].backupStatus.FailMessage
                Name = data.ListBackupStatusNameData[n].Name
                this.reports.push({
                    Status: Status == "SUCCESS" ? require("./success.png") : require("./error.png"),
                    Date: new Date(Datef).toLocaleString(),
                    Type: Type == "FULL" ? "Full": Type == "DIFF" ? "Differential" : "Incremental",
                    Message: Message,
                    Name: Name
                });
                continue;
            }
            if (Filtr != '' && data.ListBackupStatusNameData[n].Name == Filtr) {
            Status = data.ListBackupStatusNameData[n].backupStatus.Status
            Datef = data.ListBackupStatusNameData[n].backupStatus.TimeOfBackup
            Type = data.ListBackupStatusNameData[n].backupStatus.BackupType
            Message = data.ListBackupStatusNameData[n].backupStatus.FailMessage
            Name = data.ListBackupStatusNameData[n].Name
            this.reports.push({
                Status: Status == "SUCCESS" ? require("./success.png") : require("./error.png"),
                Date: new Date(Datef).toLocaleString(),
                Type: Type == "FULL" ? "Full" : Type == "DIFF" ? "Differential" : "Incremental",
                Message: Message,
                Name:Name
            });
            }
            
        }
    }
}