import { Component } from '@angular/core';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']


})
export class HomeComponent {
    constructor(private router: Router, private route: ActivatedRoute) {
        if (typeof window !== 'undefined') {
            if (sessionStorage.getItem('token') == null)
                this.router.navigate(['../login'], { relativeTo: this.route });
        }
    }
}
