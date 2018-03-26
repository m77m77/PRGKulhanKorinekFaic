import { Component,Input } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';
import 'rxjs/add/operator/toPromise';

@Component({
    selector: 'settings',
    templateUrl: './settings.component.html',
    styleUrls: ['./settings.component.css']


})
export class SettingsComponent {
    constructor(private http: Http, private router: Router, private route: ActivatedRoute) {
        this.route.params.subscribe(params => { if (typeof (window) !== 'undefined') { sessionStorage.setItem('settingsID', params.settingsID); console.log("DAEMONID: " + sessionStorage.getItem('daemonID') + " SETTINGSID:" + sessionStorage.getItem('settingsID')) }});
    }
}