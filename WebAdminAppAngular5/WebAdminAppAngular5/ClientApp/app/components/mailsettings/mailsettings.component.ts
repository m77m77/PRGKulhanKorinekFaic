import { Component } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';
import 'rxjs/add/operator/toPromise';

@Component({
    selector: 'mailsettings',
    templateUrl: './mailsettings.component.html',
    styleUrls: ['./mailsettings.component.css']


})
export class MailsettingsComponent {
    sendMail: string;
    mailAddress: string;

    OwnSmtp: string;
    SmtpPort: string;
    HostName: string;
    Username: string;
    Password: string;

    templates: any;
    daily: any;
    weekly: any;
    monthly: any;

    constructor(private http: Http, private router: Router, private route: ActivatedRoute) {
        if (typeof window !== 'undefined') {
            if (sessionStorage.getItem('mailData') == null) {
                var headers = new Headers();
                headers.append('Content-Type', 'application/json');
                
                this.http.get('http://localhost:63058/api/email/OneAdmin/' + sessionStorage.getItem('token'), { headers: headers }).toPromise()
                    .then((response: Response) => {
                        let mailSettings = response.json();
                        console.log(mailSettings.Data);
                        if (mailSettings && "OK" == mailSettings.Status) {
                            sessionStorage.setItem('mailData', JSON.stringify(mailSettings.Data));
                            this.loadMailData();
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

            this.loadMailData();
        }
    }

    loadMailData() {
        var mailData = sessionStorage.getItem('mailData');

        if (mailData != null) {
            var data = JSON.parse(mailData);
            var info = data.Info;
            var settings = data.Settings;

            this.sendMail = settings.SendEmails ? "checked" : "";
            this.mailAddress = settings.EmailAddress;

            this.OwnSmtp = settings.OwnSmtp ? "checked" : "";
            this.HostName = settings.HostName;
            this.SmtpPort = settings.SmtpPort;
            this.Username = settings.Username;
            this.Password = settings.Password;


            this.templates = [];
            for (var templateID in info.Templates) {
                var template = info.Templates[templateID];
                var selected = (settings.Template == templateID ? "selected" : "");
                this.templates.push({ Id: templateID, Name: template,Selected: selected});
            }

            this.daily = [];
            this.weekly = [];
            this.monthly = [];

            for (var daemonID in info.Daemons) {
                var daemonName = info.Daemons[daemonID];

                var conDaily = (settings.FromDaemonsDaily.indexOf(+daemonID) > -1 ? "checked" : "");
                var conWeekly = (settings.FromDaemonsWeekly.indexOf(+daemonID) > -1 ? "checked" : "");
                var conMonthly = (settings.FromDaemonsMonthly.indexOf(+daemonID) > -1 ? "checked" : "");

                this.daily.push({ Id: daemonID, Name: daemonName, Selected:  conDaily});
                this.weekly.push({ Id: daemonID, Name: daemonName, Selected:  conWeekly});
                this.monthly.push({ Id: daemonID, Name: daemonName, Selected:  conMonthly});
            }
        }
    }

    saveMailData() {
        var mailData = sessionStorage.getItem('mailData');

        if (mailData != null) {
            var data = JSON.parse(mailData);
            var info = data.Info;
            var settings = data.Settings;

            settings.SendEmails = (<HTMLInputElement>document.getElementById('checkboxmail')).checked;

            settings.OwnSmtp = (<HTMLInputElement>document.getElementById('OwnSMTP')).checked;

            settings.EmailAddress = (<HTMLInputElement>document.getElementById('idemailTo')).value;

            settings.SmtpPort = (<HTMLInputElement>document.getElementById('smtpPort')).value;
            settings.HostName = (<HTMLInputElement>document.getElementById('HostName')).value;
            settings.Username = (<HTMLInputElement>document.getElementById('username')).value;
            settings.Password = (<HTMLInputElement>document.getElementById('password')).value;

            var templateSelect = (<HTMLSelectElement>document.getElementById('selecttemplate'));
            settings.Template = templateSelect.options[templateSelect.selectedIndex].value;

            var daily = (<HTMLElement>document.getElementById('mailDaemonsDaily')).querySelectorAll("input:checked");
            var weekly = (<HTMLElement>document.getElementById('mailDaemonsWeekly')).querySelectorAll("input:checked");
            var monthly = (<HTMLElement>document.getElementById('mailDaemonsMonthly')).querySelectorAll("input:checked");

            settings.FromDaemonsDaily = [];
            for (var i = 0; i < daily.length; i++) {
                var node = daily.item(i);
                settings.FromDaemonsDaily.push(+(<HTMLInputElement>node).value);
            }

            settings.FromDaemonsWeekly = [];
            for (var i = 0; i < weekly.length; i++) {
                var node = weekly.item(i);
                settings.FromDaemonsWeekly.push(+(<HTMLInputElement>node).value);
            }

            settings.FromDaemonsMonthly = [];
            for (var i = 0; i < monthly.length; i++) {
                var node = monthly.item(i);
                settings.FromDaemonsMonthly.push(+(<HTMLInputElement>node).value);
            }

            sessionStorage.setItem('mailData', JSON.stringify(data));
        }
    }

    sendMailData() {
        var mailData = sessionStorage.getItem('mailData');

        if (mailData != null) {
            var data = JSON.parse(mailData);
            var settings = data.Settings;

            var headers = new Headers();
            headers.append('Content-Type', 'application/json');

            this.http.post('http://localhost:63058/api/email/' + sessionStorage.getItem('token'),JSON.stringify(settings), { headers: headers }).toPromise()
                .then((response: Response) => {
                    let mailSettings = response.json();
                    console.log(mailSettings);
                    if (mailSettings && "OK" == mailSettings.Status) {

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
    }
}