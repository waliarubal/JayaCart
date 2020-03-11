import { Injectable } from '@angular/core';
import { UserAccount } from '@models/user-account.model';
import { BaseService } from '@services/base.service';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class UserAccountService extends BaseService {

    constructor(httpClient: HttpClient) {
        super(httpClient, 'UserAccounts');
    }

    GetAllUsers(): Promise<UserAccount[]> {
        return this.GetAll();
    }

    CreateUser(account: UserAccount): Promise<UserAccount> {
        return this.Post(account);
    }
}