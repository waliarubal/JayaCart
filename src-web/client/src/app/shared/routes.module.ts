import { Routes, RouterModule } from "@angular/router";
import { NotFoundComponent } from '@app/not-found/not-found.component';
import { DashboardComponent } from '@app/dashboard/dashboard.component';
import { UserAccountComponent } from '@app/user-account/user-account.component';
import { AccountComponent } from '@app/user-account/account/account.component';
import { NgModule } from '@angular/core';

const APP_ROUTES: Routes = [
    {
        path: 'UserAccounts',
        children: [
            { path: 'New', component: AccountComponent },
            { path: 'All', component: UserAccountComponent }
        ]
    },
    { path: 'Dashboard', component: DashboardComponent },
    { path: '', redirectTo: '/Dashboard', pathMatch: 'full' },
    { path: '**', component: NotFoundComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(APP_ROUTES)],
    exports: [RouterModule]
})
export class RoutesModule { }