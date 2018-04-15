import { Component } from '@angular/core';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'onetimebackupscheme',
    templateUrl: './onetimebackupscheme.component.html',
    styleUrls: ['./onetimebackupscheme.component.css']


})
export class OnetimebackupschemeComponent {
    when: string;

    constructor(private router: Router, private route: ActivatedRoute) {
        var parent = this.route.parent;
        if (parent != null)
            parent.params.subscribe(params => { if (typeof (window) !== 'undefined') { this.loadOneTime(); } });
    }

    loadOneTime() {
        var daemonsData = sessionStorage.getItem('daemonsData');
        var unsaved = sessionStorage.getItem('daemonsUnsave');
        var daemonID = sessionStorage.getItem('daemonID');
        var settingsID = sessionStorage.getItem('settingsID');
        if (daemonsData != null && daemonID != null && settingsID != null && unsaved != null) {
            var data = JSON.parse(daemonsData);
            var unSavedData = JSON.parse(unsaved);
            var listDaemons = data.ListDaemons;

            try {
                var settings = null;
                if (daemonID == "default") {
                    settings = data.DefaultSettings;
                } else {
                    settings = listDaemons[daemonID].Settings[settingsID];
                }



                if (settings.BackupScheme.Type != 'ONE_TIME') {
                    var currDate = new Date();
                    var mon = (currDate.getMonth() >= 10 ? currDate.getMonth() : '0' + currDate.getMonth()); 
                    var day = (currDate.getDate() >= 10 ? currDate.getDate() : '0' + currDate.getDate());
                    var hour = (currDate.getHours() >= 10 ? currDate.getHours() : '0' + currDate.getHours()); 
                    var min = (currDate.getMinutes() >= 10 ? currDate.getMinutes() : '0' + currDate.getMinutes());
                    settings.BackupScheme = { Type: 'ONE_TIME', MaxBackups: 0, OneTimeBackup: { When: currDate.getFullYear() + '-' + mon + '-' + day + 'T' + hour + ':' + min }, BackupTimes: [] }

                    if (unSavedData.indexOf(daemonID) <= -1) {
                        unSavedData.push(daemonID);
                    }

                    sessionStorage.setItem('daemonsUnsave', JSON.stringify(unSavedData));
                    sessionStorage.setItem('daemonsData', JSON.stringify(data));
                }

                this.when = settings.BackupScheme.OneTimeBackup.When.split('.')[0];
            } catch (e) {

            }


        }
    }

    saveOneTime() {
        var daemonsData = sessionStorage.getItem('daemonsData');
        var unsaved = sessionStorage.getItem('daemonsUnsave');
        var daemonID = sessionStorage.getItem('daemonID');
        var settingsID = sessionStorage.getItem('settingsID');
        if (daemonsData != null && daemonID != null && settingsID != null && unsaved != null) {
            var data = JSON.parse(daemonsData);
            var unSavedData = JSON.parse(unsaved);
            var listDaemons = data.ListDaemons;

            try {
                var settings = null;
                if (daemonID == "default") {
                    settings = data.DefaultSettings;
                } else {
                    settings = listDaemons[daemonID].Settings[settingsID];
                }

                settings.BackupScheme.OneTimeBackup.When = (<HTMLInputElement>document.getElementById('oneTimeWhen')).value;

                if (unSavedData.indexOf(daemonID) <= -1) {
                    unSavedData.push(daemonID);
                }

                sessionStorage.setItem('daemonsUnsave', JSON.stringify(unSavedData));
                sessionStorage.setItem('daemonsData', JSON.stringify(data));

            } catch (e) {

            }


        }
    }
}
