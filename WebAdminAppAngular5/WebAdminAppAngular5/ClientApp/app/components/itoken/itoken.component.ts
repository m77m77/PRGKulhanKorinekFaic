import { Component } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { NgModule, ElementRef, Renderer2 } from '@angular/core';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';
import 'rxjs/add/operator/toPromise';
import { NgForOf } from '@angular/common';

@Component({
    selector: 'itoken',
    templateUrl: './itoken.component.html',
    styleUrls: ['./itoken.component.css']


})
export class ITokenComponent {
    itokens: any;
    constructor(private http: Http, private router: Router, private route: ActivatedRoute) {
        if (typeof window !== 'undefined') {
            this.LoadITokens();
        }
    }
    LoadITokens() {
            this.http.get('http://localhost:63058/api/newinitializationtoken/' + sessionStorage.getItem('token')).toPromise()
                .then((response: Response) => {
                    let InitializationTokens = response.json();
                    console.log(InitializationTokens.Data);
                    if (InitializationTokens && "OK" == InitializationTokens.Status) {
                        sessionStorage.setItem('InitializationTokens', JSON.stringify(InitializationTokens.Data));
                        this.WriteITokens();
                    } else {
                        sessionStorage.clear();
                        this.router.navigate(['/login'], {})
                    }
                })
                .catch((msg: any) => { sessionStorage.clear(); this.router.navigate(['/login'], {}); })
    }
    WriteITokens() {
        var InitializationTokens = sessionStorage.getItem('InitializationTokens');
        if (InitializationTokens != null) {
            var data = JSON.parse(InitializationTokens);
            var info = data.Info;
        }
        var itoken = '';

        var count = data.ListInicializationToken.length;
        this.itokens = [];

        for (var n = 0; n < count; n++) {
            itoken = data.ListInicializationToken[n].Token
            this.itokens.push({
                Token: itoken,
            });
        }
    }
    AddNewIToken() {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
        this.http.post('http://localhost:63058/api/newinitializationtoken/' + sessionStorage.getItem('token'), { headers: headers }).toPromise()
            .then((response: Response) => {
                let InitializationTokens = response.json();
                if (InitializationTokens && "OK" == InitializationTokens.Status) {
                    this.LoadITokens();
                    this.WriteITokens();
                } else {
                    sessionStorage.clear();
                    this.router.navigate(['/login'], {})
                }
            })
            .catch((msg: any) => { sessionStorage.removeItem('token'); this.router.navigate(['/login'], {}) })
    }
}