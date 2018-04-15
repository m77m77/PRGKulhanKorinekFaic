import { Component, Renderer2 } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';
import 'rxjs/add/operator/toPromise';

@Component({
    selector: 'backupsettings',
    templateUrl: './backupsettings.component.html',
    styleUrls: ['./backupsettings.component.css']


})
export class BackupSettingsComponent {
    source: string;

    nothingSelected: string;
    restartSelected: string;
    turnoffSelected: string;
    sleepSelected: string;

    zipSelected: string;
    plainSelected: string;

    localChecked: string;
    ftpChecked: string;
    sftpChecked: string;

    localDisabled: string;
    ftpDisabled: string;
    sftpDisabled: string;

    localPath: string;

    ftpAddress: string;
    ftpPort: string;
    ftpUsername: string;
    ftpPassword: string;
    ftpPath: string;

    sftpAddress: string;
    sftpPort: string;
    sftpUsername: string;
    sftpPassword: string;
    sftpPath: string;

    constructor(private http: Http, private renderer: Renderer2, private router: Router, private route: ActivatedRoute) {
        var parent = this.route.parent;
        if(parent != null)
        parent.params.subscribe(params => { if (typeof (window) !== 'undefined') { this.loadSettings(); } });
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
                    settings = data.DefaultSettings;
                } else {
                    settings = listDaemons[daemonID].Settings[settingsID];
                }

                this.source = settings.BackupSourcePath;
                var action = settings.ActionAfterBackup;

                this.nothingSelected = action == 'NOTHING' ? 'selected' : '';
                this.restartSelected = action == 'RESTART' ? 'selected' : '';
                this.turnoffSelected = action == 'TURN OFF' ? 'selected' : '';
                this.sleepSelected = action == 'SLEEP' ? 'selected' : '';


                var saveFormat = settings.SaveFormat;

                this.zipSelected = saveFormat == 'ZIP' ? 'selected' : '';
                this.plainSelected = saveFormat == 'PLAIN' ? 'selected' : '';


                var destination = settings.Destination;

                this.localPath = '';
                this.ftpAddress = '';
                this.ftpPort = '';
                this.ftpUsername = '';
                this.ftpPassword = '';
                this.ftpPath = '';
                this.sftpAddress = '';
                this.sftpPort = '';
                this.sftpUsername = '';
                this.sftpPassword = '';
                this.sftpPath = '';

                this.localChecked = destination.Type == 'LOCAL_NETWORK' ? 'checked' : '';
                if (destination.Type == 'LOCAL_NETWORK') {
                    this.enableLocal();
                    this.localPath = destination.Path;
                }
                    

                this.ftpChecked = destination.Type == 'FTP' ? 'checked' : '';
                if (destination.Type == 'FTP') {
                    this.enableFtp();
                    this.ftpAddress = destination.Adress;
                    this.ftpPort = destination.Port;
                    this.ftpUsername = destination.Username;
                    this.ftpPassword = destination.Password;
                    this.ftpPath = destination.Path;
                }
                    
                
                this.sftpChecked = destination.Type == 'SFTP' ? 'checked' : '';
                if (destination.Type == 'SFTP') {
                    this.enableSftp();
                    this.sftpAddress = destination.Adress;
                    this.sftpPort = destination.Port;
                    this.sftpUsername = destination.Username;
                    this.sftpPassword = destination.Password;
                    this.sftpPath = destination.Path;
                }
                    



            } catch (e) {

            }
        }
    }

    enableLocal() {
        this.ftpDisabled = 'disabled';
        this.sftpDisabled = 'disabled';
        this.localDisabled = '';
    }

    enableFtp() {
        this.ftpDisabled = '';
        this.sftpDisabled = 'disabled';
        this.localDisabled = 'disabled';
    }

    enableSftp() {
        this.ftpDisabled = 'disabled';
        this.sftpDisabled = '';
        this.localDisabled = 'disabled';
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
                    settings = data.DefaultSettings;
                } else {
                    settings = listDaemons[daemonID].Settings[settingsID];
                }

                if (unSavedData.indexOf(daemonID) <= -1) {
                    unSavedData.push(daemonID);
                }

                var sources = (<HTMLDivElement>document.getElementById("backupSetting")).querySelectorAll('.OnebackupSetting');
                settings.BackupSources = [];

                for (var i = 0; i < sources.length; i++) {
                    var source = sources[i];
                    var val = (<HTMLInputElement>source.querySelector('.pathtextselect')).value;
                    console.log(val);
                    settings.BackupSources.push(val);
                }

                settings.BackupSourcePath = (<HTMLInputElement>document.getElementById('sourcePath')).value;
                var saveFormat = (<HTMLSelectElement>document.getElementById('saveFormat'));
                var afterBackup = (<HTMLSelectElement>document.getElementById('afterBackup'));
                settings.SaveFormat = saveFormat.options[saveFormat.selectedIndex].value;
                settings.ActionAfterBackup = afterBackup.options[afterBackup.selectedIndex].value;

                var dest = settings.Destination;

                if ((<HTMLInputElement>document.getElementById('radioLND')).checked) {
                    dest.$type = 'LocalNetworkDestination';
                    dest.Type = 'LOCAL_NETWORK';
                    dest.Path = (<HTMLInputElement>document.getElementById('LNDpath')).value;

                } else if ((<HTMLInputElement>document.getElementById('radioFTP')).checked) {
                    dest.$type = 'FTPDestination';
                    dest.Type = 'FTP';

                    dest.Adress = (<HTMLInputElement>document.getElementById('FTPserver')).value;
                    dest.Port = (<HTMLInputElement>document.getElementById('FTPport')).value;
                    dest.Username = (<HTMLInputElement>document.getElementById('FTPusername')).value;
                    dest.Password = (<HTMLInputElement>document.getElementById('FTPpassword')).value;
                    dest.Path = (<HTMLInputElement>document.getElementById('FTPpath')).value;
                } else if ((<HTMLInputElement>document.getElementById('radioSFTP')).checked) {
                    dest.$type = 'SFTPDestination';
                    dest.Type = 'SFTP';

                    dest.Adress = (<HTMLInputElement>document.getElementById('SFTPserver')).value;
                    dest.Port = (<HTMLInputElement>document.getElementById('SFTPport')).value;
                    dest.Username = (<HTMLInputElement>document.getElementById('SFTPusername')).value;
                    dest.Password = (<HTMLInputElement>document.getElementById('SFTPpassword')).value;
                    dest.Path = (<HTMLInputElement>document.getElementById('SFTPpath')).value;
                }


            } catch (e) {

            }

            sessionStorage.setItem('daemonsData', JSON.stringify(data));
            sessionStorage.setItem('daemonsUnsave', JSON.stringify(unSavedData));
        }
    }

     addBackupSource() {

        var backups = <HTMLDivElement>document.getElementById("backupSetting");

        var newBackupSetting = this.renderer.createElement('div');
        newBackupSetting.className = 'OnebackupSetting';
         

        var input = this.renderer.createElement('input');
        input.type = 'text';
        input.placeholder = 'C:\DATA';
        input.className = 'pathtextselect';

        var button = this.renderer.createElement('button');
        button.className = 'btnRemove';
        button.innerHTML = '-';
       
        this.renderer.listen(button, 'click', (evn) => this.deleteBackupSource(evn));
        this.renderer.listen(input, 'input', (evn) => this.saveSettings());
        this.renderer.appendChild(newBackupSetting, input);
       
        this.renderer.appendChild(backups, newBackupSetting);
        this.renderer.appendChild(newBackupSetting, button);
    }

     deleteBackupSource(event: any) {

         var target = event.target || event.srcElement || event.currentTarget;

         var backups = <HTMLDivElement>document.getElementById("backupSetting");

         this.renderer.removeChild(backups, target.parentNode);
         
     }
}