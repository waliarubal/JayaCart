import * as firebaseHelper from 'firebase-functions-helper';
import * as HttpStatus from 'http-status-codes';
import { BaseService, HttpMethod } from "./base.service";
import { UserAccount } from "../../../models/user-account";

export class UserAccountService extends BaseService {
    private readonly USER_ACCOUNTS = 'UserAccounts';

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
            let updatedRecord = await firebaseHelper.firestore.updateDocument(this.Database, this.USER_ACCOUNTS, request.params.PhoneNumber, request.body);
            if (updatedRecord)
                response
                    .status(HttpStatus.NO_CONTENT)
                    .json(this.Result<UserAccount>(updatedRecord));
            else
                response
                    .status(HttpStatus.BAD_REQUEST)
                    .json(this.Error<UserAccount>(`Failed to update user account with phone number ${request.params.PhoneNumber}.`));
        } catch (ex) {
            response
                .status(HttpStatus.BAD_REQUEST)
                .json(this.Error<UserAccount>(`Failed to update user account with phone number ${request.params.PhoneNumber}.`));
        }
    }

    private async GetAccount(phoneNumber: string) {
        return await firebaseHelper.firestore.getDocument(this.Database, this.USER_ACCOUNTS, phoneNumber);
    }

    private async GetAccountByPhoneNumber(request, response) {
        try {
            let record = await this.GetAccount(request.params.PhoneNumber);
            if (record)
                response
                    .status(HttpStatus.OK)
                    .json(this.Result<UserAccount>(record));
            else
                response
                    .status(HttpStatus.BAD_REQUEST)
                    .json(this.Error<UserAccount>(`Failed to get user account for phone number ${request.params.PhoneNumber}.`))

        } catch (ex) {
            response
                .status(HttpStatus.BAD_REQUEST)
                .json(this.Error<UserAccount>(`Failed to get user account for phone number ${request.params.PhoneNumber}: ${ex}`))
        }
    }

    private async SignIn(request, response) {
        try {
            let record = await this.GetAccount(request.params.PhoneNumber);
            if (record) {
                if (record.IsActive)
                    response
                        .status(HttpStatus.OK)
                        .json(this.Result<UserAccount>(record));
                else
                    response
                        .status(HttpStatus.BAD_REQUEST)
                        .json(this.Error<UserAccount>(`User account for phone number ${request.params.PhoneNumber} is not active.`));
            } else
                response
                    .status(HttpStatus.BAD_REQUEST)
                    .json(this.Error<UserAccount>(`Failed to get user account for phone number ${request.params.PhoneNumber}.`))
        } catch (ex) {
            response
                .status(HttpStatus.BAD_REQUEST)
                .json(this.Error<UserAccount>(`Failed to get user account for phone number ${request.params.PhoneNumber}: ${ex}`))
        }
    }

    private async GetAccounts(request, response) {
        try {
            let records = await firebaseHelper.firestore.backup(this.Database, this.USER_ACCOUNTS)
            if (records)
                response
                    .status(HttpStatus.OK)
                    .json(this.Result<unknown>(records))
            else
                response
                    .status(HttpStatus.BAD_REQUEST)
                    .json(this.Error<UserAccount>(`Failed to get user accounts.`))
        } catch (ex) {
            response
                .status(HttpStatus.BAD_REQUEST)
                .json(this.Error<UserAccount>(`Failed to get user accounts: ${ex}`))
        }
    }

    private async DeleteAccount(request, response) {
        const deletedRecord = await firebaseHelper.firestore.deleteDocument(this.Database, this.USER_ACCOUNTS, request.params.PhoneNumber);
        if (deletedRecord)
            response
                .status(HttpStatus.NO_CONTENT)
                .json(this.Result<object>(deletedRecord));
        else
            response
                .status(HttpStatus.BAD_REQUEST)
                .json(this.Error<UserAccount>(`Failed to delete user account with phone number ${request.params.PhoneNumber}.`))
    }

    protected RegisterMethods(): void {
        this.RegisterMethod(HttpMethod.Post, `/${this.USER_ACCOUNTS}`, async (request, response) => await this.CreateAccount(request, response));
        this.RegisterMethod(HttpMethod.Patch, `/${this.USER_ACCOUNTS}/:PhoneNumber`, async (request, response) => await this.UpdateAccount(request, response));
        this.RegisterMethod(HttpMethod.Get, `/${this.USER_ACCOUNTS}/:PhoneNumber`, async (request, response) => await this.GetAccountByPhoneNumber(request, response));
        this.RegisterMethod(HttpMethod.Get, `/${this.USER_ACCOUNTS}`, async (request, response) => await this.GetAccounts(request, response));
        this.RegisterMethod(HttpMethod.Delete, `/${this.USER_ACCOUNTS}/:PhoneNumber`, async (request, response) => await this.DeleteAccount(request, response));
        this.RegisterMethod(HttpMethod.Get, `/${this.USER_ACCOUNTS}/SignIn/:PhoneNumber`, async (request, response) => await this.SignIn(request, response));
    }
}