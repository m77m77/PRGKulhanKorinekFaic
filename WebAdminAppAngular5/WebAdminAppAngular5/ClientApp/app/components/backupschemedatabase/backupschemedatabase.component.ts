import { Component } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'backupschemedatabase',
    templateUrl: './backupschemedatabase.component.html',
    styleUrls: ['./backupschemedatabase.component.css']


})
export class BackupschemeDatabaseComponent {
    constructor(private http: Http, private router: Router, private route: ActivatedRoute) {
        var parent = this.route.parent;
        if (parent != null)
            parent.params.subscribe(params => { if (typeof (window) !== 'undefined') { this.loadScheme(); } });
    }

    loadScheme() {
        var daemonsData = sessionStorage.getItem('daemonsData');
        var daemonID = sessionStorage.getItem('daemonID');
        var settingsID = sessionStorage.getItem('settingsID')
        if (daemonsData != null && daemonID != null && settingsID != null) {
            var data = JSON.parse(daemonsData);
            var listDaemons = data.ListDaemons;

            try {
                var settings = null;
                if (daemonID == "default") {
                    settings = data.DefaultSettings;
                } else {
                    settings = listDaemons[daemonID].Settings[settingsID];
                }

                var schemeType = settings.BackupScheme.Type;

                if (schemeType == 'ONE_TIME') {
                    this.router.navigate(['onetime'], { relativeTo: this.route })
                } else if (schemeType == 'DAILY') {
                    this.router.navigate(['daily'], { relativeTo: this.route })
                } else if (schemeType == 'WEEKLY') {
                    this.router.navigate(['weekly'], { relativeTo: this.route })
                } else if (schemeType == 'MONTHLY') {
                    this.router.navigate(['monthly'], { relativeTo: this.route })
                }
            } catch (e) {

            }

            
        }
    }
}
