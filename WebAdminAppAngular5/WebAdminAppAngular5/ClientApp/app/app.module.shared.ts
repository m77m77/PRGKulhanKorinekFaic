import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { LoginComponent } from './components/login/login.component';
import { MailsettingsComponent } from './components/mailsettings/mailsettings.component';
import { RegisterComponent } from './components/register/register.component';
import { DaemonsettingsComponent } from './components/daemonsettings/daemonsettings.component';
import { BackupschemeComponent } from './components/backupscheme/backupscheme.component';
import { DailybackupschemeComponent } from './components/dailybackupscheme/dailybackupscheme.component';
import { WeeklybackupschemenewComponent} from './components/weeklybackupscheme/weeklybackupschemenew.component';
import { SettingsComponent } from './components/settings/settings.component';
import { BackupSettingsComponent } from './components/backupsettings/backupsettings.component';
import { OnetimebackupschemeComponent } from './components/onetimebackupscheme/onetimebackupscheme.component';
import { MonthlybackupschemeComponent } from './components/monthlybackupscheme/monthlybackupscheme.component';
import { ITokenComponent } from './components/itoken/itoken.component';
import { ReportComponent } from './components/report/report.component';
import { DefaultSettingsComponent } from './components/defaultsettings/defaultsettings.component';


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        FetchDataComponent,
        HomeComponent,
        LoginComponent,
        MailsettingsComponent,
        RegisterComponent,
        DaemonsettingsComponent,
        BackupschemeComponent,
        DailybackupschemeComponent,
        WeeklybackupschemenewComponent,
        SettingsComponent,
        BackupSettingsComponent,
        OnetimebackupschemeComponent,
        MonthlybackupschemeComponent,
        ITokenComponent,
        ReportComponent,
        DefaultSettingsComponent,
   
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
                    { path: 'daemon', redirectTo: 'daemon/0/0', pathMatch: 'full' },
                    {
                        path: 'daemon/:id',
                        component: DaemonsettingsComponent,
                        children: [
                            {
                                path: ':settingsID',
                                component: SettingsComponent,
                                children: [
                                    {
                                        path: 'scheme',
                                        component: BackupschemeComponent,
                                        children: [
                                            { path: 'daily', component: DailybackupschemeComponent },
                                            { path: 'weekly', component: WeeklybackupschemenewComponent },
                                            { path: 'onetime', component: OnetimebackupschemeComponent },
                                            { path: 'monthly', component: MonthlybackupschemeComponent }
                                        ]
                                    },
                                    { path: 'settings', component: BackupSettingsComponent },
                                    { path: '**', redirectTo: 'settings', pathMatch: 'full' },
                                ]
                            },


                        ]
                    },
                    {
                        path: 'default',
                        component: DefaultSettingsComponent,
                        children: [
                            {
                                path: 'default',
                                component: SettingsComponent,
                                children: [
                                    {
                                        path: 'scheme',
                                        component: BackupschemeComponent,
                                        children: [
                                            { path: 'daily', component: DailybackupschemeComponent },
                                            { path: 'weekly', component: WeeklybackupschemenewComponent },
                                            { path: 'onetime', component: OnetimebackupschemeComponent },
                                            { path: 'monthly', component: MonthlybackupschemeComponent }
                                        ]
                                    },
                                    { path: 'settings', component: BackupSettingsComponent },
                                    { path: '**', redirectTo: 'settings', pathMatch: 'full' },
                                ]
                            },


                        ]
                    },
                    { path: 'register', component: RegisterComponent },
                    { path: 'itoken', component: ITokenComponent },
                    { path: 'report', component: ReportComponent },
                ]
            }
        ])
    ]
})
export class AppModuleShared {
}
