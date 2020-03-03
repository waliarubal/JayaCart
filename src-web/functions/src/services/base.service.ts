import * as express from 'express';
import * as admin from 'firebase-admin';

export abstract class BaseService {
    
    constructor(
        private readonly _db: admin.firestore.Firestore, 
        private readonly _app: express.Express) {

    }

    protected get Database(): admin.firestore.Firestore {
        return this._db;
    }

    protected get Application(): express.Express {
        return this._app;
    }

    abstract RegisterMethods(): void;

}