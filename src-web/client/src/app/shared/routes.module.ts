import { Routes, RouterModule } from "@angular/router";
import { NgModule } from '@angular/core';
import { NotFoundComponent } from '@app/not-found/not-found.component';
import { DashboardComponent } from '@app/dashboard/dashboard.component';
import { UserAccountComponent } from '@app/user-account/user-account.component';
import { AccountComponent } from '@app/user-account/account/account.component';
import { SidebarItem } from '@models/sidebar-item.model';

const APP_ROUTES: Routes = [
    {
        path: 'Dashboard',
        component: DashboardComponent,
        data: { "Label": "Dashboard", "IconClass": "fas fa-chart-line" }
    },
    {
        path: 'UserAccounts',
        data: { "Label": "User Accounts", "IconClass": "fas fa-users" },
        children: [
            {
                path: '',
                component: UserAccountComponent,
                data: { "Label": "Manage Users", "IconClass": "fas fa-user-friends" }
            },
            {
                path: 'New',
                component: AccountComponent,
                data: { "Label": "New User", "IconClass": "fas fa-user-plus" }
            }
        ]
    },
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
            if (route.children && route.children.length > 0) {
                for (let subRoute of route.children) {
                    if (!subRoute.data)
                        continue;

                    let subItem = new SidebarItem(subRoute.data.Label, subRoute.data.IconClass);
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