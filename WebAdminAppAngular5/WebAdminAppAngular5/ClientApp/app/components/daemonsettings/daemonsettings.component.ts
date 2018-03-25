﻿import { Component } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';
import 'rxjs/add/operator/toPromise';

@Component({
    selector: 'daemonsettings',
    templateUrl: './daemonsettings.component.html',
    styleUrls: ['./daemonsettings.component.css']


})
export class DaemonsettingsComponent {
    id: string;

    constructor(private http: Http, private router: Router, private route: ActivatedRoute) {
        this.route.params.subscribe(params => this.id = params.id);
    }

}