import { Injectable } from '@angular/core';
import { Md5 } from 'ts-md5/dist/md5';
import { UserAccount } from '@models/user-account.model';
import { BaseService } from '@services/base.service';
import { HttpClient } from '@angular/common/http';

const ACCOUNT_KEY = 'UserAccount';

@Injectable()
export class UserAccountService extends BaseService {
    private _account: UserAccount;

    constructor(httpClient: HttpClient) {
        super(httpClient, 'UserAccounts');

        let accountString = localStorage.getItem(ACCOUNT_KEY);
        if (accountString) {
            accountString = atob(accountString);
            this._account = <UserAccount>JSON.parse(accountString);
        }
            
    }

    get Account(): UserAccount {
        return this._account;
    }

    get IsLoggedIn(): boolean {
        return !(this._account === undefined || this._account === null);
    }

    private GetMd5(data: string): string {
        let md5 = new Md5().appendStr(data).end();
        return md5.toString();
    }

    GetUser(phoneNumber: string): Promise<UserAccount> {
        return this.Get<UserAccount>(phoneNumber);
    }

    GetAllUsers(): Promise<UserAccount[]> {
        return this.GetAll();
    }

    CreateUser(account: UserAccount): Promise<UserAccount> {
        return this.Post(account);
    }

    Update(account: UserAccount) : Promise<UserAccount> {
        return this.Patch(account, account.PhoneNumber);
    }

    async LogIn(phoneNumber: string, password: string): Promise<boolean> {
        this._account = undefined;

        password = this.GetMd5(password);
        let credentials = {
            PhoneNumber: phoneNumber,
            Password: password
        };

        let account = await this.Post<UserAccount>(credentials, 'SignIn');
        if (account) {
            this._account = account;
            localStorage.setItem(ACCOUNT_KEY, btoa(JSON.stringify(account)));
            return true;
        }

        return false;
    }

    LogOff(): void {
        this._account = undefined;
        localStorage.removeItem(ACCOUNT_KEY);
    }
}