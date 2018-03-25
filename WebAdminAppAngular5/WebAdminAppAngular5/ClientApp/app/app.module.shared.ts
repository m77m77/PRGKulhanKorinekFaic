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
import { BackupschemeComponent } from './components/backupscheme/backupscheme.component';
import { DailybackupschemeComponent } from './components/dailybackupscheme/dailybackupscheme.component'//,
//import { WeeklybackupschemeComponent } from './components/weeklybackupscheme/weeklybackupscheme.component';



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
        DaemonsettingsComponent,
        BackupschemeComponent,
        DailybackupschemeComponent //,
        //WeeklybackupschemeComponent
   
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
                    { path: 'fetch', component: FetchDataComponent },
                    { path: 'mail', component: MailsettingsComponent },
                    {
                        path: 'daemon',
                        component: DaemonsettingsComponent,
                        children: [
                            { path: 'scheme', component: BackupschemeComponent },
                            { path: 'dailybackupscheme', component: DailybackupschemeComponent }//,
                            //{ path: 'weeklybackupscheme', component: WeeklybackupschemeComponent }
                        ]
                    },
                    { path: 'register', component: RegisterComponent}
                ]
            }
        ])
    ]
})
export class AppModuleShared {
}
