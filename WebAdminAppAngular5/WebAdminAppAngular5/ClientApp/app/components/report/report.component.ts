﻿import { Component } from '@angular/core';
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
        var Date = '';
        var Type = '';
        var Message = '';

        var count = data.ListDaemonBackupInfo.length;
        this.reports = [];
        for (var n = 0; n < count; n++) {
            Status = data.ListDaemonBackupInfo[n].Status
            Date = data.ListDaemonBackupInfo[n].TimeOfBackup
            Type = data.ListDaemonBackupInfo[n].BackupType
            Message = data.ListDaemonBackupInfo[n].backupStatus
            this.reports.push({
                Status: Status,
                Date: Date,
                Type: Type,
                Message: Message,
            });
        }
    }
}