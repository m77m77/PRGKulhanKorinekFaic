﻿import { Component } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';
import 'rxjs/add/operator/toPromise';

@Component({
    selector: 'register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css']


})
export class RegisterComponent {
    Name: string;
    Password: string;

    constructor(private http: Http, private router: Router, private route: ActivatedRoute) {
        if (typeof window !== 'undefined') {

            this.http.get('http://localhost:63058/api/newadmin/' + sessionStorage.getItem('token')).toPromise()
                    .then((response: Response) => {
                        let AdminPost = response.json();
                        console.log(AdminPost.Data);
                        if (AdminPost && "OK" == AdminPost.Status) {
                            sessionStorage.setItem('AdminPost', JSON.stringify(AdminPost.Data));
                            //this.router.navigate(['../home'], { relativeTo: this.route })
                        } else {
                            sessionStorage.removeItem('token');
                            this.router.navigate(['/login'], {})
                        }
                    })
                    .catch((msg: any) => { sessionStorage.removeItem('token'); this.router.navigate(['/login'], {}); })
            }
    }
    private CheckAdmins() {
        var AdminPost = sessionStorage.getItem('AdminPost');
        var username = (<HTMLInputElement>document.getElementById('username')).value;
        if (AdminPost != null) {
            var data = JSON.parse(AdminPost);
            var info = data.Info;

        }
        var ok = true;

        //var count = 0;
        //for (var Name in data) {
        //    if (data[count] == username) {
        //        ok = false;
        //    }
        //    count++;
        //}

        if (ok = true) {
            this.PostNewAdmin();
        }

    }
    private PostNewAdmin() {
        var username = (<HTMLInputElement>document.getElementById('username')).value;
        var password = (<HTMLInputElement>document.getElementById('password')).value;

        var AdminPost = sessionStorage.getItem('AdminPost');

        if (AdminPost != null) {
            var data = JSON.parse(AdminPost);
            var settings = data.Settings;

            var headers = new Headers();
            headers.append('Content-Type', 'application/json');
            this.http.post('http://localhost:63058/api/newadmin/' + sessionStorage.getItem('token'), {"Name": username, "Password": password}, { headers: headers }).toPromise()
                .then((response: Response) => {
                    let AdminPost = response.json();
                    console.log(AdminPost);
                    if (AdminPost && "OK" == AdminPost.Status) {
                        this.router.navigate(['/home'], {})
                        //this.router.navigate(['../home'], { relativeTo: this.route })
                    } else {
                        sessionStorage.removeItem('token');
                        this.router.navigate(['/login'], {})
                    }
                })
                .catch((msg: any) => { sessionStorage.removeItem('token'); this.router.navigate(['/login'], {}) })
        }

    }
    public Validation() {
        var username = (<HTMLInputElement>document.getElementById('username')).value;
        var password = (<HTMLInputElement>document.getElementById('password')).value;
        var cpassword = (<HTMLInputElement>document.getElementById('cpassword')).value;

        if (username !== "" && password !== "" && password == cpassword) {
            this.CheckAdmins();
        }
    }

    }