import * as express from 'express';
import * as admin from 'firebase-admin';
import * as firebaseHelper from 'firebase-functions-helper';
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
                response.status(201).json(account);
            else {
                console.log(`Failed to create user account: ${account}`);
                response.status(400).send(`Failed to create user account.`);
            }

        } catch (ex) {
            console.log(`Failed to create user account. ${ex}`);
            response.status(400).send(`Failed to create user account.`);
        }
    }

    private async UpdateAccount(request, response) {
        try {
            await firebaseHelper.firestore.updateDocument(this.Database, this.USER_ACCOUNTS, request.params.PhoneNumber, request.body);
            response.status(204).json(request.body);
        } catch (ex) {
            response.status(400).send(`Failed to update user account with phone number ${request.params.PhoneNumber}.`);
        }
    }

    private GetAccountByPhoneNumber(request, response) {
        firebaseHelper.firestore.getDocument(this.Database, this.USER_ACCOUNTS, request.params.PhoneNumber)
            .then(record => response.status(200).json(record))
            .catch(ex => response.status(400).send(`Failed to get user account for phone number ${request.params.PhoneNumber}: ${ex}`));
    }

    private GetAccount(request, response) {
        firebaseHelper.firestore.backup(this.Database, this.USER_ACCOUNTS)
            .then(records => response.status(200).json(records))
            .catch(ex => response.status(400).send(`Failed to get user accounts: ${ex}`));
    }

    private async DeleteAccount(request, response) {
        const deletedRecord = await firebaseHelper.firestore.deleteDocument(this.Database, this.USER_ACCOUNTS, request.params.PhoneNumber);
        response.status(204).json(deletedRecord);
    }

    RegisterMethods(): void {
        this.Application.post(`/${this.USER_ACCOUNTS}`, this.CreateAccount);
        this.Application.patch(`/${this.USER_ACCOUNTS}/:PhoneNumber`, this.UpdateAccount);
        this.Application.get(`/${this.USER_ACCOUNTS}/:PhoneNumber`, this.GetAccountByPhoneNumber);
        this.Application.get(`/${this.USER_ACCOUNTS}`, this.GetAccount);
        this.Application.delete(`/${this.USER_ACCOUNTS}/:PhoneNumber`, this.DeleteAccount);
    }
}