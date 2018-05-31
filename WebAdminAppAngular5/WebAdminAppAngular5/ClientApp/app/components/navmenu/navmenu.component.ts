import { Component } from '@angular/core';
import { RouterModule, Routes, Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.css']
})
export class NavMenuComponent {
    constructor(private router: Router, private route: ActivatedRoute) {
    }

    logOut() {
        sessionStorage.clear();
        this.router.navigate(['/login'], {})
    }
}
