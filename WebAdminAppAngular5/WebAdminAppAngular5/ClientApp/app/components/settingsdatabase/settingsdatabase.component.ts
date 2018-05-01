import { Component,Input } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { NgModule, EventEmitter, OnInit, Output } from '@angular/core';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';
import 'rxjs/add/operator/toPromise';

@Component({
    selector: 'settingsdatabase',
    templateUrl: './settingsdatabase.component.html',
    styleUrls: ['./settingsdatabase.component.css']


})


export class SettingsDatabaseComponent{
    display: string;
    
    constructor(private http: Http, private router: Router, private route: ActivatedRoute) {
        sessionStorage.setItem('SettingsType', 'database')
        this.route.params.subscribe(params => { if (typeof (window) !== 'undefined') { this.display = 'display:none'; sessionStorage.setItem('settingsID', params.settingsID); } });
        
    }
}