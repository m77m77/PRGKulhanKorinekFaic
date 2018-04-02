import { Component} from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';
import 'rxjs/add/operator/toPromise';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']


})

export class LoginComponent {

    public constructor(private http: Http, private router: Router, private route: ActivatedRoute) { 
        if (typeof window !== 'undefined') {
            if (sessionStorage.getItem('token') != null)
                this.router.navigate(['../home/mail'], { relativeTo: this.route })
        }
    }

    public login() {
        var username = (<HTMLInputElement>document.getElementById('username')).value;
        var password = (<HTMLInputElement>document.getElementById('password')).value

        var headers = new Headers();
        headers.append('Content-Type', 'application/json');

        return this.http.post('http://localhost:63058/api/newtoken/admin', { Name: username, Password: password }, { headers: headers }).toPromise()
            .then((response: Response) => {
                let user = response.json();

                if (user && "OK" == user.Status) {
                    if (typeof window !== 'undefined') {
                        sessionStorage.setItem('token', user.NewToken); // sessionStorage > localStorage => nemusíme dělat expiraci ručně
                    }
                    /********************* admin TYPE - sessionStorage SAVE*/
                    this.http.get('http://localhost:63058/api/newadmin/type/' + sessionStorage.getItem('token')).toPromise()
                        .then((response: Response) => {
                            let AdminInfo = response.json();
                            console.log(AdminInfo.Data);
                            if (AdminInfo && "OK" == AdminInfo.Status) {
                                sessionStorage.setItem('AdminInfo', JSON.stringify(AdminInfo.Data));
                            } else {
                                sessionStorage.removeItem('token');
                                this.router.navigate(['/login'], {})
                            }
                        })
                        .catch((msg: any) => { sessionStorage.removeItem('token'); this.router.navigate(['/login'], {}); })
                    /***********************/
                    this.router.navigate(['../home/mail'], { relativeTo: this.route })
                } else {
                    console.log('Error: ' + user.Error)
                }
            })
            .catch((msg: any) => console.log('Error: ' + msg.status + ' ' + msg.statusText))
    }

    public Validation() {
        var username = (<HTMLInputElement>document.getElementById('username')).value;
        var password = (<HTMLInputElement>document.getElementById('password')).value

        if (username !== "" && password !== "") {
            this.login();
        }
    }
}
