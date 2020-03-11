import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';

import { RoutesModule } from './shared/routes.module';
import { AppComponent } from './app.component';
import { NotFoundModule } from './not-found/not-found.module';
import { UserAccountModule } from './user-account/user-account.module';
import { DashboardModule } from './dashboard/dashboard.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RoutesModule,
    NgbModule,
    NotFoundModule,
    DashboardModule,
    UserAccountModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
