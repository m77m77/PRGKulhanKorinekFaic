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

import { SettingsDatabaseComponent } from './components/settingsdatabase/settingsdatabase.component';
import { BackupSettingsDatabaseComponent } from './components/backupsettingsdatabase/backupsettingsdatabase.component';
import { BackupschemeDatabaseComponent } from './components/backupschemedatabase/backupschemedatabase.component';
import { DailybackupschemeDatabaseComponent } from './components/dailybackupschemedatabase/dailybackupschemedatabase.component';
import { DefaultSettingsDatabaseComponent } from './components/defaultsettingsdatabase/defaultsettingsdatabase.component';
import { MonthlybackupschemeDatabaseComponent } from './components/monthlybackupschemedatabase/monthlybackupschemedatabase.component';
import { OnetimebackupschemeDatabaseComponent } from './components/onetimebackupschemedatabase/onetimebackupschemedatabase.component';
import { WeeklybackupschemenewDatabaseComponent } from './components/weeklybackupschemedatabase/weeklybackupschemenewdatabase.component';



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
        SettingsDatabaseComponent,
        SettingsDatabaseComponent,
        BackupSettingsDatabaseComponent,
        BackupschemeDatabaseComponent,
        DailybackupschemeDatabaseComponent,
        DefaultSettingsDatabaseComponent,
        MonthlybackupschemeDatabaseComponent,
        OnetimebackupschemeDatabaseComponent,
        WeeklybackupschemenewDatabaseComponent,
   
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
                    { path: 'daemon', redirectTo: 'daemon/0/file/0', pathMatch: 'full' },
                    {
                        path: 'daemon/:id',
                        component: DaemonsettingsComponent,
                        children: [
                            {
                                path: 'file/:settingsID',
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
                            {
                                path: 'database/:settingsID',
                                component: SettingsDatabaseComponent,
                                children: [
                                    {
                                        path: 'scheme',
                                        component: BackupschemeDatabaseComponent,
                                        children: [
                                            { path: 'daily', component: DailybackupschemeDatabaseComponent },
                                            { path: 'weekly', component: WeeklybackupschemenewDatabaseComponent },
                                            { path: 'onetime', component: OnetimebackupschemeDatabaseComponent },
                                            { path: 'monthly', component: MonthlybackupschemeDatabaseComponent }
                                        ]
                                    },
                                    { path: 'settings', component: BackupSettingsDatabaseComponent },
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
                    {
                        path: 'defaultdatabase',
                        component: DefaultSettingsDatabaseComponent,
                        children: [
                            {
                                path: 'defaultdatabase',
                                component: SettingsDatabaseComponent,
                                children: [
                                    {
                                        path: 'scheme',
                                        component: BackupschemeDatabaseComponent,
                                        children: [
                                            { path: 'daily', component: DailybackupschemeDatabaseComponent },
                                            { path: 'weekly', component: WeeklybackupschemenewDatabaseComponent },
                                            { path: 'onetime', component: OnetimebackupschemeDatabaseComponent },
                                            { path: 'monthly', component: MonthlybackupschemeDatabaseComponent }
                                        ]
                                    },
                                    { path: 'settings', component: BackupSettingsDatabaseComponent },
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
