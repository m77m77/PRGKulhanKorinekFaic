import { Component } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { NgModule, ElementRef, Renderer2 } from '@angular/core';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';
import 'rxjs/add/operator/toPromise';

@Component({
    selector: 'admininfo',
    templateUrl: './admininfo.component.html',
    styleUrls: ['./admininfo.component.css']


})
export class AdminInfoComponent {
    private Write() {

        var name = sessionStorage.getItem('adminInfoName');
        if (name !== null) {
            (<HTMLInputElement>document.getElementById('name')).value = name;
            (<HTMLInputElement>document.getElementById('password')).value = "";
            (<HTMLInputElement>document.getElementById('type')).value = "";
        }
    }
}