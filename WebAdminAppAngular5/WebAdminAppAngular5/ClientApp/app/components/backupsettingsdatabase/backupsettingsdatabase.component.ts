﻿import { Component, Renderer2 } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';
import 'rxjs/add/operator/toPromise';

@Component({
    selector: 'backupsettingsdatabase',
    templateUrl: './backupsettingsdatabase.component.html',
    styleUrls: ['./backupsettingsdatabase.component.css']


})
export class BackupSettingsDatabaseComponent {
    databaseinfo: any;

    destCount: number;
    destinations: any;

    nothingSelected: string;
    restartSelected: string;
    turnoffSelected: string;
    sleepSelected: string;

    constructor(private http: Http, private renderer: Renderer2, private router: Router, private route: ActivatedRoute) {
        var parent = this.route.parent;
        this.destCount = 0;
        if(parent != null)
        parent.params.subscribe(params => { if (typeof (window) !== 'undefined') { this.loadSettings(); } });
    }

    deserializeDestination(settings: any, i: number) {
        this.destCount++;
        var dest = {
            id: i,
            localPath: '',
            ftpAddress: '',
            ftpPort: '',
            ftpUsername: '',
            ftpPassword: '',
            ftpPath: '',
            sftpAddress: '',
            sftpPort: '',
            sftpUsername: '',
            sftpPassword: '',
            sftpPath: '',
            localChecked: '',
            ftpChecked: '',
            sftpChecked: '',
            ftpDisabled: '',
            sftpDisabled: '',
            localDisabled: '',
            zipSelected: '',
            plainSelected: ''
        };

        if (i == -1) {
            dest.id = this.destCount;
            dest.localChecked = 'checked';
            dest.ftpDisabled = 'disabled';
            dest.sftpDisabled = 'disabled';
            dest.localDisabled = '';
            dest.plainSelected = 'selected';
            return dest;
        }

        var destination = settings.Destinations[i];

        dest.localChecked = destination.Type == 'LOCAL_NETWORK' ? 'checked' : '';
        if (destination.Type == 'LOCAL_NETWORK') {
            dest.ftpDisabled = 'disabled';
            dest.sftpDisabled = 'disabled';
            dest.localDisabled = '';
            dest.localPath = destination.Path;
        }


        dest.ftpChecked = destination.Type == 'FTP' ? 'checked' : '';
        if (destination.Type == 'FTP') {
            dest.ftpDisabled = '';
            dest.sftpDisabled = 'disabled';
            dest.localDisabled = 'disabled';
            dest.ftpAddress = destination.Adress;
            dest.ftpPort = destination.Port;
            dest.ftpUsername = destination.Username;
            dest.ftpPassword = destination.Password;
            dest.ftpPath = destination.Path;
        }


        dest.sftpChecked = destination.Type == 'SFTP' ? 'checked' : '';
        if (destination.Type == 'SFTP') {
            dest.ftpDisabled = 'disabled';
            dest.sftpDisabled = '';
            dest.localDisabled = 'disabled';
            dest.sftpAddress = destination.Adress;
            dest.sftpPort = destination.Port;
            dest.sftpUsername = destination.Username;
            dest.sftpPassword = destination.Password;
            dest.sftpPath = destination.Path;
        }

        return dest;
    }

    serializeDestination(settings: any, id: string) {
        var destination = <HTMLTableElement>document.getElementById(id);
        var dest = {
            $type: '',
            Type: '',
            Path: '',
            Adress: '',
            Port: '',
            Username: '',
            Password: '',
            SaveFormat: ''
        };
        console.log(destination);
        if ((<HTMLInputElement>destination.querySelector('.radioLND')).checked) {
            dest.$type = 'LocalNetworkDestination';
            dest.Type = 'LOCAL_NETWORK';
            dest.Path = (<HTMLInputElement>destination.querySelector('.LNDpath')).value;

        } else if ((<HTMLInputElement>destination.querySelector('.radioFTP')).checked) {
            dest.$type = 'FTPDestination';
            dest.Type = 'FTP';

            dest.Adress = (<HTMLInputElement>destination.querySelector('.FTPserver')).value;
            dest.Port = (<HTMLInputElement>destination.querySelector('.FTPport')).value;
            dest.Username = (<HTMLInputElement>destination.querySelector('.FTPusername')).value;
            dest.Password = (<HTMLInputElement>destination.querySelector('.FTPpassword')).value;
            dest.Path = (<HTMLInputElement>destination.querySelector('.FTPpath')).value;
        } else if ((<HTMLInputElement>destination.querySelector('.radioSFTP')).checked) {
            dest.$type = 'SFTPDestination';
            dest.Type = 'SFTP';

            dest.Adress = (<HTMLInputElement>destination.querySelector('.SFTPserver')).value;
            dest.Port = (<HTMLInputElement>destination.querySelector('.SFTPport')).value;
            dest.Username = (<HTMLInputElement>destination.querySelector('.SFTPusername')).value;
            dest.Password = (<HTMLInputElement>destination.querySelector('.SFTPpassword')).value;
            dest.Path = (<HTMLInputElement>destination.querySelector('.SFTPpath')).value;
        }

        settings.Destinations.push(dest);
        console.log(settings.Destinations);
    }

    loadSettings() {
        var daemonsData = sessionStorage.getItem('daemonsData');
        var daemonID = sessionStorage.getItem('daemonID');
        var settingsID = sessionStorage.getItem('settingsID')
        if (daemonsData != null && daemonID != null && settingsID != null) {
            var data = JSON.parse(daemonsData);
            var listDaemons = data.ListDaemons;

            try {
                var settings = null;
                if (daemonID == "default") {
                    settings = data.DefaultSettingsDatabase;
                } else {
                    settings = listDaemons[daemonID].SettingsDatabase[settingsID];
                }


                this.destinations = [];
                this.databaseinfo = [];

                var database = '';
                var server = '';
                var username = '';
                var password = '';
                for (var i = 0; i < settings.length; i++) {
                    database = settings[i].Database
                    server = settings[i].Server
                    username = settings[i].Username
                    password = settings[i].Password

                    this.databaseinfo.push({
                        Database: database,
                        Server: server,
                        Username: username,
                        Password: password,
                    });
                }

                for (var i = 0; i < settings.Destinations.length; i++) {
                    this.destinations.push(this.deserializeDestination(settings,i));
                }

            } catch (e) {

            }
        }
    }

    enableLocal(id: string) {
        var destIndex = this.destinations.findIndex((el: any) => el.id == id);
        this.destinations[destIndex].ftpDisabled = 'disabled';
        this.destinations[destIndex].sftpDisabled = 'disabled';
        this.destinations[destIndex].localDisabled = '';
    }

    enableFtp(id: string) {
        var destIndex = this.destinations.findIndex((el: any) => el.id == id);
        this.destinations[destIndex].ftpDisabled = '';
        this.destinations[destIndex].sftpDisabled = 'disabled';
        this.destinations[destIndex].localDisabled = 'disabled';
    }

    enableSftp(id: string) {
        var destIndex = this.destinations.findIndex((el: any) => el.id == id);
        this.destinations[destIndex].ftpDisabled = 'disabled';
        this.destinations[destIndex].sftpDisabled = '';
        this.destinations[destIndex].localDisabled = 'disabled';
    }

    showHideDestination(id: string,hide: boolean) {
        var table = <HTMLTableElement>document.getElementById(id);
        var tbody = <HTMLTableSectionElement>table.querySelector('tbody');
        var arrow = <HTMLTableHeaderCellElement>table.querySelector('.showHideArrow');
        if (tbody.style.display != 'none' && hide) {
            tbody.style.display = 'none';
            arrow.innerHTML = '▼';
        } else {
            tbody.style.display = 'table-row-group';
            arrow.innerHTML = '▲';
        }
    }

    addNewDestination() {
        this.destinations.push(this.deserializeDestination(null, -1));
    }

    deleteDestination(id: string) {
        var destIndex = this.destinations.findIndex((el:any) => el.id == id);
        this.destinations.splice(destIndex, 1);
    }

    saveSettings() {
        console.log('SAVE');
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

                if (unSavedData.indexOf(daemonID) <= -1) {
                    unSavedData.push(daemonID);
                }
                /**/
                settings.Database = (<HTMLInputElement>document.getElementById('Database')).value;
                settings.Server = (<HTMLInputElement>document.getElementById('Server')).value;
                settings.Username = (<HTMLInputElement>document.getElementById('Username')).value;
                settings.Password = (<HTMLInputElement>document.getElementById('Password')).value;
                /**/
                var sources = (<HTMLDivElement>document.getElementById("backupSetting")).querySelectorAll('.OnebackupSetting');
                settings.BackupSources = [];

                for (var i = 0; i < sources.length; i++) {
                    var source = sources[i];
                    var val = (<HTMLInputElement>source.querySelector('.pathtextselect')).value;
                    settings.BackupSources.push(val);
                }

                settings.Destinations = [];

                var destDiv = <HTMLDivElement>document.getElementById('destinationsDiv');
                var dests = destDiv.querySelectorAll('.oneDestination');

                for (var i = 0; i < dests.length; i++) {
                    var dest = dests[i];

                    this.serializeDestination(settings, dest.id);
                }


            } catch (e) {

            }

            sessionStorage.setItem('daemonsData', JSON.stringify(data));
            sessionStorage.setItem('daemonsUnsave', JSON.stringify(unSavedData));
        }
    }

}