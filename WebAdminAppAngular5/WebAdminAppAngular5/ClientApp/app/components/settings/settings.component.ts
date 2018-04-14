import { Component,Input } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { NgModule, EventEmitter, OnInit, Output } from '@angular/core';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';
import 'rxjs/add/operator/toPromise';

@Component({
    selector: 'settings',
    templateUrl: './settings.component.html',
    styleUrls: ['./settings.component.css']


})


export class SettingsComponent{
    constructor(private http: Http, private router: Router, private route: ActivatedRoute) {
        this.route.params.subscribe(params => { if (typeof (window) !== 'undefined') { sessionStorage.setItem('settingsID', params.settingsID); }});
    }

    public DeleteSettings() {
        var daemonsData = sessionStorage.getItem('daemonsData');
        var daemonID = sessionStorage.getItem('daemonID');
        var settingsrow = sessionStorage.getItem('settingsID');
        var SettingsID;

        if (daemonsData != null && daemonID != null && settingsrow != null) {
            var data = JSON.parse(daemonsData);
            var listDaemons = data.ListDaemons;
            SettingsID = listDaemons[daemonID].Settings[settingsrow].SettingsID;
        }

        if (SettingsID != 'default'){
            this.http.delete('http://localhost:63058/api/newsettings/delete/' + sessionStorage.getItem('token') + '/' + SettingsID).toPromise()
            .catch((msg: any) => { sessionStorage.clear(); this.router.navigate(['/login'], {}) })
            window.location.reload();
        }
    }
}