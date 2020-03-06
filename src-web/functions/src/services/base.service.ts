import * as express from 'express';
import * as admin from 'firebase-admin';
import { ApiResponse } from '../models';

export type ApiRequestHandler = (request: any, response: any) => Promise<void>;

export enum HttpMethod {
    Get,
    Post,
    Put,
    Delete,
    Patch,
    Head
}

export abstract class BaseService {

    constructor(
        private readonly _db: admin.firestore.Firestore,
        private readonly _app: express.Express) {

    }

    protected get Database(): admin.firestore.Firestore {
        return this._db;
    }

    protected RegisterMethod(method: HttpMethod, route: string, handler: ApiRequestHandler): void {
        switch (method) {
            case HttpMethod.Get:
                this._app.get(route, handler);
                break;

            case HttpMethod.Post:
                this._app.post(route, handler);
                break;

            case HttpMethod.Put:
                this._app.put(route, handler);
                break;

            case HttpMethod.Delete:
                this._app.delete(route, handler);
                break;

            case HttpMethod.Patch:
                this._app.patch(route, handler);
                break;

            case HttpMethod.Head:
                this._app.head(route, handler);
                break;
        }
    }

    abstract RegisterMethods(): void;

    protected Error<T>(error: string): ApiResponse<T> {
        console.log(error);
        return new ApiResponse<T>(null, error);
    }

    protected Result<T>(result: T): ApiResponse<T> {
        return new ApiResponse<T>(result);
    }

}