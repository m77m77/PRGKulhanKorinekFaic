import { Component } from '@angular/core';
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
    name: string;
    daemons: any;
    defaultChanged: string;


    constructor(private http: Http, private router: Router, private route: ActivatedRoute) {
        this.route.params.subscribe(params => { if (typeof (window) !== 'undefined') { sessionStorage.setItem('daemonID', params.id); this.loadDaemon(); } });

        if (typeof window !== 'undefined') {
            if (sessionStorage.getItem('daemonsData') == null) {
                var headers = new Headers();
                headers.append('Content-Type', 'application/json');

                this.http.get('http://localhost:63058/api/admin/' + sessionStorage.getItem('token'), { headers: headers }).toPromise()
                    .then((response: Response) => {
                        let mailSettings = response.json();
                        if (mailSettings && "OK" == mailSettings.Status) {
                            sessionStorage.setItem('daemonsData', JSON.stringify(mailSettings.Data));
                            sessionStorage.setItem('daemonsUnsave', JSON.stringify([]));
                            this.loadDaemon();
                            //this.router.navigate(['../home'], { relativeTo: this.route })
                        } else {
                            sessionStorage.removeItem('token');
                            sessionStorage.removeItem('daemonsData');
                            sessionStorage.removeItem('daemonsUnsave');
                            sessionStorage.removeItem('mailData');
                            this.router.navigate(['/login'], {});
                        }
                    })
                    .catch((msg: any) => {
                        sessionStorage.removeItem('token');
                        sessionStorage.removeItem('daemonsData');
                        sessionStorage.removeItem('daemonsUnsave');
                        sessionStorage.removeItem('mailData');
                        this.router.navigate(['/login'], {});
                    })
            }

            //this.loadMailData();
        }

    }

    loadDaemon() {
        var daemonsData = sessionStorage.getItem('daemonsData');
        var unsaved = sessionStorage.getItem('daemonsUnsave');
        var daemonID = sessionStorage.getItem('daemonID');
        if (daemonsData != null && daemonID != null &&unsaved != null) {
            var data = JSON.parse(daemonsData);
            var unSavedData = JSON.parse(unsaved);
            var listDaemons = data.ListDaemons;

            try {
                if (daemonID == "default") {
                    (<HTMLElement>document.getElementById("dName")).style.display = 'none';
                } else {
                    (<HTMLElement>document.getElementById("dName")).style.display = 'block';
                    this.name = listDaemons[daemonID].DaemonName;
                }  
            } catch (e) {

            }

            if (unSavedData.indexOf('default') > -1) {
                this.defaultChanged = '*';
            } else {
                this.defaultChanged = '';
            }

            this.daemons = [];
            for (var i = 0; i < listDaemons.length; i++) {
                var daemon = listDaemons[i];
                var settingsCount = daemon.Settings.length;
                var settings = [];
                for (var k = 0; k < settingsCount; k++) {
                    settings.push({I: k, Route: '../' + i + '/' + k});
                }

                this.daemons.push({ Route: '../' + i, Name: daemon.DaemonName, Settings: settings, Changed: unSavedData.indexOf(''+i) > -1 ? '*' : ''});
            }

        }
    }

    saveDaemon() {
        var daemonsData = sessionStorage.getItem('daemonsData');
        var unsaved = sessionStorage.getItem('daemonsUnsave');
        var daemonID = sessionStorage.getItem('daemonID');
        if (daemonsData != null && daemonID != null && unsaved != null) {
            var data = JSON.parse(daemonsData);
            var unSavedData = JSON.parse(unsaved);
            var listDaemons = data.ListDaemons;

            try {
                if (daemonID == "default") {
                    
                } else {
                    listDaemons[daemonID].DaemonName = (<HTMLInputElement>document.getElementById("daemonName")).value;
                }
            } catch (e) {

            }

            if (unSavedData.indexOf(daemonID) <= -1) {
                unSavedData.push(daemonID);
            }

            sessionStorage.setItem('daemonsData', JSON.stringify(data));
            sessionStorage.setItem('daemonsUnsave', JSON.stringify(unSavedData));

            this.loadDaemon();
        }
    }

    sendDaemon() {
        var daemonsData = sessionStorage.getItem('daemonsData');
        var unsaved = sessionStorage.getItem('daemonsUnsave');
        var daemonID = sessionStorage.getItem('daemonID');
        if (daemonsData != null && daemonID != null && unsaved != null) {
            var data = JSON.parse(daemonsData);
            var unSavedData = JSON.parse(unsaved);
            var listDaemons = data.ListDaemons;

            try {
                var headers = new Headers();
                headers.append('Content-Type', 'application/json');

                if (daemonID == "default") {
                    this.http.post('http://localhost:63058/api/admin/system/' + sessionStorage.getItem('token'), { Name: 'defaultDaemonSettings', Value: JSON.stringify(data.DefaultSettings) }, { headers: headers }).toPromise()
                        .then((response: Response) => {
                            let mailSettings = response.json();
                            if (mailSettings && "OK" == mailSettings.Status) {

                            } else {
                                sessionStorage.removeItem('token');
                                sessionStorage.removeItem('daemonsData');
                                sessionStorage.removeItem('daemonsUnsave');
                                sessionStorage.removeItem('mailData');
                                this.router.navigate(['/login'], {});
                            }
                        })
                        .catch((msg: any) => {
                            sessionStorage.removeItem('token');
                            sessionStorage.removeItem('daemonsData');
                            sessionStorage.removeItem('daemonsUnsave');
                            sessionStorage.removeItem('mailData');
                            this.router.navigate(['/login'], {});
                        })
                } else {
                    var daemon = listDaemons[daemonID];

                    this.http.post('http://localhost:63058/api/admin/' + sessionStorage.getItem('token'),JSON.stringify(daemon), { headers: headers }).toPromise()
                        .then((response: Response) => {
                            let mailSettings = response.json();
                            if (mailSettings && "OK" == mailSettings.Status) {

                            } else {
                                sessionStorage.removeItem('token');
                                sessionStorage.removeItem('daemonsData');
                                sessionStorage.removeItem('daemonsUnsave');
                                sessionStorage.removeItem('mailData');
                                this.router.navigate(['/login'], {});
                            }
                        })
                        .catch((msg: any) => {
                            sessionStorage.removeItem('token');
                            sessionStorage.removeItem('daemonsData');
                            sessionStorage.removeItem('daemonsUnsave');
                            sessionStorage.removeItem('mailData');
                            this.router.navigate(['/login'], {});
                        })
                }
            } catch (e) {

            }

            if (unSavedData.indexOf(daemonID) > -1) {
                unSavedData.splice(unSavedData.indexOf(daemonID),1);
            }

            sessionStorage.setItem('daemonsUnsave', JSON.stringify(unSavedData));

            this.loadDaemon();
        }
    }

}