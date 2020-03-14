import { Injectable } from '@angular/core';
import { Md5 } from 'ts-md5/dist/md5';
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

    private GetMd5(data: string): string {
        let md5 = new Md5().appendStr(data).end();
        return md5.toString();
    }

    GetAllUsers(): Promise<UserAccount[]> {
        return this.GetAll();
    }

    CreateUser(account: UserAccount): Promise<UserAccount> {
        return this.Post(account);
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
            return true;
        }

        return false;
    }
}