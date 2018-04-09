import { Component,Input } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';
import 'rxjs/add/operator/toPromise';

@Component({
    selector: 'settings',
    templateUrl: './settings.component.html',
    styleUrls: ['./settings.component.css']


})
export class SettingsComponent {
    constructor(private http: Http, private router: Router, private route: ActivatedRoute) {
        this.route.params.subscribe(params => { if (typeof (window) !== 'undefined') { sessionStorage.setItem('settingsID', params.settingsID); }});
    }
    public DeleteSettings() {
        var SettingsID = sessionStorage.getItem('settingsID');
        if (SettingsID != 'default'){
            this.http.delete('http://localhost:63058/api/newsettings/delete/' + sessionStorage.getItem('token') + '/' + SettingsID).toPromise()
            .catch((msg: any) => { sessionStorage.removeItem('token'); this.router.navigate(['/login'], {}) })
            window.location.reload();
            console.log('deleted' + SettingsID)
        }
        
    }
}