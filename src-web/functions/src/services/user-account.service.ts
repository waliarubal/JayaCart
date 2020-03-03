import * as express from 'express';
import * as admin from 'firebase-admin';
import * as firebaseHelper from 'firebase-functions-helper';
import * as HttpStatus from 'http-status-codes';
import { BaseService } from "./base.service";
import { UserAccount } from "../models/user-account";

export class UserAccountService extends BaseService {
    private readonly USER_ACCOUNTS = 'UserAccounts';

    constructor(db: admin.firestore.Firestore, app: express.Express) {
        super(db, app);
    }

    private async CreateAccount(request, response) {
        try {
            let account: UserAccount = {
                PhoneNumber: request.body['PhoneNumber'],
                FirstName: request.body['FirstName'],
                LastName: request.body['LastName'],
                AddressLine1: request.body['AddressLine1'],
                AddressLine2: request.body['AddressLine2'],
                City: request.body['City'],
                Password: request.body['Password'],
                Image: request.body['Image'],
                Balance: 0,
                IsActive: false,
                IsAdmin: false
            };

            let isCreated = await firebaseHelper.firestore.createDocumentWithID(this.Database, this.USER_ACCOUNTS, account.PhoneNumber, account);
            if (isCreated)
                response
                    .status(HttpStatus.CREATED)
                    .json(this.Result<UserAccount>(account));
            else
                response
                    .status(HttpStatus.BAD_REQUEST)
                    .json(this.Error<UserAccount>(`Failed to create user account: ${account}`));
        } catch (ex) {
            response
                .status(HttpStatus.BAD_REQUEST)
                .json(this.Error<UserAccount>(`Failed to create user account.`));
        }
    }

    private async UpdateAccount(request, response) {
        try {
            await firebaseHelper.firestore.updateDocument(this.Database, this.USER_ACCOUNTS, request.params.PhoneNumber, request.body);
            response
                .status(HttpStatus.NO_CONTENT)
                .json(this.Result<UserAccount>(request.body));
        } catch (ex) {
            response
                .status(HttpStatus.BAD_REQUEST)
                .json(this.Error<UserAccount>(`Failed to update user account with phone number ${request.params.PhoneNumber}.`));
        }
    }

    private GetAccountByPhoneNumber(request, response) {
        firebaseHelper.firestore.getDocument(this.Database, this.USER_ACCOUNTS, request.params.PhoneNumber)
            .then(record => response.
                status(HttpStatus.OK)
                .json(this.Result<UserAccount>(record)))
            .catch(ex => response
                .status(HttpStatus.BAD_REQUEST)
                .json(this.Error<UserAccount>(`Failed to get user account for phone number ${request.params.PhoneNumber}: ${ex}`)));
    }

    private GetAccount(request, response) {
        firebaseHelper.firestore.backup(this.Database, this.USER_ACCOUNTS)
            .then(records => response
                .status(HttpStatus.OK)
                .json(this.Result<unknown>(records)))
            .catch(ex => response
                .status(HttpStatus.BAD_REQUEST)
                .json(this.Error<UserAccount>(`Failed to get user accounts: ${ex}`)));
    }

    private async DeleteAccount(request, response) {
        const deletedRecord = await firebaseHelper.firestore.deleteDocument(this.Database, this.USER_ACCOUNTS, request.params.PhoneNumber);
        response
            .status(HttpStatus.NO_CONTENT)
            .json(this.Result<object>(deletedRecord));
    }

    RegisterMethods(): void {
        this.Application.post(`/${this.USER_ACCOUNTS}`, this.CreateAccount);
        this.Application.patch(`/${this.USER_ACCOUNTS}/:PhoneNumber`, this.UpdateAccount);
        this.Application.get(`/${this.USER_ACCOUNTS}/:PhoneNumber`, this.GetAccountByPhoneNumber);
        this.Application.get(`/${this.USER_ACCOUNTS}`, this.GetAccount);
        this.Application.delete(`/${this.USER_ACCOUNTS}/:PhoneNumber`, this.DeleteAccount);
    }
}