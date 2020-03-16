import * as firebaseHelper from 'firebase-functions-helper';
import * as HttpStatus from 'http-status-codes';
import { Md5 } from 'ts-md5/dist/md5';
import { BaseService, HttpMethod } from "./base.service";
import { UserAccount } from "../models";

const USER_ACCOUNTS = 'UserAccounts';
const DEFAULT_PASSWORD = 'password@123';

export class UserAccountService extends BaseService {

    private GetMd5(data: string): string {
        let md5 = new Md5().appendStr(data).end();
        return md5.toString();
    }

    private async Create(request, response) {
        try {
            let password = request.body['Password'] ?? this.GetMd5(DEFAULT_PASSWORD);
            let image = request.body['Image'] ?? '';
            let lastName = request.body['LastName'] ?? '';
            let addressLine2 = request.body['AddressLine2'] ?? '';
            let isActive = request.body['IsActive'] ?? false;
            let isAdmin = request.body['IsAdmin'] ?? false;

            let account: UserAccount = {
                PhoneNumber: request.body['PhoneNumber'],
                FirstName: request.body['FirstName'],
                LastName: lastName,
                AddressLine1: request.body['AddressLine1'],
                AddressLine2: addressLine2,
                City: request.body['City'],
                Password: password,
                Image: image,
                Balance: 0,
                IsActive: isActive,
                IsAdmin: isAdmin
            };

            let isCreated = await firebaseHelper.firestore.createDocumentWithID(this.Database, USER_ACCOUNTS, account.PhoneNumber, account);
            if (isCreated)
                response
                    .status(HttpStatus.OK)
                    .json(this.Result<UserAccount>(account));
            else
                response
                    .status(HttpStatus.OK)
                    .json(this.Error<UserAccount>(`Failed to create user account: ${account}`));
        } catch (ex) {
            response
                .status(HttpStatus.OK)
                .json(this.Error<UserAccount>(`Failed to create user account. ${ex}`));
        }
    }

    private async Update(request, response) {
        try {
            let updatedRecord = await firebaseHelper.firestore.updateDocument(this.Database, USER_ACCOUNTS, request.params.PhoneNumber, request.body);
            if (updatedRecord)
                response
                    .status(HttpStatus.OK)
                    .json(this.Result<UserAccount>(updatedRecord));
            else
                response
                    .status(HttpStatus.OK)
                    .json(this.Error<UserAccount>(`Failed to update user account with phone number ${request.params.PhoneNumber}.`));
        } catch (ex) {
            response
                .status(HttpStatus.OK)
                .json(this.Error<UserAccount>(`Failed to update user account with phone number ${request.params.PhoneNumber}. ${ex}`));
        }
    }

    private async Get(phoneNumber: string) {
        let record = await firebaseHelper.firestore.getDocument(this.Database, USER_ACCOUNTS, phoneNumber);
        if (record)
            return this.Deserialize<UserAccount>(record);
        else
            return undefined;
    }

    private async GetByPhoneNumber(request, response) {
        try {
            let record = await this.Get(request.params.PhoneNumber);
            if (record)
                response
                    .status(HttpStatus.OK)
                    .json(this.Result<UserAccount>(record));
            else
                response
                    .status(HttpStatus.OK)
                    .json(this.Error<UserAccount>(`User account with phone number ${request.params.PhoneNumber} does not exist.`))

        } catch (ex) {
            response
                .status(HttpStatus.OK)
                .json(this.Error<UserAccount>(`Failed to get user account with phone number ${request.params.PhoneNumber}: ${ex}`))
        }
    }

    private async SignIn(request, response) {
        try {
            let phoneNumber = request.body['PhoneNumber'];
            let password = request.body['Password'];

            let record = await this.Get(phoneNumber);
            if (record) {
                if (record.Password !== password) {
                    response
                        .status(HttpStatus.OK)
                        .json(this.Error<UserAccount>(`Password is incorrect.`));
                    return;
                }

                if (!record.IsActive) {
                    response
                        .status(HttpStatus.OK)
                        .json(this.Error<UserAccount>(`User account for phone number ${request.params.PhoneNumber} is not active.`));
                    return;
                }

                response
                    .status(HttpStatus.OK)
                    .json(this.Result<UserAccount>(record));

            } else
                response
                    .status(HttpStatus.OK)
                    .json(this.Error<UserAccount>(`User account for phone number ${request.params.PhoneNumber} does not exist.`))
        } catch (ex) {
            response
                .status(HttpStatus.OK)
                .json(this.Error<UserAccount>(`Failed to get user account for phone number ${request.params.PhoneNumber}: ${ex}`))
        }
    }

    private async GetMany(request, response) {
        try {
            let records = await firebaseHelper.firestore.backup(this.Database, USER_ACCOUNTS)
            if (records)
                response
                    .status(HttpStatus.OK)
                    .json(this.ResultArray<UserAccount[]>(records, USER_ACCOUNTS));
            else
                response
                    .status(HttpStatus.OK)
                    .json(this.Error<UserAccount[]>(`Failed to get user accounts.`))
        } catch (ex) {
            response
                .status(HttpStatus.OK)
                .json(this.Error<UserAccount>(`Failed to get user accounts: ${ex}`))
        }
    }

    private async Delete(request, response) {
        const deletedRecord = await firebaseHelper.firestore.deleteDocument(this.Database, USER_ACCOUNTS, request.params.PhoneNumber);
        if (deletedRecord)
            response
                .status(HttpStatus.OK)
                .json(this.Result<object>(deletedRecord));
        else
            response
                .status(HttpStatus.OK)
                .json(this.Error<UserAccount>(`Failed to delete user account with phone number ${request.params.PhoneNumber}.`))
    }

    RegisterMethods(): void {
        this.RegisterMethod(HttpMethod.Post, `/${USER_ACCOUNTS}`, async (request, response) => await this.Create(request, response));
        this.RegisterMethod(HttpMethod.Patch, `/${USER_ACCOUNTS}/:PhoneNumber`, async (request, response) => await this.Update(request, response));
        this.RegisterMethod(HttpMethod.Get, `/${USER_ACCOUNTS}/:PhoneNumber`, async (request, response) => await this.GetByPhoneNumber(request, response));
        this.RegisterMethod(HttpMethod.Get, `/${USER_ACCOUNTS}`, async (request, response) => await this.GetMany(request, response));
        this.RegisterMethod(HttpMethod.Delete, `/${USER_ACCOUNTS}/:PhoneNumber`, async (request, response) => await this.Delete(request, response));
        this.RegisterMethod(HttpMethod.Post, `/${USER_ACCOUNTS}/SignIn`, async (request, response) => await this.SignIn(request, response));
    }
}