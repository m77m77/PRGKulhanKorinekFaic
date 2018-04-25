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
    settings: any;
    daemonID: string;
    defaultChanged: string;


    constructor(private http: Http, private router: Router, private route: ActivatedRoute) {
        this.route.params.subscribe(params => { if (typeof (window) !== 'undefined') { sessionStorage.setItem('daemonID', params.id); this.loadDaemon(); } });

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
                    this.loadDaemon();
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
                    if (document.getElementById('dName') != null)
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

                if (i+'' == daemonID) {
                    this.daemonID = daemon.DaemonID;
                    this.settings = []
                    for (var k = 0; k < daemon.Settings.length; k++) {
                        this.settings.push({ I: k, Route: '../' + i + '/file/' + k });
                    }
                }
                

                this.daemons.push({
                    Route: '../' + i, Name: daemon.DaemonName, Id: daemon.DaemonID, Changed: unSavedData.indexOf(''+i) > -1 ? ' * ' : ''});
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
                                sessionStorage.clear();
                                this.router.navigate(['/login'], {});
                            }
                        })
                        .catch((msg: any) => {
                            sessionStorage.clear();
                            this.router.navigate(['/login'], {});
                        })
                } else {
                    var daemon = listDaemons[daemonID];

                    this.http.post('http://localhost:63058/api/admin/' + sessionStorage.getItem('token'),JSON.stringify(daemon), { headers: headers }).toPromise()
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
    public PostNewSettings(DaemonID:string) {

        var headers = new Headers();
        headers.append('Content-Type', 'application/json');
        this.http.post('http://localhost:63058/api/newsettings/' + sessionStorage.getItem('token'), { "DaemonID": DaemonID, "DaemonName": null, "Settings": null }, { headers: headers }).toPromise()
            .then((response: Response) => {
                let NewSettings = response.json();
                if (NewSettings && "OK" == NewSettings.Status) {
                    this.getDaemons();
                } else {
                    sessionStorage.clear();
                    this.router.navigate(['/login'], {})
                }
            })
            .catch((msg: any) => { sessionStorage.clear(); this.router.navigate(['/login'], {}) })
        
    }
    
    public DeleteSettings() {
        var daemonsData = sessionStorage.getItem('daemonsData');
        var daemonID = sessionStorage.getItem('daemonID');
        var settingsrow = sessionStorage.getItem('settingsID');
        var SettingsID;

        if (daemonsData != null && daemonID != null && settingsrow != null) {
            var data = JSON.parse(daemonsData);
            var listDaemons = data.ListDaemons;
            SettingsID = listDaemons[daemonID].Settings[settingsrow].SettingsID;
        }

        if (SettingsID != 'default') {
            this.http.delete('http://localhost:63058/api/newsettings/delete/' + sessionStorage.getItem('token') + '/' + SettingsID).toPromise()
                .then((response: Response) => {
                    let res = response.json();
                    if (res && "OK" == res.Status) {
                        this.getDaemons();
                    } else {
                        sessionStorage.clear();
                        this.router.navigate(['/login'], {})
                    }
                })
                .catch((msg: any) => { sessionStorage.clear(); this.router.navigate(['/login'], {}) })
        }
    }

}