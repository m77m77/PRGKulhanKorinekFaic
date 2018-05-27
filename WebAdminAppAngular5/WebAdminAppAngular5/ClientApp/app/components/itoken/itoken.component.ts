﻿import { Component } from '@angular/core';
import { Http, Headers, Response, ResponseContentType, RequestOptions } from '@angular/http';
import { NgModule, ElementRef, Renderer2 } from '@angular/core';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';
import 'rxjs/add/operator/toPromise';
import { NgForOf } from '@angular/common';
import { Observable } from 'rxjs/Observable';
//import { ClipboardModule } from 'ngx-clipboard';
import 'rxjs/add/operator/map';

import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import 'file-saver';

@Component({
    selector: 'itoken',
    templateUrl: './itoken.component.html',
    styleUrls: ['./itoken.component.css']


})
export class ITokenComponent {
    itokens: any;
    lastitoken: string;
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
        var iditoken = '';
        var Expiration = '';

        var count = data.ListInicializationToken.length;
        this.itokens = [];

        for (var n = 0; n < count; n++) {
            itoken = data.ListInicializationToken[n].Token;
            iditoken = data.ListInicializationToken[n].Id;
            Expiration = data.ListInicializationToken[n].Expiration;

            this.itokens.push({
                Token: itoken,
                Id: iditoken,
                Expiration: Expiration,
            });
        }
    }
    async AddNewIToken() {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
        await this.http.post('http://localhost:63058/api/newinitializationtoken/' + sessionStorage.getItem('token'), { headers: headers }).toPromise()
            .then((response: Response) => {
                let InitializationTokens = response.json();
                if (InitializationTokens && "OK" == InitializationTokens.Status) {
                    this.LoadITokens();
                    this.WriteITokens();
                    this.lastitoken = InitializationTokens.NewToken;
                    //sessionStorage.setItem('lastitoken', InitializationTokens.NewToken)
                    window.prompt('New initialization token', InitializationTokens.NewToken )
                } else {
                    sessionStorage.clear();
                    this.router.navigate(['/login'], {})
                }
            })
            .catch((msg: any) => { sessionStorage.clear(); this.router.navigate(['/login'], {}) })
        /*********************************************************/
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
        this.http.post('http://localhost:63058/api/xmlfile/' + sessionStorage.getItem('token') + '/' + this.lastitoken, { headers: headers }).toPromise()
            .then((response: Response) => {
                let InitializationTokens = response.json();
                if (InitializationTokens && "OK" == InitializationTokens.Status) {
                } else {
                    sessionStorage.clear();
                    this.router.navigate(['/login'], {})
                }
            })
            .catch((msg: any) => { sessionStorage.clear(); this.router.navigate(['/login'], {}) })
    }
    public DeleteToken(iditoken:any) {
        if (window.confirm('Are you sure you want to delete this initialization token') == true) {
            this.http.delete('http://localhost:63058/api/newinitializationtoken/' + sessionStorage.getItem('token') + '/' + iditoken).toPromise()
                .then((response: Response) => {
                    let DelResponse = response.json();
                    if (DelResponse && "OK" == DelResponse.Status) {
                        this.LoadITokens()
                    } else {
                        sessionStorage.clear();
                        this.router.navigate(['/login'], {})
                    }
                })
                .catch((msg: any) => { sessionStorage.clear(); this.router.navigate(['/login'], {}) })
        } 
    }
    copyTextToClipboard(itoken:string) {
        var txtArea = document.createElement("textarea");

        txtArea.style.position = 'fixed';
        txtArea.style.top = '0';
        txtArea.style.left = '0';
        txtArea.style.opacity = '0';
        txtArea.value = itoken;
        document.body.appendChild(txtArea);
        txtArea.select();
        try {
            var successful = document.execCommand('copy');
            var msg = successful ? 'successful' : 'unsuccessful';
            if (successful) {
                return true;
            }
        } catch (err) {
        }
        document.body.removeChild(txtArea);
        return false;
    }

    public downloadfile2(runname: string, type: string) {
        var headers = new Headers();
        headers.append('responseType', 'arraybuffer');
        return this.http.get('http://localhost:63058/api/xmlfile/' + sessionStorage.getItem('token') + '/' + 'N5AMXxowC1q08dzxDIqnj9c-VtALlCvG')
            .map(response => new Blob([response.json().Data.XMLConfig], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' }))
        
    }

    downloadfile(type: string) {
        var reader = new FileReader();
        this.downloadfile2('pes', 'xml')
            .subscribe(res => reader.readAsDataURL(res),
            error => console.log("Error downloading the file."),
            () => console.log('Completed file download.'));

        reader.onloadend = function (e) {
            window.open(reader.result, 'xml', 'width=20,height=10,toolbar=0,menubar=0,scrollbars=no');
        }
    }
}