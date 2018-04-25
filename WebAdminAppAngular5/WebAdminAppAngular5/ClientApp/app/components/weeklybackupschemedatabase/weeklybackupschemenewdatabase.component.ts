import { Component, Renderer2 } from '@angular/core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'weeklybackupschemenewdatabase',
    templateUrl: './weeklybackupschemenewdatabase.component.html',
    styleUrls: ['./weeklybackupschemenewdatabase.component.css']

})
export class WeeklybackupschemenewDatabaseComponent{

    days: any;
    keepBackups: any;

    constructor(private renderer: Renderer2,private router: Router, private route: ActivatedRoute) {
        var parent = this.route.parent;
        if (parent != null)
            parent.params.subscribe(params => { if (typeof (window) !== 'undefined') { this.loadWeekly(); } });

    }

    loadWeekly() {
        var dayNames = ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sun', 'Sat'];

        this.days = [];

        for (var i = 0; i < dayNames.length; i++) {
            this.days.push({ Name: dayNames[i], Backups: [], Class:'weeklyOneDayButton' });
        }

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

                if (settings.BackupScheme.Type != 'WEEKLY') {
                    settings.BackupScheme = { Type: 'WEEKLY', MaxBackups: settings.BackupScheme.MaxBackups, OneTimeBackup: null, BackupTimes: [] }

                    if (unSavedData.indexOf(daemonID) <= -1) {
                        unSavedData.push(daemonID);
                    }

                    sessionStorage.setItem('daemonsUnsave', JSON.stringify(unSavedData));
                    sessionStorage.setItem('daemonsData', JSON.stringify(data));
                }

                this.keepBackups = settings.BackupScheme.MaxBackups;

                var bcTimes = settings.BackupScheme.BackupTimes;

                for (var i = 0; i < bcTimes.length; i++) {
                    var bcTime = bcTimes[i];

                    this.days[bcTime.DayNumber].Class = 'weeklyOneDayButton active';
                    this.days[bcTime.DayNumber].Backups.push({
                        Time: bcTime.Time,
                        FullSelected: bcTime.Type == 'FULL' ? 'selected' : '',
                        DiffSelected: bcTime.Type == 'DIFF' ? 'selected' : '',
                        IncSelected: bcTime.Type == 'INC' ? 'selected' : ''
                    });
                }

            } catch (e) {

            }


        }

        this.validate();
    }

    addBackup(event : any) {
        var target = event.target || event.srcElement || event.currentTarget;

        if ((<HTMLButtonElement>target).parentElement == null)
            return;

        var backups = (<HTMLButtonElement>target.parentElement).querySelector('div.weeklyBackups');

        var newBackup = this.renderer.createElement('div');
        newBackup.className = 'weeklyOneBackup';

        var input = this.renderer.createElement('input');
        input.type = 'time';
        input.className = 'time';
        input.value = '00:00'
        input.required = true;

        var select = this.renderer.createElement('select');
        select.className = 'backupType';
        select.innerHTML =
            '<option value="FULL" > Full </option>' +
            '<option value= "DIFF"> Differential </option>' +
            '<option value= "INC"> Incremental </option>';

        var button = this.renderer.createElement('button');
        button.className = 'btnRemove';
        button.innerHTML = '-';


        this.renderer.listen(button, 'click', (evn) => this.deleteBackup(evn));
        this.renderer.listen(input, 'change', (evn) => { this.validate(); this.saveWeekly(); });
        this.renderer.listen(select, 'change', (evn) => { this.validate(); this.saveWeekly(); });

        this.renderer.appendChild(newBackup, input);
        this.renderer.appendChild(newBackup, select);
        this.renderer.appendChild(newBackup, button);


        this.renderer.appendChild(backups, newBackup);

        this.validate();
        this.saveWeekly();
    }

    showHide(event: any) {

        var target = event.target || event.srcElement || event.currentTarget;

        if ((<HTMLButtonElement>target).parentElement == null)
            return;
        var panel = <HTMLDivElement>(<HTMLButtonElement>target.parentElement).querySelector('div.weeklyOneDayPanel');
        var display = panel.style.display;

        var panels = (<HTMLDivElement>document.getElementById('weeklyScheme')).querySelectorAll('.weeklyOneDay .weeklyOneDayPanel');

        for (var i = 0; i < panels.length; i++) {
            var clPanel = <HTMLDivElement>panels[i];

            clPanel.style.display = 'none';
        }

        

        if (display == 'none') {
            panel.style.display = 'block';
        } else {
            panel.style.display = 'none';
        }

        
    }

    saveWeekly() {
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

                settings.BackupScheme.MaxBackups = +(<HTMLInputElement>document.getElementById('idnumberbackups')).value;

                var elements = (<HTMLDivElement>document.getElementById('weeklyScheme')).querySelectorAll('div.weeklyOneDay div.weeklyOneDayPanel div.weeklyBackups');

                settings.BackupScheme.BackupTimes = [];

                for (var i = 0; i < elements.length; i++) {
                    var elem = elements[i];
                    var backups = elem.querySelectorAll('div.weeklyOneBackup');
                    for (var k = 0; k < backups.length; k++) {
                        var el = backups[k];

                        var timeInput = <HTMLInputElement>el.querySelector('input.time');
                        var select = <HTMLSelectElement>el.querySelector('select.backupType');

                        settings.BackupScheme.BackupTimes.push({
                            Type: select.options[select.selectedIndex].value,
                            Time: timeInput.value,
                            DayNumber: i
                        });
                    }
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

    deleteBackup(event : any) {
        var target = event.target || event.srcElement || event.currentTarget;

        if ((<HTMLButtonElement>target).parentElement == null)
            return;

        var backups = (<HTMLDivElement>(<HTMLButtonElement>target.parentElement).parentElement);

        this.renderer.removeChild(backups, (<HTMLButtonElement>target).parentElement);

        this.validate();
        this.saveWeekly();
    }

    validate() {
        var daysDiv = <HTMLDivElement>document.getElementById('weeklyScheme');

        if (daysDiv == null)
            return;

        var daysElements = daysDiv.querySelectorAll('div.weeklyOneDay');

        var found = false;

        for (var i = 0; i < daysElements.length; i++) {
            var day = daysElements[i];
            var dayButton = day.querySelector('button.weeklyOneDayButton');

            var panel = <HTMLDivElement>day.querySelector('div.weeklyOneDayPanel div.weeklyBackups');
            var backups = panel.querySelectorAll('div.weeklyOneBackup');

            if (backups.length > 0) {
                this.renderer.addClass(dayButton, 'active');
                if (!found) {
                    var first = null;

                    for (var k = 0; k < backups.length; k++) {
                        var backup = backups[k];
                        var select = <HTMLSelectElement>backup.querySelector('select.backupType');
                        select.disabled = false;
                        if (first == null) {
                            first = backup;
                        } else {
                            
                            var timeInput = <HTMLInputElement>backup.querySelector('input.time');
                            var timeInputFirst = <HTMLInputElement>first.querySelector('input.time');

                            if (timeInput.value < timeInputFirst.value) {
                                first = backup;
                            }

                        }
                    }

                    if (first != null) {
                        var select = <HTMLSelectElement>first.querySelector('select.backupType');
                        select.selectedIndex = 0;
                        select.disabled = true;
                        found = true;
                    }
                }
            } else {
                this.renderer.removeClass(dayButton, 'active');
            }

            

        }
    }

}
