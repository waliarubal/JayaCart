import { Routes, RouterModule } from "@angular/router";
import { NgModule } from '@angular/core';
import { NotFoundComponent } from '@app/not-found/not-found.component';
import { DashboardComponent } from '@app/dashboard/dashboard.component';
import { UserAccountComponent } from '@app/user-account/user-account.component';
import { AccountComponent } from '@app/user-account/account/account.component';
import { SidebarItem } from '@models/sidebar-item.model';
import { AuthGuardService } from '@services/auth-guard.service';
import { LoginComponent } from '@app/user-account/login/login.component';
import { ArticleComponent } from '@app/article/article.component';

const APP_ROUTES: Routes = [
    {
        path: 'Dashboard',
        component: DashboardComponent,
        canActivate: [AuthGuardService],
        data: { Label: "Dashboard", IconClass: "fas fa-chart-line" }
    },
    {
        path: 'Articles',
        data: { Label: 'Articles', IconClass: 'fas fa-boxes' },
        canActivate: [AuthGuardService],
        children: [
            {
                path: '',
                component: ArticleComponent,
                data: { Label: "Manage Articles", IconClass: "fas fa-box" }
            },
        ]
    },
    {
        path: 'UserAccounts',
        data: { Label: "User Accounts", IconClass: "fas fa-users" },
        canActivate: [AuthGuardService],
        children: [
            {
                path: '',
                component: UserAccountComponent,
                data: { Label: "Manage Users", IconClass: "fas fa-user-friends", Header: "Manage User Accounts" }
            },
            {
                path: 'New',
                component: AccountComponent,
                data: { Label: "New User", IconClass: "fas fa-user-plus", Header: 'Create New User Account' }
            }
        ]
    },
    { path: 'Login', component: LoginComponent },
    { path: '', redirectTo: '/Dashboard', pathMatch: 'full' },
    { path: '**', component: NotFoundComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(APP_ROUTES)],
    exports: [RouterModule]
})
export class RoutesModule {

    static GetSidebarItems(): SidebarItem[] {
        let items: SidebarItem[] = [];

        for (let route of APP_ROUTES) {
            if (!route.data)
                continue;

            let item = new SidebarItem(route.data.Label, route.data.IconClass);
            item.Header = route.data.Header ?? item.Label;
            if (route.children && route.children.length > 0) {
                for (let subRoute of route.children) {
                    if (!subRoute.data)
                        continue;

                    let subItem = new SidebarItem(subRoute.data.Label, subRoute.data.IconClass);
                    subItem.Header = subRoute.data.Header ?? subItem.Label;
                    subItem.RouterLink = `/${route.path}/${subRoute.path}`
                    item.Items.push(subItem);
                }
            } else
                item.RouterLink = `/${route.path}`;

            items.push(item);
        }

        return items;
    }

}