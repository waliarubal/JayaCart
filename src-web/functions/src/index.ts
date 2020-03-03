import * as functions from 'firebase-functions';
import * as admin from 'firebase-admin';
import * as firebaseHelper from 'firebase-functions-helper';
import * as express from 'express';
import * as bodyParser from 'body-parser';

import { UserAccount } from './models/user-account';

admin.initializeApp(functions.config().firebase);

const app = express();

const main = express();
main.use('/api/v1', app);
main.use(bodyParser.json());
main.use(bodyParser.urlencoded({ extended: false }));

export const webApi = functions.https.onRequest(main);

const USER_ACCOUNTS = 'UserAccounts';

const db = admin.firestore();

app.post(`/${USER_ACCOUNTS}`, async (request, response) => {
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
            Balance: 0
        };

        let isCreated = await firebaseHelper.firestore.createDocumentWithID(db, USER_ACCOUNTS, account.PhoneNumber, account);
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
});

app.patch(`/${USER_ACCOUNTS}/:PhoneNumber`, async (request, response) => {
    try {
        await firebaseHelper.firestore.updateDocument(db, USER_ACCOUNTS, request.params.PhoneNumber, request.body);
        response.status(204).json(request.body);
    } catch (ex) {
        response.status(400).send(`Failed to update user account with phone number ${request.params.PhoneNumber}.`);
    }
});

app.get(`/${USER_ACCOUNTS}/:PhoneNumber`, (request, response) => {
    firebaseHelper.firestore.getDocument(db, USER_ACCOUNTS, request.params.PhoneNumber)
        .then(record => response.status(200).json(record))
        .catch(ex => response.status(400).send(`Failed to get user account for phone number ${request.params.PhoneNumber}: ${ex}`));
});

app.get(`/${USER_ACCOUNTS}`, (request, response) => {
    firebaseHelper.firestore.backup(db, USER_ACCOUNTS)
        .then(records => response.status(200).json(records))
        .catch(ex => response.status(400).send(`Failed to get user accounts: ${ex}`));
});

app.delete(`/${USER_ACCOUNTS}/:PhoneNumber`, async (request, response) => {
    const deletedRecord = await firebaseHelper.firestore.deleteDocument(db, USER_ACCOUNTS, request.params.PhoneNumber);
    response.status(204).json(deletedRecord);
});