import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { LoginComponent } from './components/login/login.component';
import { MailsettingsComponent } from './components/mailsettings/mailsettings.component';
import { RegisterComponent } from './components/register/register.component';
import { DaemonsettingsComponent } from './components/daemonsettings/daemonsettings.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        LoginComponent,
        MailsettingsComponent,
        RegisterComponent,
        DaemonsettingsComponent
   
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'login', pathMatch: 'full' },
            { path: 'login', component: LoginComponent },
            {
                path: 'home',
                component: HomeComponent,
                children: [
                    { path: 'fetch', component: FetchDataComponent }
                   
                ]
            },
            {
                path: 'mailsettings',
                component: MailsettingsComponent
            },
            {
                path: 'register',
                component: RegisterComponent
            },
             {
                 path: 'daemonsettings',
                 component: DaemonsettingsComponent
            }
            
        

        ])
    ]
})
export class AppModuleShared {
}
