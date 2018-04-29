import { Component } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';
import 'rxjs/add/operator/toPromise';

@Component({
    selector: 'defaultsettingsdatabase',
    templateUrl: './defaultsettingsdatabase.component.html',
    styleUrls: ['./defaultsettingsdatabase.component.css']


})
export class DefaultSettingsDatabaseComponent {

    name: string;
    daemons: any;
    defaultChanged: string;


    constructor(private http: Http, private router: Router, private route: ActivatedRoute) {
        this.route.params.subscribe(params => { if (typeof (window) !== 'undefined') { sessionStorage.setItem('daemonID', 'defaultdatabase'); sessionStorage.setItem('settingsID', 'defaultdatabase');} });

        if (typeof window !== 'undefined') {
            if (sessionStorage.getItem('daemonsData') == null) {
                this.getDaemons();
            }
        }

    }

    getDaemons() {
        var headers = new Headers();
        headers.append('Content-Type', 'application/json');

        this.http.get('http://localhost:63058/api/admin/' + sessionStorage.getItem('token'), { headers: headers }).toPromise()
            .then((response: Response) => {
                let mailSettings = response.json();
                if (mailSettings && "OK" == mailSettings.Status) {
                    sessionStorage.setItem('daemonsData', JSON.stringify(mailSettings.Data));
                    sessionStorage.setItem('daemonsUnsave', JSON.stringify([]));

                    

                    //this.router.navigate(['../home'], { relativeTo: this.route })
                } else {
                    sessionStorage.clear();
                    this.router.navigate(['/login'], {});
                }
            })
            .catch((msg: any) => {
                sessionStorage.clear();
                this.router.navigate(['/login'], {});
            })
    }

    sendDaemon() {
        var daemonsData = sessionStorage.getItem('daemonsData');
        var daemonID = sessionStorage.getItem('daemonID');
        if (daemonsData != null && daemonID != null) {
            var data = JSON.parse(daemonsData);
            var listDaemons = data.ListDaemons;

            try {
                var headers = new Headers();
                headers.append('Content-Type', 'application/json');
                this.http.post('http://localhost:63058/api/admin/system/' + sessionStorage.getItem('token'), { Name: 'defaultDaemonSettingsDatabase', Value: JSON.stringify(data.DefaultSettingsDatabase) }, { headers: headers }).toPromise()
                        .then((response: Response) => {
                            let mailSettings = response.json();
                            if (mailSettings && "OK" == mailSettings.Status) {

                            } else {
                                sessionStorage.clear();
                                this.router.navigate(['/login'], {});
                            }
                        })
                        .catch((msg: any) => {
                            sessionStorage.clear();
                            this.router.navigate(['/login'], {});
                        })
            } catch (e) {

            }
        }
    }
}