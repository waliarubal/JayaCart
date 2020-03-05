import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../constants';

@Injectable()
export class UserAccountService {

    constructor(private readonly _http: HttpClient) {

    }

    GetAllUsers() {
        return this._http.get(`${Constants.ApiUrl}/UserAccounts`);
    }
}