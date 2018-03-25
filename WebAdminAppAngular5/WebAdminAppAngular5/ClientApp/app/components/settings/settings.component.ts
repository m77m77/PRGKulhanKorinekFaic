import { Component } from '@angular/core';
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
    id: string;

    constructor(private http: Http, private router: Router, private route: ActivatedRoute) {
        this.route.params.subscribe(params => this.id = params.settingsID);
    }
}