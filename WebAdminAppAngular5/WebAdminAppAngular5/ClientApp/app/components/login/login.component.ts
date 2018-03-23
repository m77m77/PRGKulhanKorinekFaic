import { Component } from '@angular/core';
import { Http, Headers, Response, URLSearchParams } from '@angular/http';
import { NgModule } from '@angular/core';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']


})

export class LoginComponent {

    public constructor(private http: Http, private router: Router, private route: ActivatedRoute) {
    }

    public login() {
        try {
            var headers = new Headers();
            headers.append('Content-Type', 'application/x-www-form-urlencoded');
            let urlSearchParams = new URLSearchParams();
            urlSearchParams.append('Name', 'admin');
            urlSearchParams.append('Password', 'password');
            let body = urlSearchParams.toString()

            return this.http.post('http://localhost:51404/api/newtoken/admin', body, { headers: headers })
                .lift((response: Response) => {
                    // login successful if user.status = success in the response
                    let user = response.json();
                    console.log(user.status)
                    if (user && "success" == user.status) {
                        // store user details and jwt token in local storage to keep user logged in between page refreshes
                        localStorage.setItem('currentUser', JSON.stringify(user.data));

                        this.router.navigate([`../home`], { relativeTo: this.route })
                    }
                });
             }
        catch(e) {

    }
        

    }
}
