import * as functions from 'firebase-functions';
import * as admin from 'firebase-admin';
import * as express from 'express';
import * as cors from 'cors';
import * as bodyParser from 'body-parser';
import { UserAccountService } from './services/user-account.service';

admin.initializeApp(functions.config().firebase);

const app = express();
const Cors = cors();

const main = express();
main.use('/api/v1', app);
main.use(bodyParser.json());
main.use(bodyParser.urlencoded({ extended: false }));

const db = admin.firestore();

new UserAccountService(db, app, Cors)

export const webApi = functions.https.onRequest(main);