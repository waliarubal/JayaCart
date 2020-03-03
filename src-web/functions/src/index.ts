import * as functions from 'firebase-functions';
import * as admin from 'firebase-admin';
import * as express from 'express';
import * as bodyParser from 'body-parser';
import { UserAccountService } from './services/user-account.service';

admin.initializeApp(functions.config().firebase);

const app = express();

const main = express();
main.use('/api/v1', app);
main.use(bodyParser.json());
main.use(bodyParser.urlencoded({ extended: false }));

export const webApi = functions.https.onRequest(main);

const db = admin.firestore();

let services = [
    new UserAccountService(db, app)
];
for (let service of services)
    service.RegisterMethods();