import { Component } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { NgModule, ElementRef } from '@angular/core';
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

    private elementRef: ElementRef
    private position: InsertPosition

    admins: any;

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
        this.http.get('http://localhost:63058/api/newadmin/' + sessionStorage.getItem('token')).toPromise()
            .then((response: Response) => {
                let AdminPost = response.json();
                console.log(AdminPost.Data);
                if (AdminPost && "OK" == AdminPost.Status) {
                    sessionStorage.setItem('AdminPost', JSON.stringify(AdminPost.Data));
                    this.WriteAdmins();

                    //this.router.navigate(['../home'], { relativeTo: this.route })
                } else {
                    sessionStorage.removeItem('token');
                    this.router.navigate(['/login'], {})
                }
            })
            .catch((msg: any) => { sessionStorage.removeItem('token'); this.router.navigate(['/login'], {}); })
    }
    private CheckAdmins() {
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

        //var type = sessionStorage.getItem('AdminInfo')

        if (username !== "" && password !== "" && password == cpassword) {
            this.CheckAdmins();
        }
    }



    private WriteAdmins() {
        this.position = "afterbegin";
        var htmlCode = '';
        var btnName = '';



        var AdminPost = sessionStorage.getItem('AdminPost');
        if (AdminPost != null) {
            var data = JSON.parse(AdminPost);
            var info = data.Info;
        }

        var count = data.ListAdmin.length;
        this.admins = [];
        for (var n = 0; n < count; n++) {
            btnName = data.ListAdmin[n].Name
            //htmlCode = htmlCode + '<p><button id="' + btnName + '" (click)="OpenAdminInfo("' + btnName + '")">' + btnName + '</button></p>';
            this.admins.push({
                Name: btnName
            });

        }


        //var div = document.createElement("div");
        //var d1 = (<HTMLInputElement>document.getElementById('code'))
        //div.className = "adminmenu";
        //div.innerHTML = htmlCode;
        //this.renderer.appendChild(d1,div);
    }
    public OpenAdminInfo(adminName: any) {
        sessionStorage.setItem('adminInfoName', adminName);
        this.router.navigate(['/home/adminmenu/admininfo'], {})
    }
    public Delete(adminName: any) {
        console.log(adminName + 'deleted')
    }

    }