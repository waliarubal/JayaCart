import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { UserAccountService } from '@services/user-account.service';
import { AuthGuardService } from '@services/auth-guard.service';
import { AppComponent } from './app.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { RoutesModule } from './shared/routes.module';
import { UserAccountModule } from './user-account/user-account.module';
import { DashboardModule } from './dashboard/dashboard.module';
import { ArticleModule } from './article/article.module';

@NgModule({
  declarations: [
    AppComponent,
    NotFoundComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    RoutesModule,
    NgbModule,
    DashboardModule,
    UserAccountModule,
    ArticleModule
  ],
  providers: [
    UserAccountService,
    AuthGuardService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
