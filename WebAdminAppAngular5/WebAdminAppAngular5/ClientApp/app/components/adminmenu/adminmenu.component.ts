import { Component } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { NgModule, ElementRef, Renderer2 } from '@angular/core';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';
import 'rxjs/add/operator/toPromise';
import { NgForOf } from '@angular/common';

@Component({
    selector: 'adminmenu',
    templateUrl: './adminmenu.component.html',
    styleUrls: ['./adminmenu.component.css']


})
export class AdminMenuComponent {
    private elementRef: ElementRef
    private position: InsertPosition

    admins: any;

    constructor(private renderer: Renderer2, private http: Http, private router: Router, private route: ActivatedRoute) {
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
                Name: btnName == btnName
            });
        }

        //var div = document.createElement("div");
        //var d1 = (<HTMLInputElement>document.getElementById('code'))
        //div.className = "adminmenu";
        //div.innerHTML = htmlCode;
        //this.renderer.appendChild(d1,div);
    }
    public OpenAdminInfo(adminName: string) {
        sessionStorage.setItem('adminInfoName', adminName);
        this.router.navigate(['/home/adminmenu/admininfo'], {})
    }
}