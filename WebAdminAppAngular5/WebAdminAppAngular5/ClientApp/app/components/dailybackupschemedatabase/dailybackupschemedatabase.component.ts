﻿import { Component,Renderer2 } from '@angular/core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'dailybackupschemedatabase',
    templateUrl: './dailybackupschemedatabase.component.html',
    styleUrls: ['./dailybackupschemedatabase.component.css']


})
export class DailybackupschemeDatabaseComponent {
    backups: any;
    keepBackups: number;


    constructor(private renderer: Renderer2, private router: Router, private route: ActivatedRoute) {
        var parent = this.route.parent;
        if (parent != null)
            parent.params.subscribe(params => { if (typeof (window) !== 'undefined') { this.loadDaily(); } });
    }

    loadDaily() {
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
                    settings = data.DefaultSettingsDatabase;
                } else {
                    settings = listDaemons[daemonID].SettingsDatabase[settingsID];
                }

                if (settings.BackupScheme.Type != 'DAILY') {
                    settings.BackupScheme = { Type: 'DAILY', MaxBackups: settings.BackupScheme.MaxBackups, OneTimeBackup: null, BackupTimes: [] }

                    if (unSavedData.indexOf(daemonID) <= -1) {
                        unSavedData.push(daemonID);
                    }

                    sessionStorage.setItem('daemonsUnsave', JSON.stringify(unSavedData));
                    sessionStorage.setItem('daemonsData', JSON.stringify(data));
                }

                this.keepBackups = settings.BackupScheme.MaxBackups;

                var bcTimes = settings.BackupScheme.BackupTimes;

                this.backups = [];

                for (var i = 0; i < bcTimes.length; i++) {
                    var bcTime = bcTimes[i];

                    this.backups.push({
                        Time: bcTime.Time,
                    });
                }

            } catch (e) {

            }


        }
    }

    saveDaily() {
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
                    settings = data.DefaultSettingsDatabase;
                } else {
                    settings = listDaemons[daemonID].SettingsDatabase[settingsID];
                }

                settings.BackupScheme.MaxBackups = +(<HTMLInputElement>document.getElementById('idnumberbackups')).value;

                var elements = (<HTMLDivElement>document.getElementById('dailyScheme')).querySelectorAll('div.dailyOneBackup');

                settings.BackupScheme.BackupTimes = [];

                for (var i = 0; i < elements.length; i++) {
                    var el = elements[i];
                    var timeInput = <HTMLInputElement>el.querySelector('input.time');
                    
                    settings.BackupScheme.BackupTimes.push({
                        Time: timeInput.value,
                        DayNumber: 0
                    });
                }

                if (unSavedData.indexOf(daemonID) <= -1) {
                    unSavedData.push(daemonID);
                }

                sessionStorage.setItem('daemonsUnsave', JSON.stringify(unSavedData));
                sessionStorage.setItem('daemonsData', JSON.stringify(data));

            } catch (e) {

            }


        }
    }

    validate() {
        var backups = <HTMLDivElement>document.getElementById("dailyScheme");

        var elements = backups.querySelectorAll('div.dailyOneBackup');

        var first = null;

        for (var i = 0; i < elements.length; i++) {
            var el = elements[i];
            var timeInput = <HTMLInputElement>el.querySelector('input.time');
            timeInput.parentNode
            if (first == null) {
                first = timeInput;
            } else {
                if (timeInput.value < first.value)
                    first = timeInput;
            }

        }
    }

    addBackup() {
        var backups = <HTMLDivElement>document.getElementById("dailyScheme");

        var newBackup = this.renderer.createElement('div');
        newBackup.className = 'dailyOneBackup';

        var br1 = this.renderer.createElement('br');
        var br2 = this.renderer.createElement('br');

        var input = this.renderer.createElement('input');
        input.type = 'time';
        input.className = 'time';
        input.value = '00:00'
        input.required = true;


        var button = this.renderer.createElement('button');
        button.className = 'btnRemove';
        button.innerHTML = '-';
            

        this.renderer.listen(button, 'click', (evn) => this.deleteBackup(evn));
        this.renderer.listen(input, 'change', (evn) => { this.validate(); this.saveDaily(); });

        this.renderer.appendChild(newBackup, input);
        this.renderer.appendChild(newBackup, br1);
        this.renderer.appendChild(newBackup, br2);
        this.renderer.appendChild(newBackup, button);


        this.renderer.appendChild(backups, newBackup);

        this.validate();
        this.saveDaily();
    }

    deleteBackup(event : any) {
        var target = event.target || event.srcElement || event.currentTarget;

        var backups = <HTMLDivElement>document.getElementById("dailyScheme");

        this.renderer.removeChild(backups, target.parentNode);

        this.validate();
        this.saveDaily();
    }
}