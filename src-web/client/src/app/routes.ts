import { Routes } from "@angular/router";
import { AccountsComponent } from './user-account/accounts/accounts.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { DashboardComponent } from './dashboard/dashboard.component';

export const AppRoutes: Routes = [
    { path: 'UserAccounts', component: AccountsComponent },
    { path: 'Dashboard', component: DashboardComponent },
    { path: '', redirectTo: '/Dashboard', pathMatch: 'full' },
    { path: '**', component: NotFoundComponent }
];