﻿import { Component } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { NgModule, ElementRef } from '@angular/core';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';
import 'rxjs/add/operator/toPromise';
import { useAnimation } from '@angular/core/src/animation/dsl';

@Component({
    selector: 'register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css']


})
export class RegisterComponent {
    Name: string;
    Password: string;

    private elementRef: ElementRef
    private position: InsertPosition

    admins: any;

    constructor(private http: Http, private router: Router, private route: ActivatedRoute) {
        if (typeof window !== 'undefined') {

            //if (sessionStorage.getItem('AdminPost') != null) {
            this.getAdmins();
            //}
            //this.WriteAdmins();
        }
    }

    getAdmins() {
        this.http.get('http://localhost:63058/api/newadmin/' + sessionStorage.getItem('token')).toPromise()
            .then((response: Response) => {
                let AdminPost = response.json();
                if (AdminPost && "OK" == AdminPost.Status) {
                    sessionStorage.setItem('AdminPost', JSON.stringify(AdminPost.Data));

                    this.WriteAdmins();
                    //this.WriteAdmins();

                    //this.router.navigate(['../home'], { relativeTo: this.route })
                } else {
                    sessionStorage.clear();
                    this.router.navigate(['/login'], {})
                }
            })
            .catch((msg: any) => { sessionStorage.clear(); this.router.navigate(['/login'], {}); });
    }

    private CheckAdmins() {
        this.getAdmins();
        var AdminPost = sessionStorage.getItem('AdminPost');
        var username = (<HTMLInputElement>document.getElementById('username')).value;
        if (AdminPost != null) {
            var data = JSON.parse(AdminPost);
            var info = data.Info;

        }

        var ok = true;
        var count = data.ListAdmin.length;

        for (var n = 0; n < count; n++) {
            if (username == data.ListAdmin[n].Name) {
                ok = false;
            }
        }

        if (ok == true) {
            this.PostNewAdmin();
        }

    }
    private PostNewAdmin() {
        if (sessionStorage.getItem('AdminInfo') !== '"master"') {
            window.alert('You are not allowed to create admin!')
            return;
        }
        var username = (<HTMLInputElement>document.getElementById('username')).value;
        var password = (<HTMLInputElement>document.getElementById('password')).value;
        var typeSelect = (<HTMLSelectElement>document.getElementById('type'));
        var type = typeSelect.options[typeSelect.selectedIndex].value;

        var AdminPost = sessionStorage.getItem('AdminPost');

        if (AdminPost != null) {
            var data = JSON.parse(AdminPost);
            var settings = data.Settings;

            var headers = new Headers();
            headers.append('Content-Type', 'application/json');

            this.http.post('http://localhost:63058/api/newadmin/' + sessionStorage.getItem('token'), { "Name": username, "Password": password, "Type": type }, { headers: headers }).toPromise()
                .then((response: Response) => {
                    let AdminPost = response.json();
                    console.log(AdminPost);
                    if (AdminPost && "OK" == AdminPost.Status) {
                        this.getAdmins();
                        //this.router.navigate(['../home'], { relativeTo: this.route })
                    } else {
                        sessionStorage.clear();
                        this.router.navigate(['/login'], {})
                    }
                })
                .catch((msg: any) => { sessionStorage.clear(); this.router.navigate(['/login'], {}) })
        }
    }

    public Validation() {
        this.getAdmins();
        var username = (<HTMLInputElement>document.getElementById('username'));
        var password = (<HTMLInputElement>document.getElementById('password'));
        var cpassword = (<HTMLInputElement>document.getElementById('cpassword'));

        //var type = sessionStorage.getItem('AdminInfo')

        if (username.value !== "" && password.value !== "" && password.value == cpassword.value) {
            this.CheckAdmins();
        }

        username.value = "";
        password.value = "";
        cpassword.value = "";
    }



    private WriteAdmins() {
        this.getAdmins();
        this.position = "afterbegin";
        var htmlCode = '';
        var btnName = '';
        var btnType = '';
        var btnId = '';


        var AdminPost = sessionStorage.getItem('AdminPost');
        if (AdminPost != null) {
            var data = JSON.parse(AdminPost);
            var info = data.Info;
        }

        var count = data.ListAdmin.length;
        this.admins = [];
        for (var n = 0; n < count; n++) {
            btnName = data.ListAdmin[n].Name
            btnType = data.ListAdmin[n].Type
            btnId = data.ListAdmin[n].Id
            this.admins.push({
                Name: btnName,
                Type: btnType,
                Id: btnId
            });

        }
    }
    public Delete(adminId: any) {
        if (sessionStorage.getItem('AdminInfo') !== '"master"') {
            window.alert('You are not allowed to delete admin!')
            return;
        }
            if (window.confirm('Are you sure you want to delete this admin') == true) {
                this.http.delete('http://localhost:63058/api/newadmin/delete/' + sessionStorage.getItem('token') + '/' + adminId).toPromise()
                    .then((response: Response) => {
                        let DelResponse = response.json();
                        if (DelResponse && "OK" == DelResponse.Status) {
                            this.getAdmins();
                        } else {
                            sessionStorage.clear();
                            this.router.navigate(['/login'], {})
                        }
                    })
                    .catch((msg: any) => { sessionStorage.clear(); this.router.navigate(['/login'], {}) })
            }
    }
}


            
        
