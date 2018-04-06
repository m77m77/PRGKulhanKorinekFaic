import { Component } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
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
                        this.WriteAdmins();

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
                        window.location.reload();
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
        var btnType = '';



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
            this.admins.push({
                Name: btnName,
                Type: btnType
            });

        }
    }
    public Delete(adminName: any) {
        this.http.delete('http://localhost:63058/api/newadmin/delete/' + sessionStorage.getItem('token') + '/' + adminName).toPromise()
            .catch((msg: any) => { sessionStorage.removeItem('token'); this.router.navigate(['/login'], {}) })
        window.location.reload();
        
    }

    }