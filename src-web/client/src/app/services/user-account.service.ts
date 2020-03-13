import { Injectable } from '@angular/core';
import { UserAccount } from '@models/user-account.model';
import { BaseService } from '@services/base.service';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class UserAccountService extends BaseService {
    private _account: UserAccount;

    constructor(httpClient: HttpClient) {
        super(httpClient, 'UserAccounts');
    }

    get Account(): UserAccount {
        return this._account;
    }

    get IsLoggedIn(): boolean {
        return !(this._account === undefined || this._account === null);
    }

    GetAllUsers(): Promise<UserAccount[]> {
        return this.GetAll();
    }

    CreateUser(account: UserAccount): Promise<UserAccount> {
        return this.Post(account);
    }
}